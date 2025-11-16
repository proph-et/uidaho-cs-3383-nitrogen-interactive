public abstract class DiscountParent
{
    protected float DiscountAmount;

    // public abstract float apply_discount(float value);
    public float apply_discount(float value)
    {
    return value - (DiscountAmount * value);
    }
}