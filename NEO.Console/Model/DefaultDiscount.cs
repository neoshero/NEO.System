using NEO.Console.Interface;

namespace NEO.Console.Model
{
    public class DefaultDiscount : IDiscount
    {
        public decimal DiscountSize { get; set; }

        public decimal ApplyDiscount(decimal amount)
        {
            return amount * (DiscountSize / 10);
        }
    }
}
