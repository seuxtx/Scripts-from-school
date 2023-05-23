using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    //this is a singleton class to manage persistence between scenes
    //static means the variable belongs to the class and not the instance so
    // only one instance of the variable will be created over scope
    //create the Singleton in this class 
    public static GameControlScript instance;

    //this is the list that holds inventory collected for the game
    public static List<Item> InventoryList = new List<Item>();

    // a list of items that have been used to solve puzzles
    public static List<Item> InventoryUsed = new List<Item>();

    // these are all the items in the game that are collectible
    public static List<Item> theItems = new List<Item>();

    public string filePath = "SampleSprites";
    public Sprite[] theSprites;
    public string msg = "The number of images loaded is ";

    //setup the Dictionary for the game
    public Dictionary<string, string> spriteDictionary = new Dictionary<string, string>();
    public TextAsset datafile;
    public string[] dataLines;
    public string[][] dataPairs;

    //this is needed for the map grid navigation
    // this is the 2D array of the room map
    /*public int[,] roomGridArray =
       {
            {2,5,3,0},
            {0,1,0,4 },
            {0,0,0,1 },
            {0,0,2,0 },
            {1,0,0,0 }       
        };
        
    //this is needed to solve the puzzles
    public string[][] roomNeedsArray = new string[][]
      {
        new string[0] {},
        new string[2] {"BlueBall", "RedBall"},
        new string[2] {"YellowBall", "PurpleBall"},
        new string[0] {},
        new string[0] {}
      };*/
    private void Awake()
    {
        if (instance == null)
        {
            //set this instance as the instance reference
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //load the sprites into the Sprite array using the Resources directory
        theSprites = Resources.LoadAll<Sprite>(filePath);
        msg += theSprites.Length;
        Debug.Log(msg + " = the length of the sprite array");

        //this adds to the ItemDatabase using the Item class Constructor we created in Item.cs
        theItems.Add(new Item("SkullRed", 0, "the Red Skull", true, 0));
        theItems.Add(new Item("SkullCyan", 1, "the Cyan Skull", true, 0));
        theItems.Add(new Item("SkullBlue", 2, "the Blue Skull", true, 0));
        theItems.Add(new Item("Skullpink",3, "The Pink Skull", true, 0));
 

        foreach (Item anItem in theItems)
        {
            anItem.itemIcon = Resources.Load<Texture2D>("SampleSprites/" + anItem.itemName);
        }

        Debug.Log("the number of items in theItems = " + theItems.Count);

        //load the Dictionary
        datafile = Resources.Load("DictionaryForSpritesFile") as TextAsset;
        dataLines = datafile.text.Split('\n');
        dataPairs = new string[dataLines.Length][];
        int lineNum = 0;

        foreach (string line in dataLines)
        {
            dataPairs[lineNum++] = line.Split(',');
            string[] aPart = line.Split(',');
            if (aPart[0] == "")
            {
                break;
            }
            else
            {
                spriteDictionary.Add(aPart[0], aPart[1]);
            }
        }
        //verify that the dictionary loaded correctly
        Debug.Log("entries in dictionary = " + spriteDictionary.Count);
        foreach (KeyValuePair<string, string> keyValue in spriteDictionary)
        {
            Debug.Log("the key = " + keyValue.Key + " the value = " + keyValue.Value);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("GameController was destroyed");
    }

}
