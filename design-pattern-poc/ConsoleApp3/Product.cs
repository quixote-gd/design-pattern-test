using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public abstract class Product 
    {
        public abstract int CreateProductForEvent(int eventId);
        public abstract void RemoveProductFromEvent(int productId);
        public abstract Product SaveProductState(Product p, int eventId);
    }
}
