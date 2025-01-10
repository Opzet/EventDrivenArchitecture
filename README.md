
## Event-Driven Architecture

Event-driven architecture is considered to be the holy grail of system design in many ways. Its design is based on events, which are actions around which we can build reactive systems. This leads to asynchronous, decoupled, persistent, fault-tolerant and scalable systems.
Event-sourcing is a powerful pattern that allows you to capture all changes to an application's state as a sequence of events. This approach provides a historical view of the application's state and enables you to reconstruct past states at any point in time. 
When combined with the Command Query Responsibility Segregation (CQRS) pattern, event-sourcing becomes even more potent.

Move away from a single representation that we interact with via CRUD, and move to a task-based UI.

Stakeholders can **Visualise**  : [Event Catalog - Viewer Demo ](https://demo.eventcatalog.dev/visualiser/domains/Orders/0.0.3 )

![EDA Visualisation](https://github.com/user-attachments/assets/908fd877-6b81-4f6f-923f-bbdc68b04b39)

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


## CQRS Pattern
Many people have been getting confused over what CQRS is. They look at CQRS as being an architecture; it is not. CQRS is a very simple pattern that enables many opportunities for architecture that may otherwise not exist. CQRS is not eventual consistency, it is not eventing, it is not messaging, it is not having separated models for reading and writing, nor is it using event sourcing. I want to take a few paragraphs to describe first exactly what CQRS is and then how it relates to other patterns.

 
### CQRS Command and Query Responsibility Segregation
Starting with CQRS, CQRS is simply the creation of two objects where there was previously only one. The separation occurs based upon whether the methods are a command or a query (the same definition that is used by Meyer in Command and Query Separation, a command is any method that mutates state and a query is any method that returns a value).

When most people talk about CQRS they are really speaking about applying the CQRS pattern to the object that represents the service boundary of the application. Consider the following pseudo-code service definition.

**CustomerService**

```csharp
void MakeCustomerPreferred(CustomerId)
Customer GetCustomer(CustomerId)
CustomerSet GetCustomersWithName(Name)
CustomerSet GetPreferredCustomers()
void ChangeCustomerLocale(CustomerId, NewLocale)
void CreateCustomer(Customer)
void EditCustomerDetails(CustomerDetails)

``` 

Applying CQRS on this would result in two services

CustomerWriteService

```csharp
void MakeCustomerPreferred(CustomerId)
void ChangeCustomerLocale(CustomerId, NewLocale)
void CreateCustomer(Customer)
void EditCustomerDetails(CustomerDetails)
```
CustomerReadService

```csharp
Customer GetCustomer(CustomerId)
CustomerSet GetCustomersWithName(Name)
CustomerSet GetPreferredCustomers()
```

That is it. That is the entirety of the CQRS pattern. There is nothing more to it than that… Doesn’t seem nearly as interesting when we explain it this way does it? This separation however enables us to do many interesting things architecturally, the largest is that it forces a break of the mental retardation that because the two use the same data they should also use the same data model.

The largest possible benefit though is that it recognizes that their are different architectural properties when dealing with commands and queries … for example it allows us to host the two services differently eg: we can host the read service on 25 servers and the write service on two. The processing of commands and queries is fundamentally asymmetrical, and scaling the services symmetrically does not make a lot of sense.

 

## Task Based UI
A task based UI is quite different from a CRUD based UI. 

In a task based UI you track what the user is doing and you push forward commands representing the intent of the user. 

I would like to state once and for all that CQRS does not require a task based UI. 
We could apply CQRS to a CRUD based interface (though things like creating separated data models would be much harder).

# Domain Driven Design.
There is however one thing that does really require a task based UI… That is Domain Driven Design.

## Application Service Layer
The Application Service Layer in Domain Driven Design represents the tasks the system can perform.

It does not just copy data to domain objects and save them… It should be dealing with behaviors on the objects… Before going further let’s look at what happened if we did;

there would be no verbs in our ubiquitous language except for “Create”, “Delete”, and “Change”.  

While there exist many domains where this is what the Ubiquitous Language is actually like, you probably should not be using Domain Driven Design for such systems.

The concept of a task based UI is more often than not assumed to be part of CQRS, it is not, it is there so the domain can have verbs but also capturing the intent of the user is important in general. 

Was this a managerial override or a normal update? Does it make a difference? It depends on what question you want to ask …

 
Moving on to the next pattern that gets confused into CQRS
 
## Event Sourcing

For this I want to be clear, when I use this term I am not encompassing all of what is written on the bliki. I am referring to storing current state as a series of events and rebuilding state within the system by replaying that series of events. .

On the command side of the equation, since reads are no longer on the domain, storing events can be a great way of keeping the current state. 

The value increases more if you decide to have two separate models (a write model and a read model) and you have a need to integrate between the two of them as you will likely be doing that through events. 

Since you are building the eventing anyway, why not just use the one model to manage your state?


## Messaging Patterns
There is no need to use messaging patterns with CQRS. 

That said, if you separate your data models you will more likely than not use messaging in the integration between the models because it offers interesting possibilities.

Finally I come to the last “pattern” I hate to call it a pattern when it is really a concept that people tend to put into their definitions of CQRS and it goes hand in hand with messaging.

 
## Eventual Consistency

Eventual consistency is also quite often introduced between the services. 

It is done for many architectural reasons but the largest is that it allows you to increase your scalability and availability. 

If you remember CAP theorem consistency if given up allows increases in the other two.

Eventual consistency is extremely useful in between the models if you have them in a separated fashion but is in no way a property of CQRS itself.

 
## Summary
Going through all of these we can see that CQRS itself is actually a fairly trivial pattern. 

What is interesting around CQRS is not CQRS itself but the architectural properties in the integration of the two services. 

In other words the interesting stuff is not really the CQRS pattern itself but in the architectural decisions that can be made around it. 

Don’t get me wrong there are a lot of interesting decisions that can be made around a system that has had CQRS applied … just don’t confuse all of those architectural decisions with CQRS itself.

### Note:

A simpler way to refer to the current most common architectures using CQRS, RIDE = Read, Intent, Domain, Events

Chosen as summary points of a typical cqrs system:
[Client] =Commands=> [Domain Model] =Events=> [Read Model] =DTOs=> [Client]

A key point is that Commands carry Intents, and summarizing a little this can be simplified:
[Client] => Intent => Domain => Events => Read => [Client]

And since a Client would typically read before having some intention, reordered:
Read => [Client] => Intent => Domain => Events

And since everything should be viewed from the Client perspective, we can leave that out:
**Read => Intent => Domain => Events = RIDE**
