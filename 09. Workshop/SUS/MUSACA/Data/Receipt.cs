using System;
using System.Collections.Generic;

namespace MUSACA.Data
{
    public class Receipt
    {
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string UserId { get; set; }

        public User Cashier { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
