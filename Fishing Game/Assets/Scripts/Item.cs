using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string Name;
    public int quantity = 1;

    public TextMeshProUGUI quantityText;

    public GameObject prefab;

    private void Awake()
    {
        //quantityText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateQuantityDisplay();
    }

    public void UpdateQuantityDisplay()
    {
        if(quantityText != null)
        {
        quantityText.text = quantity > 1 ? quantity.ToString() : "";
            
        }
    }

    public void AddToStack(int amount = 1)
    {
        quantity += amount;
        UpdateQuantityDisplay();
    }

    public int RemoveFromStack(int amount = 1)
    {
        int removed = Mathf.Min(amount, quantity);
        quantity -= removed;
        UpdateQuantityDisplay();
        return removed;
        
    }

    public GameObject CloneItem(int newQuantity)
    {
        GameObject clone = Instantiate(prefab);
        Item cloneItem = clone.GetComponent<Item>();

        //RectTransform rectTransform = cloneItem.GetComponent<RectTransform>();
        //rectTransform.localScale = new Vector3(2f, 2f, 2f);

        cloneItem.quantity = newQuantity;
        cloneItem.UpdateQuantityDisplay();
        return clone;
    }

    public virtual void UseItem()
    {
        
    }

    public virtual void PickUp()
    {
        Sprite itemIcon = GetComponent<Image>().sprite;
        //if(ItemPickupUIController.Instance != null)
        {
           // ItemPickupUIController.Instance.ShowItemPickup(Name, itemIcon);
        }

    }

}
