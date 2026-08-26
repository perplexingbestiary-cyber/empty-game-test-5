using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;
   // public RequestController requestController;

    private InventoryController inventoryController;
        void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        inventoryController = InventoryController.Instance;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        ShopSlot dropSlot = eventData.pointerEnter?.GetComponent<ShopSlot>();
      
        ShopSlot originalSlot = originalParent.GetComponent<ShopSlot>();
        TableSlot tableOriginalSlot = originalParent.GetComponent<TableSlot>();

        TableSlot tableDropSlot = eventData.pointerEnter?.GetComponent<TableSlot>();


       /*
        if(dropSlot == null)
        {
            GameObject dropItem = eventData.pointerEnter;
            if(dropItem != null)
            {
                dropSlot = dropItem.GetComponentInParent<ShopSlot>();
            }
            transform.SetParent(originalParent);
        }
*/
        //if ended drag ontop of a slot
        if(dropSlot != null)
        {
            //if there is an item already in a slot
            if(dropSlot.currentItem != null)
            {
                //dropSlot.currentItem.transform.SetParent(originalSlot.transform);
                //originalSlot.currentItem = dropSlot.currentItem;
                //dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                transform.SetParent(originalParent);
                GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }

            else
            {
                transform.SetParent(dropSlot.transform);
                dropSlot.currentItem = gameObject;
                GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                //originalSlot.currentItem = null;
                Item item = GetComponent<Item>();
                int quantity = item.quantity;

                if(quantity > 1)
                {
                    item.RemoveFromStack();

                    transform.SetParent(originalParent);
                    //transform.SetParent(dropSlot.transform);
                    //GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    GameObject newItem = item.CloneItem(1);

                    newItem.transform.SetParent(dropSlot.transform);

                    //dropSlot.currentItem = newItem;
                    GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                    rectTransform.localScale = new Vector3(1f, 1f, 1f);

                    //if(inventoryController == null || newItem == null) return;

                    //foreach(Transform slotTransform in inventoryController.inventoryPanel.transform)
                    //{
                     //   ShopSlot slot = slotTransform.GetComponent<ShopSlot>();
                     //   if(slot != null && slot.currentItem == null)
                     //   {
                     //       slot.currentItem = newItem;
                     //       newItem.transform.SetParent(dropSlot.transform);
                    //        newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    //        return;
                    //    }
                  //  }

                    //item.AddToStack(1);
                    //Destroy(newItem);
                    
                   // quantity = 1;
                }
                else
                {
                    if(originalSlot != null)
                    {
                        originalSlot.currentItem = null;
                    }
                    GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                }

            }
            
        }
        else
        {
            transform.SetParent(originalParent);
            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }


        if(tableDropSlot != null)
        {
            
            //if there is an item already in a slot
            
            if(tableDropSlot.currentItem != null)
            {
                transform.SetParent(originalParent);
                GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }

            else
            {
                Item item = GetComponent<Item>();
                RequestController requestController = GameObject.Find("Controllers").GetComponent<RequestController>();

                int quantity = item.quantity;

                if(item.ID == requestController.tableSlotOne)
                {
                    transform.SetParent(tableDropSlot.transform);
                    tableDropSlot.currentItem = gameObject;
                    GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                        if(quantity > 1)
                        {
                            item.RemoveFromStack();

                            transform.SetParent(originalParent);

                            GameObject newItem = item.CloneItem(1);

                            newItem.transform.SetParent(tableDropSlot.transform);
                    
                            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                            //item will not scale to 2x; happens occasionally but with no apparent consistency: Aug 25
                            rectTransform.localScale = new Vector3(2f, 2f, 2f);
                            newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    
                            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        }
                        else
                        {
                            if(originalSlot != null)
                            {
                                originalSlot.currentItem = null;
                            }

                            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        }
                requestController.KillOne();
                canvasGroup.enabled = false;
                //Debug.Log("kill one");
                return;
                }
                else if(item.ID == requestController.tableSlotTwo)
                {
                    transform.SetParent(tableDropSlot.transform);
                    tableDropSlot.currentItem = gameObject;
                    GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                        if(quantity > 1)
                        {
                            item.RemoveFromStack();

                            transform.SetParent(originalParent);

                            GameObject newItem = item.CloneItem(1);

                            newItem.transform.SetParent(tableDropSlot.transform);
                    
                            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                            
                            newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    
                            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                            rectTransform.localScale = new Vector3(2f, 2f, 2f);
                        }
                        else
                        {
                            if(originalSlot != null)
                            {
                                originalSlot.currentItem = null;
                            }

                            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        }
                requestController.KillTwo();
                canvasGroup.enabled = false;
                return;

                }                
                else if(item.ID == requestController.tableSlotThree)
                {
                    transform.SetParent(tableDropSlot.transform);
                    tableDropSlot.currentItem = gameObject;
                    GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                        if(quantity > 1)
                        {
                            item.RemoveFromStack();

                            transform.SetParent(originalParent);

                            GameObject newItem = item.CloneItem(1);

                            newItem.transform.SetParent(tableDropSlot.transform);
                    
                            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                            
                            newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    
                            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                            rectTransform.localScale = new Vector3(2f, 2f, 2f);
                        }
                        else
                        {
                            if(originalSlot != null)
                            {
                                originalSlot.currentItem = null;
                            }

                            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        }
                requestController.KillThree();
                canvasGroup.enabled = false;
                return;

                }  
                else if(item.ID == requestController.tableSlotFour)
                {
                    transform.SetParent(tableDropSlot.transform);
                    tableDropSlot.currentItem = gameObject;
                    GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                        if(quantity > 1)
                        {
                            item.RemoveFromStack();

                            transform.SetParent(originalParent);

                            GameObject newItem = item.CloneItem(1);

                            newItem.transform.SetParent(tableDropSlot.transform);
                    
                            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                            
                            newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    
                            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                            rectTransform.localScale = new Vector3(2f, 2f, 2f);
                        }
                        else
                        {
                            if(originalSlot != null)
                            {
                                originalSlot.currentItem = null;
                            }

                            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        }
                requestController.KillFour();
                canvasGroup.enabled = false;
                return;

                }  
                else if(item.ID == requestController.tableSlotFive)
                {
                    transform.SetParent(tableDropSlot.transform);
                    tableDropSlot.currentItem = gameObject;
                    GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                        if(quantity > 1)
                        {
                            item.RemoveFromStack();

                            transform.SetParent(originalParent);

                            GameObject newItem = item.CloneItem(1);

                            newItem.transform.SetParent(tableDropSlot.transform);
                    
                            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                            rectTransform.localScale = new Vector3(2f, 2f, 2f);
                            
                            newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    
                            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                            
                        }
                        else
                        {
                            if(originalSlot != null)
                            {
                                originalSlot.currentItem = null;
                            }

                            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        }
                requestController.KillFive();
                canvasGroup.enabled = false;
                return;

                }  
            }
        }
    }



}
