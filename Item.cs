using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemId;
    public string itemDesc;
    public Texture2D itemIcon;
    public bool itemUsable;
    public int itemUseWithId;

    public Item(string name,int id, string desc, bool useable, int useWithId)
    {
        itemName = name;
        itemId = id;
        itemDesc = desc;
        itemIcon = Resources.Load<Texture2D>("SampleSprites" + name);
        itemUsable = useable;
        itemUseWithId = useWithId;
    }
}
