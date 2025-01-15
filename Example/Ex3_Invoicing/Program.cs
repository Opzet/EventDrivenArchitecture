using Ex3_Invoicing.Infrastructure;
using Ex3_Invoicing.Model;
using Ex3_Invoicing.Resolve;
using static Ex3_Invoicing.Events.InvoiceEvents;
using static Ex3_Invoicing.Model.Invoice;

namespace Ex3_Invoicing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DemoEventSourcing();
        }

        static void DemoEventSourcing()
        {
            // Events are immutable and are used to capture and persist these state changes.

            EventStore eventStore = new EventStore();

            Console.WriteLine("EDA with Event Sourcing");
            var invoiceInitiated = new InvoiceInitiated(
                "INV/2021/11/01",
                34.12,
                new Person("Oscar the Grouch", "123 Sesame Street"),
                DateTime.UtcNow
            );
            eventStore.Append(invoiceInitiated);

            var invoiceIssued = new InvoiceIssued(
                "Cookie Monster",
                DateTime.UtcNow
            );
            eventStore.Append(invoiceIssued);


            var invoiceSent = new InvoiceSent(
                InvoiceSendMethod.Email,
                DateTime.UtcNow
            );

            eventStore.Append(invoiceSent);

            // Get all events from the event store
            var events = eventStore.GetAllEvents();

        }




        static void Demo_eventinmemory()
        {
            Console.WriteLine("List of Events in memory");

            var invoiceInitiated = new InvoiceInitiated(
                "INV/2021/11/01",
                34.12,
                new Person("Oscar the Grouch", "123 Sesame Street"),
                DateTime.UtcNow
            );

            var invoiceIssued = new InvoiceIssued(
                "Cookie Monster",
                DateTime.UtcNow
            );

            var invoiceSent = new InvoiceSent(
                InvoiceSendMethod.Email,
                DateTime.UtcNow
            );

            // Pre changing to infrastructure with event dispatcher
            // 1,2. Get all events and sort them in the order of appearance
            var events = new object[] { invoiceInitiated, invoiceIssued, invoiceSent };

            // 3. Construct empty Invoice object
            var invoiceView = new Invoice();

            // 4. Apply each event on the entity and print details
            foreach (var @event in events)
            {
                InvoiceAggregrate invoiceAggregrate = new InvoiceAggregrate();
                invoiceAggregrate.Evolve(@event);

                invoiceView = invoiceAggregrate.invoiceRendered;

                // Print event details
                Console.WriteLine($"Event Applied: {@event.GetType().Name}");
                switch (@event)
                {
                    case InvoiceInitiated e:
                        Console.WriteLine($"Invoice Number: {e.Number}");
                        Console.WriteLine($"Amount: {e.Amount}");
                        Console.WriteLine($"Customer: {e.Customer.Name}, Address: {e.Customer.Address}");
                        Console.WriteLine($"Date: {e.InitiatedAt}");
                        break;
                    case InvoiceIssued e:
                        Console.WriteLine($"Issued By: {e.IssuedBy}");
                        Console.WriteLine($"Date: {e.IssuedAt}");
                        break;
                    case InvoiceSent e:
                        Console.WriteLine($"Send Method: {e.SentVia}");
                        Console.WriteLine($"Date: {e.SentAt}");
                        break;
                }

                // Print current state of the invoice
                Console.WriteLine("Current Invoice State:");
                Console.WriteLine($"Invoice Number: {invoiceView.Number}");
                Console.WriteLine($"Amount: {invoiceView.Amount}");
                Console.WriteLine($"Customer: {invoiceView.Customer?.Name}, Address: {invoiceView.Customer?.Address}");
                Console.WriteLine($"Issued By: {invoiceView.IssuedBy}");
                Console.WriteLine($"Send Method: {invoiceView.SentVia}");
                Console.WriteLine();
            }
        }
    }
}
