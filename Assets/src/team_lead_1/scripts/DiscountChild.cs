public class DiscountChild : DiscountParent
{
    public DiscountChild(float discountAmount)
    {
        DiscountAmount = discountAmount;
    }

    public float apply_discount(float value)
    {
        return value - (DiscountAmount * value * 2);
    }
}