using Ex3_Invoicing.Model;
using static Ex3_Invoicing.Events.Invoice;
using static Ex3_Invoicing.Model.Invoice;

namespace Ex3_Invoicing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

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

            // 1,2. Get all events and sort them in the order of appearance
            var events = new object[] { invoiceInitiated, invoiceIssued, invoiceSent };

            // 3. Construct empty Invoice object
            var invoice = new Invoice();

            // 4. Apply each event on the entity.
            foreach (var @event in events)
            {
                invoice.Evolve(@event);
            }

        }
    }
}
