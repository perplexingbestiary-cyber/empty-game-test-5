using UnityEngine;

public class TableSlot : MonoBehaviour
{
    public GameObject currentItem;

    public void ClearSlot()
    {
        currentItem = null;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        Debug.Log("current item is null");
    }
}
