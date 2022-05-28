using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    public Item item;
    private Text text;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        text = transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
        image.overrideSprite = Resources.Load<Sprite>("Item Icons/"+item.spriteName );
       text.text = "" + item.quantity;

    }
}
