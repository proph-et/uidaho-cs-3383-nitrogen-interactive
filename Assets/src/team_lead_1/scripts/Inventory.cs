using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        if (item != null)
        {
            items.Add(item);
            Debug.Log("Added item: " + item.itemName);
        }
    }
}
