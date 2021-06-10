using System;

namespace MUSACA.Data
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public long Barcode { get; set; }

        public string Picture { get; set; }
    }
}
