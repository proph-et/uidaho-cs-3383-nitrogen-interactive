public class DiscountChild : DiscountParent
{
    public DiscountChild(int discountAmount)
    {
        DiscountAmount = discountAmount;
    }

    // public override int ApplyDiscount(int value)
        public int ApplyDiscount(int value)
    {
        int discountedAmount = value - DiscountAmount;
        if (discountedAmount >= 0) return discountedAmount;
        return 0;
    }
}