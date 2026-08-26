using UnityEngine;

public class RequestController : MonoBehaviour
{
    public int tableSlotOne;
    public int tableSlotTwo;
    public int tableSlotThree;
    public int tableSlotFour;
    public int tableSlotFive;

    public TableSlot tableSlot;
    public TableSlot tableSlot1;
    public TableSlot tableSlot2;
    public TableSlot tableSlot3;
    public TableSlot tableSlot4;

    public bool reset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tableSlotOne = 0;
        tableSlotThree = 0;
        tableSlotTwo = 0;
        tableSlotFour = 0;
        tableSlotFive = 0;
    }

    void Update()
    {
        if (reset)
        {
            tableSlotOne = Random.Range(1, 3);
            tableSlotThree = Random.Range(1, 3);
            tableSlotTwo = Random.Range(1, 3);
            tableSlotFour = Random.Range(1, 3);
            tableSlotFive = Random.Range(1, 3);

            tableSlot.ClearSlot();
        tableSlot1.ClearSlot();
        tableSlot2.ClearSlot();
        tableSlot3.ClearSlot();
        tableSlot4.ClearSlot();
            
            reset = false;
        }

        if(tableSlotOne == 0 && tableSlotThree == 0 && tableSlotTwo == 0 && tableSlotFour == 0 && tableSlotFive == 0)
        {
            reset = true;
        }
        
    }

    public void KillOne()
    {
        tableSlotOne = 0;
    }

    public void KillTwo()
    {
        tableSlotTwo = 0;
    }
    public void KillThree()
    {
        tableSlotThree = 0;
    }
    public void KillFour()
    {
        tableSlotFour = 0;
    }
    public void KillFive()
    {
        tableSlotFive = 0;
    }
}
