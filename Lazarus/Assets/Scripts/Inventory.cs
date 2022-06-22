using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Inventory
{
    private Dictionary<Item,int> _items;

    public Dictionary<Item, int> Items { get => _items; }

    public Inventory(Dictionary<Item,int> items)
    {
        _items = items;
    }

    public Item UseItem(string name)
    {
        foreach(Item item in Items.Keys)
        {
           if(item.Name==name)
           {
                Items[item]--;
                return item;
           }
        }
        return null;
    }
    public void AddItem(Item item)
    {
        if(ContainsItem(item))
        {
            Items[GetItemWithSameName(item)]++;
        }
        else
        {
            Items.Add(item, 1);
        }
    }


    private Item GetItemWithSameName(Item item)
    {
        foreach(Item currItem in Items.Keys)
        {
            if(currItem.Name==item.Name)
            {
                return currItem;
            }
        }
        return null;
    }
    private bool ContainsItem(Item item)
    {
        foreach(Item currItem in Items.Keys)
        {
            if(currItem.Name==item.Name)
            {
                return true;
            }
        }
        return false;
    }

    public static ItemType GetItemType(string type)
    {
        //ich weiﬂ das ich switch benutzen kann aber switch geht iwi nicht darum ja
        if (type == ItemType.Attack.ToString())
        {
            return ItemType.Attack;
        }
        if (type == ItemType.Crit.ToString())
        {
            return ItemType.Crit;
        }
        return ItemType.Health;

    }
   
}
