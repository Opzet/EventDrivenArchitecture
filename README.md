
## Event-Driven Architecture

Event-driven architecture is considered to be the holy grail of system design in many ways. Its design is based on events, which are actions around which we can build reactive systems. This leads to asynchronous, decoupled, persistent, fault-tolerant and scalable systems.
Event-sourcing is a powerful pattern that allows you to capture all changes to an application's state as a sequence of events. This approach provides a historical view of the application's state and enables you to reconstruct past states at any point in time. 
When combined with the Command Query Responsibility Segregation (CQRS) pattern, event-sourcing becomes even more potent.

Move away from a single representation that we interact with via CRUD, and move to a task-based UI.

### CRUD Pattern
The mainstream approach people use for interacting with an information system is to treat it as a CRUD datastore. 
![image](https://github.com/user-attachments/assets/20fd4f29-4e3b-4f14-98d9-eda66e19df63)
By this I mean that we have mental model of some record structure where we can create new records, read records, update existing records, and delete records when we're done with them. In the simplest case, our interactions are all about storing and retrieving these records.

### Command Query Responsibility Segregation (CQRS) pattern
As our needs become more sophisticated we steadily move away from that model. We may want to look at the information in a different way to the record store, perhaps collapsing multiple records into one, or forming virtual records by combining information for different places. 

On the update side we may find validation rules that only allow certain combinations of data to be stored, or may even infer data to be stored that's different from that we provide.

CQRS is a significant mental leap 

![image](https://github.com/user-attachments/assets/3c8db98b-624a-4303-8a15-b20c4f6341a7)


CQRS naturally fits with some other architectural patterns.

-  As we move away from a single representation that we interact with via CRUD, we can easily move to a task-based UI.
-  CQRS fits well with event-based programming models. It's common to see CQRS system split into separate services communicating with Event Collaboration. This allows these services to easily take advantage of Event Sourcing.
-  Having separate models raises questions about how hard to keep those models consistent, which raises the likelihood of using eventual consistency.
-  For many domains, much of the logic is needed when you're updating, so it may make sense to use EagerReadDerivation to simplify your query-side models.
-  If the write model generates events for all updates, you can structure read models as EventPosters, allowing them to be MemoryImages and thus avoiding a lot of database interactions.
-  CQRS is suited to complex domains, the kind that also benefit from Domain-Driven Design.

As this occurs we begin to see multiple representations of information. When users interact with the information they use various presentations of this information, each of which is a different representation. 

Developers typically build their own conceptual model which they use to manipulate the core elements of the model. Usually there's enough overlap between the command and query sides that sharing a model is easier.

If you're using a Domain Model, then this is usually the conceptual representation of the domain. You typically also make the persistent storage as close to the conceptual model as you can. 

CAUTION : Using CQRS on a domain that doesn't match it will add complexity, thus reducing productivity and increasing risk.


This structure of multiple layers of representation can get quite complicated, but when people do this they still resolve it down to a single conceptual representation which acts as a conceptual integration point between all the presentations.

The change that CQRS introduces is to split that conceptual model into separate models for update and display, which it refers to as Command and Query respectively following the vocabulary of CommandQuerySeparation. The rationale is that for many problems, particularly in more complicated domains, having the same conceptual model for commands and queries leads to a more complex model that does neither well.



### Getting Started with Event Sourcing in .NET

https://www.youtube.com/watch?v=n_o-xuuVtmw

https://dometrain.com/course/from-zero-to-hero-event-driven-architecture/




## What is Event-Sourcing and CQRS?
https://mbarkt3sto.hashnode.dev/how-to-implement-event-sourcing-with-cqrs-using-ef-core-and-mediatr

Event-sourcing is a pattern that represents the state of an application as a series of events. Instead of storing the current state of an object, you store a log of events that have occurred, which can be replayed to reconstruct the state at any given point in time. Each event represents a discrete change in the application's state and is immutable.

CQRS, on the other hand, is a pattern that separates the read and write operations in an application. It distinguishes between commands (requests that modify state) and queries (requests that retrieve state). By segregating these concerns, you can optimize the read and write models independently, leading to better performance and scalability.
