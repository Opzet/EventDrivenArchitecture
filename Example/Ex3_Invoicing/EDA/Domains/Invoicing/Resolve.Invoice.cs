
using static Ex3_Invoicing.Events.Invoice;
using static Ex3_Invoicing.Model.Invoice;

namespace Ex3_Invoicing.Resolve
{
    public class Invoice
    {
        //Aggregrate Root
        Model.Invoice invoice = new Model.Invoice();
        // Resolve
        public void Evolve(object @event)
        {
            switch (@event)
            {
                case InvoiceInitiated invoiceInitiated:
                    Apply(invoiceInitiated);
                    break;
                case InvoiceIssued invoiceIssued:
                    Apply(invoiceIssued);
                    break;
                case InvoiceSent invoiceSent:
                    Apply(invoiceSent);
                    break;
            }
        }

        private void Apply(InvoiceInitiated @event)
        {
            invoice.Id = @event.Number;
            invoice.Amount = @event.Amount;
            invoice.Number = @event.Number;
            invoice.IssuedTo = @event.IssuedTo;
            invoice.InitiatedAt = @event.InitiatedAt;
            invoice.Status = InvoiceStatus.Initiated;
        }

        private void Apply(InvoiceIssued @event)
        {
            invoice.IssuedBy = @event.IssuedBy;
            invoice.IssuedAt = @event.IssuedAt;
            invoice.Status = InvoiceStatus.Issued;
        }

        private void Apply(InvoiceSent @event)
        {
            invoice.SentVia = @event.SentVia;
            invoice.SentAt = @event.SentAt;
            invoice.Status = InvoiceStatus.Sent;
        }
    }
}