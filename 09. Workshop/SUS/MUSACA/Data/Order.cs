using MUSACA.Data.Enums;
using System;

namespace MUSACA.Data
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public Status Status { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public string UserId { get; set; }

        public virtual User Cashier { get; set; }

        public string ReceiptId { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
