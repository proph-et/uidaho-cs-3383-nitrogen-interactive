public abstract class DiscountParent
{
    protected float DiscountAmount;

    // public virtual float ApplyDiscount(float value)
    public float ApplyDiscount(float value)
    {
        return value - (DiscountAmount * value);
    }
}