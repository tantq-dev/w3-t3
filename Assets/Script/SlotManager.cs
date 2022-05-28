using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public int SlotCount;
    private GameObject prefab;
    private GameObject itemPrefab;
    public int itemCount = 10;
    List<Item> items = new List<Item>();
    private void Awake()
    {
        prefab = Resources.Load("Prefabs/Slot") as GameObject;
        itemPrefab = Resources.Load("Prefabs/Item") as GameObject;


    }
    void Start()
    {
        TextAsset itemdata = Resources.Load<TextAsset>("ItemData");
        string[] data = itemdata.text.Split(new char[] {'\n'});
        for (int i = 1; i < data.Length-1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            if (row[1] !="")
            {
                Item item = new Item();
                int.TryParse(row[0], out item.id);
                item.name = row[1];
                item.spriteName = row[2];
                int.TryParse(row[3], out item.quantity);
                item.type = row[4];
                items.Add(item);
            }
        }
        for (int i = 0; i < SlotCount; i++)
        {
            var newSlot = Instantiate(prefab,
            new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            newSlot.transform.parent = gameObject.transform;
            Debug.Log(items.Count);
            if (i < items.Count)
            {

               
                var newItem = Instantiate(itemPrefab,
                new Vector3(newSlot.transform.position.x, newSlot.transform.position.y, newSlot.transform.position.z), Quaternion.identity);
                newItem.transform.parent = gameObject.transform.GetChild(i).transform;
                newItem.GetComponent<ItemObject>().item=items[i];
              
            }
        }

    }

}
