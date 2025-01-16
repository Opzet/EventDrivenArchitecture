# Distributed System Design

<p><a href="https://learn.particular.net/courses/adsd-online?wvideo=4sl3iip87q"><img src="https://embed-ssl.wistia.com/deliveries/56374cb50b05345c10bb38956ffacc835f91e929.jpg?image_play_button_size=2x&amp;image_crop_resized=556x313&amp;image_play_button=1&amp;image_play_button_color=54bbffe0" width="400" height="225" style="width: 400px; height: 225px;"></a></p><p><a href="https://learn.particular.net/courses/adsd-online?wvideo=4sl3iip87q">Advanced Distributed Systems Design (Online)</a></p>

Modern architecture design practices for distributed systems with Service-Oriented Architecture 
https://udidahan.com/2009/12/09/clarified-cqrs/
https://learn.particular.net/courses/adsd-online


## Fallacies of Distributed Computing

Introduction: Systems vs. Applications

# Fallacy
 1. The network is reliable
 2. Latency isn’t a problem
 3. Bandwidth isn’t a problem
 4. The network is secure
 5. The network topology won’t change
 6. The admin will know what to do
 7. Transport cost isn’t a problem
 8. The network is homogeneous
 
 Summary:  fallacies of distributed computing
 1. The system is atomic
 2. The system is finished
 3. Towards a better development process
 4. The business logic can and should be centralized


## Coupling

Coupling in applications: afferent and efferent

Coupling in systems: platform, temporal and spatial

Coupling solutions: platform

Coupling solutions: temporal and spatial

Coupling: summary and Q&A

## Intro to messaging

 -  Why messaging?
 -  One-way, fire & forget
 -  Performance: messaging vs RPC
 -  Service interfaces vs strongly-typed messages
 -  Fault tolerance
 -  Auditing
 -  Web Services invocation

##  Exercise: selling messaging to your organization

Exercise: selling messaging to your organization - overview

Exercise: selling messaging to your organization - discussion (part 1)

Exercise: selling messaging to your organization - discussion (part 2)

Exercise: selling messaging to your organization - summary

##  Messaging patterns

-  Dealing with out of order messages
-  Request-response
-  Publish-subscribe
-  Publish-subscribe: topics
-  Exercise: dealing with out of order messages - overview
-  Exercise: dealing with out of order messages - solutions
-  Visualization
-  Messaging patterns: summary

## Architectural styles: Bus and Broker

-  Intro to architectural styles
-  Architectural styles: Broker
-  Architectural styles: Bus
-  Architectural styles: Bus vs Broker


## Intro to SOA

-  SOA tenets
-  Service example
-  Services modelling: Workflows, boundaries and business capabilities
-  UI composition and Branding service
-  IT/Ops service

## Exercise: services modelling
-  Exercise: services modelling (hotel) - overview
-  Exercise: services modelling (hotel) - solutions
-  SOA modelling process and approach
-  Domain analysis: Hotel
-  Domain analysis: Hotel - payment
-  Domain analysis: Hotel - booking
-  Domain analysis: Hotel - check-in

## Advanced SOA

-  Business components
-  Autonomous components
-  Autonomous components: deployment
-  Service boundaries
-  Reporting
-  Referential integrity
-  Team structure


## CQRS

-  Intro to CQRS
-  Non-collaborative domains
-  Collaborative domains
-  CQRS theory
-  CQRS in action
-  CQRS: summary
-  Q&A: event sourcing
-  Q&A: search, reporting, and requirements vs user wishes
-  Engine pattern
-  Q&A: engine pattern

## SOA: operational aspects

-  Deployment
-  Monitoring
-  Scaling
-  Fault-tolerance, backups, disaster recovery
-  Versioning

## Sagas/Long-running business processes modelling
-  Sagas: long-running processes
-  Sagas: request-response
-  Sagas: event-driven
-  Sagas: time component

### Exercise: saga design

-  Exercise: saga design - overview
-  Exercise: saga design - solutions

## SOA: modelling
-  Domain models
-  Testing domain models
-  Domain models deployment
-  Concurrency models
-  Realistic concurrency
-  Domain models: sagas

## Organizational transition to SOA
-  The rewrite tax
-  Phase 1: Good programming practices
-  Phase 2: Pub/sub
-  Phase 3: carve out pieces
-  Phase 4: attack the database

## Web Services and User Interfaces
-  Caching
-  Content Delivery Networks
-  Personalization
