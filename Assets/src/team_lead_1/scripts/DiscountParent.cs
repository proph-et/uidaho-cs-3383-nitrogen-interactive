public abstract class DiscountParent
{
    protected int DiscountAmount;

    // public virtual int ApplyDiscount(int value)
    public int ApplyDiscount(int value)
    {
        return (int)(value - DiscountAmount * (value / 100.0f));
    }
}