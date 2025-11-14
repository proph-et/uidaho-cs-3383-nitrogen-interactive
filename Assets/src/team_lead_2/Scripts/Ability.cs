using UnityEngine;

public abstract class Ability
{
   public virtual void Activate(GameObject user)
    {
        Debug.Log($"{user.name} used a generic ability.");
    }
}
