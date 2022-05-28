using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item 
{
    public int id;
    public string name;
    public string spriteName;
    public int quantity;
    private Text quantityTxt;
    private Image itemImg;
    [SerializeField] public string type;
    [SerializeField] public int slotIndex;
    public Item() { }

}
