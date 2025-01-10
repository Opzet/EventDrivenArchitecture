# Event Driven Architecture Annotator: Code-First Approach

**Intent:** Documentation from a single source of truth — the [annotated] code

The **Event Annotator** is a **code-first tool** designed to enable developers to annotate source code in a way that automatically generates documentation. This documentation is then rendered in the **Event Viewer**.

By focusing on code annotations, this tool ensures that event-driven architecture (EDA) documentation is always up-to-date and automatically generated, directly reflecting changes in the source code.

This approach differs from the **model-first** method, as it allows for seamless integration of third-party event-driven components into your existing architecture. The **Event Annotator** makes managing complex event-driven integrations simpler by directly using the annotated code as the source of truth, removing the need for separately maintained models.

---

## Example: Annotating C# Code

The `AddUserCommand` class demonstrates how the **Event Annotator** can be used to generate documentation from annotated source code.

```csharp
namespace UserRegistration.Domain.Commands
{
    /// <summary>
    /// Command to register a new user.
    /// </summary>
    /// <remarks>
    /// In the context of Event Sourcing, commands are used to encapsulate all the information needed to perform an action or trigger a state change in the system.
    /// Commands are part of the Command Query Responsibility Segregation (CQRS) pattern, where they represent the "write" side of the application.
    /// 
    /// When a command is issued, it is handled by a command handler, which performs the necessary business logic and generates one or more events.
    /// These events are then persisted to an event store and used to update the state of the application.
    /// 
    /// The RegisterUserCommand class encapsulates the data required to register a new user, including the user's name, email, and password.
    /// When this command is handled, it will result in an event (e.g., UserRegisteredEvent) that represents the successful registration of the user.
    /// </remarks>
    [CommandMetadata(
        domain: "RegisterUser",
        name: "RegisterUser",
        description: "Command to register a new user.",
        version: "1.0",
        summary: "Registers a new user in the system.",
        owners: new[] { "admin@example.com" },
        address: "https://api.example.com/register",
        protocols: new[] { "HTTP", "HTTPS" },
        environments: new[] { "Production", "Staging" },
        channelOverview: "User registration channel"
    )]
    public class AddUserCommand
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }
    }
}
```

In this example, the `AddUserCommand` class is annotated with detailed metadata such as the domain, version, description, and the protocols it supports. This metadata forms the basis for the Event Catalog documentation.

---

## Workflow Overview

### Step 1: Generate and Save Event Documentation (MDX Catalog)
- Annotate your C# source code with event details.
- Use the **bootstrapped** process to generate an **MDX documentation catalog** from the annotated code.
- The catalog is generated using the `eventcatalog build` command.
- The output is a comprehensive **EventCatalog** containing event definitions, relationships, and other relevant documentation in MDX format.

### Step 2: Bootstrap the Event Catalog
- The bootstrapped event catalog is automatically consumed by the `eventcatalog build` command.
- This command processes your annotated C# code and generates the event documentation, which is now ready for consumption.

### Step 3: Compile and Serve the Event Catalog
Once the catalog is bootstrapped, the documentation can be compiled and served:
- You can compile the **EventCatalog** for visualization purposes, generating a static site that can be hosted anywhere.
- Use the following command to build the static site:

  ```bash
  eventcatalog build
  ```

- The **EventCatalog** app provides a set of powerful scripts to:
  - Generate the documentation catalog.
  - Serve the catalog locally or deploy it to any hosting platform.

---

## Features

- **Document Generation:** Automatically generates the Event Catalog schema directly from annotated source code.
- **Event Catalog Schema:** Defines events and their relationships, providing a comprehensive backbone for your event-driven architecture.
- **Deploy:** Generate static visualization of the Event Catalog that can be hosted anywhere for easy access.
- **Open-Source Visualization:** The Event Viewer provides a clear, interactive way to visualize event relationships and documentation.

### Key Benefits:
- **Event Discoverability:** Bring discoverability and governance to your event-driven architecture.
- **Comprehensive Documentation:** Document your domains, services, events (commands, queries), and channels.
- **Supports OpenAPI:** Supports documenting OpenAPI specifications, schemas, and code examples.
- **Visualize Event Flow:** Visualize the flow between messages (events, commands, queries) in your system, making it easier to understand and manage.

---

## Complexities with Event-Driven Architectures

As event-driven architectures grow and become more complex, understanding the relationships between different components can be challenging. Over time, questions begin to emerge, such as:

- What messages (events, commands, queries) exist in the system?
- What is the purpose of these messages, and what context do they belong to?
- What are the payloads of these messages?
- How can changes be made to the messages or events?
- Who is consuming these messages?

By using the **Event Annotator** and **EventCatalog**, you can answer these questions quickly and effectively, improving the maintainability and clarity of your event-driven architecture.

---

## Event Visualizer: Open-Source Tool

The **Event Viewer** is an open-source, community-driven tool designed to help visualize your event catalog. It transforms complex event flows into clear, interactive diagrams, providing insights at a glance.

- **User-Friendly Format:** Makes understanding complex event flows easy and intuitive.
- **Cross-Team Communication:** Helps teams communicate event flows and event-driven architectures effectively.

For more details, visit: [Event Catalog - Viewer](https://www.kallemarjokorpi.fi/blog/how-to-create-and-event-catalog/)

---

## Comparison: Code-First vs. Model-First

| **Feature**                         | **Code-First Approach (Event Annotator)**                                        | **Model-First Approach**                                                    |
|-------------------------------------|---------------------------------------------------------------------------------|------------------------------------------------------------------------------|
| **Source of Truth**                 | Documentation is generated directly from annotated code.                         | Documentation is created based on pre-defined event models or designs.      |
| **Integration of External Events**  | Easily integrates third-party event-driven components directly from code.       | Integrating third-party events may require manual model updates.            |
| **Documentation Synchronization**   | Real-time synchronization with codebase ensures documentation stays current.    | Documentation may become out of sync if models or event definitions change.  |
| **Ease of Use**                     | Simple to implement and maintain by annotating code directly.                   | Requires defining and maintaining separate event models.                    |
| **Flexibility**                     | More flexible, especially for projects that evolve rapidly.                     | Less flexible, as it requires adjustments to the event models when changes occur. |
| **Complexity**                      | Simplifies complex integration scenarios, especially with third-party systems.  | Can become cumbersome with complex integrations or updates.                 |

The **Event Annotator** focuses on generating documentation directly from the codebase, while the **model-first approach** relies on pre-defined models to create event-driven architectures.

---

## Model-First Approach (Proprietary)

The **model-first** approach often uses proprietary tools such as **Event Studio** for designing and managing event catalogs. These visual editors allow for drag-and-drop configurations but may require more overhead in keeping event models in sync with the implementation.
![image](https://github.com/user-attachments/assets/ab87d532-e34e-40a0-8060-f8bef3d58c75)

### Key Features of Model-First:
- **Closed-Source Visual Editor:** Drag-and-drop editor for creating event catalogs.
- **Code Generation:** Automatically generates scaffold code for integrating third-party services.
- **Event Catalog Schema:** Defines events and relationships but relies on visual tools to maintain it.

For more details on the **Event Catalog Generator** and **Event Studio**, please refer to the **Event Catalog Generator Documentation**.

---

### Get Started

To get started with the **Event Annotator**, ensure your C# project is set up with event annotations, then use the EventCatalog tools to generate and visualize your event documentation.

For detailed instructions, refer to the official documentation on [Event Annotator GitHub](https://github.com/your-repo-link).

---

## Modeller App:

Could utilise https://github.com/amaurote/NodeGraphControl/

https://github.com/amaurote/NodeGraphControl/blob/master/res/sample_use.PNG
