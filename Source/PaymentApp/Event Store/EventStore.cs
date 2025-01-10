using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class EventStore : IEventStore
{
    private readonly IEventStoreConnection _connection; public EventStore(IEventStoreConnection connection)
    {
        _connection = connection;
    }
    public async IAsyncEnumerable<Event> GetAggregateEventsAsync<TEventSourcedAggregate>(Guid aggregateId)
    where TEventSourcedAggregate : EventSourcedAggregate
    {
        var streamName = GetAggregateStreamName<TEventSourcedAggregate>(aggregateId);
        StreamEventsSlice currentSlice;
        var nextSliceStart = (long)StreamPosition.Start; do
        {
            currentSlice = await _connection.ReadStreamEventsForwardAsync(streamName, nextSliceStart, 10, false);
            nextSliceStart = currentSlice.NextEventNumber; foreach (var resolvedEvent in currentSlice.Events)
                yield return EventStoreSerializer.Deserialize(resolvedEvent);
        } while (!currentSlice.IsEndOfStream);
    }
    public async Task SaveAggregateEventsAsync<TEventSourcedAggregate>(Guid aggregateId, IEnumerable<Event> events, int expectedVersion)
    where TEventSourcedAggregate : EventSourcedAggregate
    {
        var streamName = GetAggregateStreamName<TEventSourcedAggregate>(aggregateId);
        var eventsToSave = events.Select(@event => EventStoreSerializer.Serialize(@event));
        await _connection.AppendToStreamAsync(streamName, expectedVersion, eventsToSave);
    }
    private static string GetAggregateStreamName<TEventSourcedAggregate>(Guid aggregateId)
    where TEventSourcedAggregate : EventSourcedAggregate
    {
        return $"{typeof(TEventSourcedAggregate).Name}-{aggregateId}";
    }
}
public sealed class EventSourcedRepository<TEventSourcedAggregate> : IEventSourcedRepository<TEventSourcedAggregate>
where TEventSourcedAggregate : EventSourcedAggregate, new()
{
    private readonly IEventStore _eventStore; public EventSourcedRepository(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    public async Task SaveAsync(TEventSourcedAggregate aggregate)
    {
        var uncommittedEvents = aggregate.GetUncommittedEvents();
        if (!uncommittedEvents.Any())
            return; var originalVersion = aggregate.Version - uncommittedEvents.Count;
        var expectedVersion = originalVersion == 0
        ? ExpectedVersion.NoStream
        : originalVersion - 1; try
        {
            await _eventStore.SaveAggregateEventsAsync<TEventSourcedAggregate>(aggregate.Id, uncommittedEvents, expectedVersion);
        }
        catch (WrongExpectedVersionException e)
        when (e.ExpectedVersion == ExpectedVersion.NoStream)
        {
            throw new DuplicateKeyException(aggregate.Id);
        }
        aggregate.MarkEventsAsCommitted();
    }
    public async Task<TEventSourcedAggregate?> GetAsync(Guid id)
    {
        TEventSourcedAggregate? aggregate = null; await foreach (var @event in _eventStore.GetAggregateEventsAsync<TEventSourcedAggregate>(id))
            (aggregate ??= new TEventSourcedAggregate()).ApplyEvent(@event); return aggregate;
    }
}