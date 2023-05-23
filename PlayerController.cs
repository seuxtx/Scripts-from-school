using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int theOne;
    public GameObject SomeObject;
    private void OnTriggerEnter(Collider col)
    {
        //when a collision occurs find out what you collided with and 
        // add interactable objects to the inventory list
        //show the name of the object you collided with
        Debug.Log("you collided with the " + col.gameObject.name);

        SomeObject = col.gameObject;

        //if this is an interactable object...
        //disable the mesh renderer to make the object disappear

        if (SomeObject.CompareTag("Interact"))
        {
            MeshRenderer theMesh = SomeObject.GetComponent<MeshRenderer>();
            theMesh.enabled = false;
            theOne = -1;
            findInDatabase();
            isItHere();
        }
    }

    private void findInDatabase() // find the object you collided with in the itemDatabase
    {
        for (int i = 0; i < GameControlScript.theItems.Count; i++)
        {
            // if the itemDatabase element matches the name of the object you collided with, store the index value
            Debug.Log("someObject.name = " + SomeObject.name);
            Debug.Log("compare to " + GameControlScript.theItems[i].itemName);
            if (GameControlScript.theItems[i].itemName == SomeObject.name)
            {
                theOne = i;
                break;
            }
        }
    }

    private void isItHere()
    {
        // make sure the item is added to inventory only once
        bool foundIt = false;

        //for loop to compare VALUES of the contents of the items in the lists
        // list.contains will NOT do this - it looks for objects not values
        foreach (Item x in GameControlScript.InventoryList)
        {
            if (x.itemName == SomeObject.name)
            {
                foundIt = true;
                break;
            }
        }
        if (!foundIt)
        {
            // the item is NOT in inventory so add it
            Debug.Log("the value of theOne = " + theOne);
            AddItemToInventory(GameControlScript.theItems[theOne]);
            showInPanel();
        }
    }

    private void AddItemToInventory(Item item)
    {
        //copy the Item into InventoryList
        Item newItem = new Item(item.itemName, item.itemId, item.itemDesc,
            item.itemUsable, item.itemUseWithId);
        newItem.itemIcon = Resources.Load<Texture2D>("SampleSprites/" +
            newItem.itemName);
        GameControlScript.InventoryList.Add(newItem);
    }

    private void showInPanel()
    {
        Texture2D tex;
        Sprite mySprite;
        string theName;
        int whichOne;
        whichOne = GameControlScript.InventoryList.Count;
        theName = "btnimage" + whichOne;
        GameObject anObject = GameObject.Find(theName);
        tex = GameControlScript.InventoryList[whichOne - 1].itemIcon;
        mySprite = Sprite.Create(tex, new Rect(0, 0, 32, 32), new Vector2(.5f, .5f));
        anObject.GetComponent<Image>().sprite = mySprite;
    }
}
