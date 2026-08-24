using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject Slot;
    public int slotCount;

    public GameObject[] fishItemPrefabs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
    }


}
