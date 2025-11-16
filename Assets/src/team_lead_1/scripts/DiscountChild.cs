public class DiscountChild : DiscountParent
{
    public DiscountChild(float discountAmount)
    {
        DiscountAmount = discountAmount;
    }

    // public override float ApplyDiscount(float value)
    public float ApplyDiscount(float value)
    {
        return value - (DiscountAmount * value * 2);
    }
}