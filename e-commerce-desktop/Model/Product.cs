using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_desktop.Model
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Publishers { get; set; }
        public int CategoryId { get; set; }
        public string CreationDate { get; set; }
        public string Description { get; set; }
    }
}