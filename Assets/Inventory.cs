using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> ItemsInInventory = new List<Item>();
    [SerializeField]
    private GameObject SlotContainer;// Start is called before the first frame update
    void Start()
    {
        
    }
   public void OnUpdateItemList()
    {
        updateItemList();
    }
    private void updateItemList()
    {
        ItemsInInventory.Clear();
        for (int i = 0; i < SlotContainer.transform.childCount; i++)
        {
            Transform trans = SlotContainer.transform.GetChild(i);
            if (trans.childCount != 0)
            {
                ItemsInInventory.Add(trans.GetChild(0).GetComponent<ItemObject>().item);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
