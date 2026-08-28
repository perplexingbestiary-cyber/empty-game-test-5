using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public ItemDictionary itemDictionary;

    public GameObject inventoryPanel;
    public GameObject tablePanel;

    public GameObject Slot;
    public GameObject TableSlot;

    public int slotCount;
    public int tableSlotCount;

    public static InventoryController Instance {get; private set;}

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public GameObject[] fishItemPrefabs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //itemDictionary = FindObjectOfType<ItemDictionary>();
        for(int i = 0; i < slotCount; i++)
        {
            ShopSlot slot = Instantiate(Slot, inventoryPanel.transform).GetComponent<ShopSlot>();

            if(i < fishItemPrefabs.Length)
            {
                GameObject item = Instantiate(fishItemPrefabs[i], slot.transform);

                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                slot.currentItem = item;
            }
        }
/*
        for(int i = 0; i < tableSlotCount; i++)
        {
            TableSlot tableSlot = Instantiate(TableSlot, tablePanel.transform).GetComponent<TableSlot>();

            if(i < fishItemPrefabs.Length)
            {
                GameObject tableItem = Instantiate(fishItemPrefabs[i], tableSlot.transform);

                tableItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                tableSlot.currentItem = tableItem;
            }

        }
        */
    }

    public bool AddItem(GameObject itemPrefab)
    {
        Item itemToAdd = itemPrefab.GetComponent<Item>();
        if (itemToAdd == null) return false;

        //checks to see if fish type already exists
        foreach(Transform slotTransform in inventoryPanel.transform)
        {
            ShopSlot slot = slotTransform.GetComponent<ShopSlot>();
            if (slot != null && slot.currentItem != null)
            {
                Item slotItem = slot.currentItem.GetComponent<Item>();
                if(slotItem != null && slotItem.ID == itemToAdd.ID)
                {
                    slotItem.AddToStack();
                    return true;
                }
            }
        }
       
        //looks for empty slot
        foreach(Transform slotTransform in inventoryPanel.transform)
        {
            ShopSlot slot = slotTransform.GetComponent<ShopSlot>();
            if (slot != null && slot.currentItem == null)
            {
                GameObject newItem = Instantiate(itemPrefab, slotTransform);
                newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.currentItem = newItem;
                return true;
            }
        }
        
        Debug.Log("inventory full");
        return false;
        
    }



}
