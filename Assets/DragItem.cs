using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    private Vector2 pointerOffset;
    private RectTransform rectTransform;
    private RectTransform rectTransformSlot;
    private CanvasGroup canvasGroup;
    private GameObject oldSlot;
    private Transform draggedItemBox;
    Inventory inventory;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransformSlot = GameObject.FindGameObjectWithTag("DraggingItem").GetComponent<RectTransform>();
        draggedItemBox = GameObject.FindGameObjectWithTag("DraggingItem").transform;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (rectTransform == null)
            return;
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Drag");
            rectTransform.SetAsLastSibling();
            transform.SetParent(draggedItemBox);
            Vector2 localPointerPosition;
            canvasGroup.blocksRaycasts = false;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransformSlot, Input.mousePosition, eventData.pressEventCamera, out localPointerPosition))
            {
                rectTransform.localPosition = localPointerPosition - pointerOffset;
            }
        }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out pointerOffset);
            oldSlot = transform.parent.gameObject;
        }

    }

    public void OnEndDrag(PointerEventData data)
    {

        if (data.button == PointerEventData.InputButton.Left)
        {
            canvasGroup.blocksRaycasts = true;
            Transform newSlot = null;
            if (data.pointerEnter != null)
                newSlot = data.pointerEnter.transform;
            if (newSlot != null)
            {
                GameObject firstItemGameObject = this.gameObject;
                GameObject secondItemGameObject = newSlot.parent.gameObject;
                RectTransform firstItemRectTransform = this.gameObject.GetComponent<RectTransform>();
                RectTransform secondItemRectTransform = newSlot.parent.GetComponent<RectTransform>();
                Item firstItem = rectTransform.GetComponent<ItemObject>().item;
                Item secondItem = new Item();
                if (newSlot.parent.GetComponent<ItemObject>() != null)
                    secondItem = newSlot.parent.GetComponent<ItemObject>().item;
                int newSlotChildCount = newSlot.transform.parent.childCount;
                bool isOnSlot = newSlot.transform.parent.GetChild(0).tag == "ItemIcon";
                if (newSlotChildCount != 0 && isOnSlot)
                {
                    firstItemGameObject.transform.SetParent(secondItemGameObject.transform.parent);
                    secondItemGameObject.transform.SetParent(oldSlot.transform);
                    secondItemRectTransform.localPosition = Vector3.zero;
                    firstItemRectTransform.localPosition = Vector3.zero;
                }
                else
                {
                    if (newSlot.tag != "Slot" && newSlot.tag != "ItemIcon")
                    {
                        firstItemGameObject.transform.SetParent(oldSlot.transform);
                        firstItemRectTransform.localPosition = Vector3.zero;
                    }
                    else
                    {
                        firstItemGameObject.transform.SetParent(newSlot.transform);
                        firstItemRectTransform.localPosition = Vector3.zero;
                    }
                }

            }
        }
    }
}
