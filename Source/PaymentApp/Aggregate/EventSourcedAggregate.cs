using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class EventSourcedAggregate
{
    private readonly List<Event> _events = new List<Event>(); public Guid Id { get; protected set; }
    public int Version { get; private set; }
    public void LoadFromHistory(IEnumerable<Event> events)
    {
        foreach (var @event in events)
            ApplyEvent(@event);
    }
    public IReadOnlyList<Event> GetUncommittedEvents()
    {
        return _events;
    }
    public void MarkEventsAsCommitted()
    {
        _events.Clear();
    }
    protected void Raise(Event @event)
    {
        @event.Version = Version + 1;
        _events.Add(@event);
        ApplyEvent(@event);
    }
    public void ApplyEvent(Event @event)
    {
        this.AsDynamic().Apply(@event);
        Version++;
    }
}
public sealed class Account : EventSourcedAggregate
{
    private decimal _balance; public static Account Open(Guid id, decimal balance)
    {
        if (balance < 0)
            throw new InvalidOperationException("Balance cannot be negative."); var account = new Account();
        account.Raise(new AccountOpened(id, balance));
        return account;
    }
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Amount must be positive."); if (amount > _balance)
            throw new InvalidOperationException("Cannot withdraw more than balance."); Raise(new WithdrawnFromAccount(Id, amount));
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Amount must be positive."); Raise(new DepositedToAccount(Id, amount));
    }
    private void Apply(AccountOpened @event)
    {
        Id = @event.AccountId;
        _balance = @event.Balance;
    }
    private void Apply(WithdrawnFromAccount @event)
    {
        _balance -= @event.Amount;
    }
    private void Apply(DepositedToAccount @event)
    {
        _balance += @event.Amount;
    }
}
public abstract class Event
{
    public int Version { get; set; }
}
public sealed class AccountOpened : Event
{
    public Guid AccountId { get; }
    public decimal Balance { get; }
    public AccountOpened(Guid accountId, decimal balance)
    {
        AccountId = accountId;
        Balance = balance;
    }
}
public sealed class DepositedToAccount : Event
{
    public Guid AccountId { get; }
    public decimal Amount { get; }
    public DepositedToAccount(Guid accountId, decimal amount)
    {
        AccountId = accountId;
        Amount = amount;
    }
}
public sealed class WithdrawnFromAccount : Event
{
    public Guid AccountId { get; }
    public decimal Amount { get; }
    public WithdrawnFromAccount(Guid accountId, decimal amount)
    {
        AccountId = accountId;
        Amount = amount;
    }
}
