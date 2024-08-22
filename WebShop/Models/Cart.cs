namespace WebShop.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddOneItem(Product product,int quantity)
        {
            CartLine line = Lines.Where(p => p.Product.Id == product.Id).FirstOrDefault();

            if (line!=null)       // prod exists in cart already
            { 
                line.Quantity = line.Quantity + quantity;
            }
            else
            {
                var p = product;

                //var p = new Product
                //{
                //    Id = product.Id,
                //    Name = product.Name,
                //    Description = product.Description,
                //    Price = product.Price,
                //    IsDiscount = product.IsDiscount,
                //    DiscountPrice = product.DiscountPrice,
                //    ImageUrl = product.ImageUrl,
                //    QuantityInStore = product.QuantityInStore,
                //    CategoryId = product.CategoryId      
                //};

                var c = new CartLine() { Product = p, Quantity = quantity };
                Lines.Add(c);
            }
        }


        public void RemoveOneItem(Product prod)
        {
            CartLine line = Lines.Where(p => p.Product.Id == prod.Id).FirstOrDefault();
            if (line!=null)
            {
                if (line.Quantity == 1)
                {
                    RemoveLine(line);
                }
                else
                {
                    line.Quantity = line.Quantity - 1;
                }
            }
        }      

        // Removes complete line
        public void RemoveLine(CartLine line)
        {
            Lines.Remove(line);
        }

        // Removes complete line
        public void RemoveLineByProducts(Product prod)
        {
            Lines.RemoveAll(l => l.Product.Id == prod.Id);
        }


        public double CartTotValue()
        {
            double sum = 0;
            foreach (var l in Lines)
            {
                if (l.Product.IsDiscount)
                {
                    sum = sum + (double)l.Product.DiscountPrice*l.Quantity;
                }
                else
                {
                    sum = sum + (double)l.Product.Price*l.Quantity;
                }
            }
            return sum;
        }



        // Empties complete cart by removing all lines
        public void Clear()
        {
            Lines.Clear();
        }
    }

}
