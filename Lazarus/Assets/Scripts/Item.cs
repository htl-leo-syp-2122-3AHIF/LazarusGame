using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public enum ItemType
{
    Attack,
    Crit,
    Health

    
}
[System.Serializable]
public class Item 
{

    
    private string _name;
    private ItemType _type;
    private float _amount;

    public Item(string name, ItemType type, float amount)
    {
        Name = name;
        Type = type;
        Amount = amount;
    }

    public string Name { get => _name; set => _name = value; }
    public ItemType Type { get => _type; set => _type = value; }
    public float Amount { get => _amount; set => _amount = value; }

    public override bool Equals(object obj)
    {
        return this.Name == ((Item)obj).Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
