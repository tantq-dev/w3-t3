using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillItem : MonoBehaviour
{
    List<Item> items = new List<Item>();
    private void Start()
    {
        TextAsset itemdata = Resources.Load<TextAsset>("Item");
        string[] data = itemdata.text.Split(new char[] {'\n'});
        for (int i = 1; i < data.Length-1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            if (row[1] != "")
            {
                Item item = new Item();
                int.TryParse(row[0], out item.id);
                item.name = row[1];
     
                item.spriteName = row[2];
         
                int.TryParse (row[3], out item.quantity);
                items.Add(item);
            }
        }
        for (int i = 0; i < items.Count; i++)
        {
            var spriteName = items[i].spriteName;
            Debug.Log(spriteName);
            GameObject prefabs = Resources.Load("ItemHolder") as GameObject;
            var newItemHolder = Instantiate(prefabs,
               new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            newItemHolder.transform.parent = gameObject.transform;
            newItemHolder.transform.GetChild(0).GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Item Icons/" + spriteName);
        }

    } 
}
