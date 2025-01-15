
using EventAnnotator;
using Ex3_Invoicing.Model;
using static Ex3_Invoicing.Model.Invoice;

namespace Ex3_Invoicing.Events
{
    public class InvoiceEvents
    {
        [CommandMetadata(
            domain: "Invoicing",
            name: "InvoiceInitiated",
            description: "The InvoiceInitiated command . ",
            version: "1.0",
            summary: "This command is used by the inventory management system to ",
            owners: new[] { "admin@example.com" },
            address: "https://api.example.com/invoice",
            protocols: new[] { "HTTP", "HTTPS" },
            environments: new[] { "Production", "Staging" },
            channelOverview: "Invoicing channel"
        )]
        public record InvoiceInitiated(
            string Number, 
            double Amount,
            Person Customer,
            DateTime InitiatedAt
        );

        public record InvoiceIssued(
            string IssuedBy,
            DateTime IssuedAt
        );


        public record InvoiceSent(
            InvoiceSendMethod SentVia,
            DateTime SentAt
        );
    }
}
