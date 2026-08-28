using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class RequestController : MonoBehaviour
{
    public int dayCount;
    public TMP_Text Day;

    public float CurrentMoney;
    //public GameObject Money;
    public TMP_Text Money;
    public float purchaseAmount;

    public int tableSlotOne;
    public int tableSlotTwo;
    public int tableSlotThree;
    public int tableSlotFour;
    public int tableSlotFive;

    public float fish1cost;
    public float fish2cost;
    public float fish3cost;
    public float fish4cost;
    public float fish5cost;

    public int customer;

    public TableSlot tableSlot;
    public TableSlot tableSlot1;
    public TableSlot tableSlot2;
    public TableSlot tableSlot3;
    public TableSlot tableSlot4;
    public FishingDetector fishingDetector;

    public bool reset;
    public bool closed;
    public bool closingTime;

    public bool menuOpen;

    public bool endDayReady;
    public int maxCustomer;

    public Button fish1Button;
    public Button fish2Button;
    public Button fish3Button;
    public Button fish4Button;
    public Button fish5Button;

    public Button lineButton;
    public Button lineLengthButton;
    public Button crawfishTimeButton;
    public Button barrelTimeButton;

    public Button skipCustomerButton;

    public Button installmentButton;
    public float installmentAmount;
    public TMP_Text InstallmentAmount;


    public Button endDayButton;

    public LureMovement lureMovement;
    public ObstacleSpawner obstacleSpawner;

    public GameObject BackgroundMiddle;
    public GameObject BackgroundTop;
    public GameObject CollectionMiddle;
    public GameObject UpgradeMiddle;
    public GameObject UpgradeMiddle1;
    public GameObject EndDayButton;
    public GameObject SkipCustomer;



    public void Awake()
    {
        fish1Button.onClick.AddListener(() =>
        {
            purchaseAmount = 10f;

            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                fish1cost += 1f;

            }
        });
        fish2Button.onClick.AddListener(() =>
        {
            purchaseAmount = 12f;

            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                fish2cost += 1f;

            }
        });
        fish3Button.onClick.AddListener(() =>
        {
            purchaseAmount = 7f;

            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                fish3cost += 1f;

            }
        });
        fish4Button.onClick.AddListener(() =>
        {
            purchaseAmount = 15f;

            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                fish4cost += 1f;

            }
        });
        fish5Button.onClick.AddListener(() =>
        {
            purchaseAmount = 17f;

            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                fish5cost += 1f;

            }
        });
        lineButton.onClick.AddListener(() =>
        {
            purchaseAmount = 5f;

            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                lureMovement.line += 1;

            }
        });
        lineLengthButton.onClick.AddListener(() =>
        {
            purchaseAmount = 20f;

            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                lureMovement.lineLength += 3;

            }
        });
        barrelTimeButton.onClick.AddListener(() =>
        {
            purchaseAmount = 20f;

            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                obstacleSpawner.barrelSpawnTime += 2;

            }
        });
        crawfishTimeButton.onClick.AddListener(() =>
        {
            purchaseAmount = 20f;

            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                obstacleSpawner.crawfishSpawnTime += 1;

            }
        });
        installmentButton.onClick.AddListener(() =>
        {
            purchaseAmount = installmentAmount;

            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                BackgroundTop.SetActive(false);
                CollectionMiddle.SetActive(false);

                UpgradeMiddle.SetActive(true);
                UpgradeMiddle1.SetActive(true);  
                

                endDayReady = true;
            }
        });
        endDayButton.onClick.AddListener(() =>
        {

            //if()
            {  
                UpgradeMiddle.SetActive(false);
                UpgradeMiddle1.SetActive(false);
                BackgroundMiddle.SetActive(true);
                BackgroundTop.SetActive(true);


                closed = false;
                closingTime = false;
                customer = 0;
                endDayReady = false;

                dayCount += 1;
                installmentAmount *= 1.2f;

                installmentAmount = Mathf.Ceil(installmentAmount * 100f) / 100f;

                Day.GetComponent<TMP_Text>().text = "Day " + dayCount;

                fishingDetector.StartFishingTime();
                SkipCustomer.SetActive(true);
                
            }
        });

        skipCustomerButton.onClick.AddListener(() =>
        {

            reset = true;
            customer += 1;

            Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;
        });

            
    }

    public void Purchase()
    {
        CurrentMoney -= purchaseAmount;
        Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;
    } 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dayCount = 1;
        Day.GetComponent<TMP_Text>().text = "Day " + dayCount;

        //modify based off of save controller later
        installmentAmount = 5f;
        installmentAmount = Mathf.Ceil(installmentAmount * 100f) / 100f;

        fish1cost = 2f;
        fish2cost = 4f;
        fish3cost = 1f;
        fish4cost = 6f;
        fish5cost = 9f;

        tableSlotOne = 0;
        tableSlotThree = 0;
        tableSlotTwo = 0;
        tableSlotFour = 0;
        tableSlotFive = 0;
        
        CurrentMoney = 0;

        Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;
    }

    void Update()
    {
        
        if (menuOpen && EndDayButton.activeSelf || !endDayReady)
        {
            EndDayButton.SetActive(false);
        }
        else if(!menuOpen && !EndDayButton.activeSelf && endDayReady)
        {
            EndDayButton.SetActive(true);
            
        }

        if (reset)
        {
            if(customer < maxCustomer && !closingTime)
            {
            tableSlotOne = Random.Range(1, 6);
            tableSlotThree = Random.Range(0, 6);
            tableSlotTwo = Random.Range(0, 6);
            tableSlotFour = Random.Range(0, 6);
            tableSlotFive = Random.Range(0, 6); 

            tableSlot.ClearSlot();
            tableSlot1.ClearSlot();
            tableSlot2.ClearSlot();
            tableSlot3.ClearSlot();
            tableSlot4.ClearSlot();
            }
            else if(customer >= maxCustomer || closingTime)
            {
                fishingDetector.currentTime = 150f;
                tableSlot.ClearSlot();
                tableSlot1.ClearSlot();
                tableSlot2.ClearSlot();
                tableSlot3.ClearSlot();
                tableSlot4.ClearSlot();

                tableSlotOne = 0;
                tableSlotThree = 0;
                tableSlotTwo = 0;
                tableSlotFour = 0;
                tableSlotFive = 0; 

                closed = true;

                
                BackgroundMiddle.SetActive(false);
                CollectionMiddle.SetActive(true);
                SkipCustomer.SetActive(false);
                InstallmentAmount.GetComponent<TMP_Text>().text = "$" + installmentAmount;

                



            }
            
            reset = false;
        }

        if (!closed)
        {
            if(tableSlotOne == 0 && tableSlotThree == 0 && tableSlotTwo == 0 && tableSlotFour == 0 && tableSlotFive == 0)
        {
            reset = true;
            CurrentMoney += 2f;
            Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;
            customer += 1;
        }
        }
        
        
    }

    public void KillOne()
    {
        if (tableSlotOne == 1)
        {
            CurrentMoney += fish1cost;   
        }
        else if (tableSlotOne == 2)
        {
            CurrentMoney += fish2cost;   
        }
        else if (tableSlotOne == 3)
        {
            CurrentMoney += fish3cost;   
        }
        else if (tableSlotOne == 4)
        {
            CurrentMoney += fish4cost;   
        }
        else if (tableSlotOne == 5)
        {
            CurrentMoney += fish5cost;   
        }
        
        tableSlotOne = 0;
    }

    public void KillTwo()
    {
        if (tableSlotTwo == 1)
        {
            CurrentMoney += fish1cost;   
        }
        else if (tableSlotTwo == 2)
        {
            CurrentMoney += fish2cost;   
        }
        else if (tableSlotTwo == 3)
        {
            CurrentMoney += fish3cost;   
        }
        else if (tableSlotOne == 4)
        {
            CurrentMoney += fish4cost;   
        }
        else if (tableSlotOne == 5)
        {
            CurrentMoney += fish5cost;   
        }
        tableSlotTwo = 0;
    }
    public void KillThree()
    {
        if (tableSlotThree == 1)
        {
            CurrentMoney += fish1cost;   
        }
        else if (tableSlotThree == 2)
        {
            CurrentMoney += fish2cost;   
        }
        else if (tableSlotThree == 3)
        {
            CurrentMoney += fish3cost;   
        }
        else if (tableSlotOne == 4)
        {
            CurrentMoney += fish4cost;   
        }
        else if (tableSlotOne == 5)
        {
            CurrentMoney += fish5cost;   
        }
        tableSlotThree = 0;
    }
    public void KillFour()
    {
        if (tableSlotFour == 1)
        {
            CurrentMoney += fish1cost;   
        }
        else if (tableSlotFour == 2)
        {
            CurrentMoney += fish2cost;   
        }
        else if (tableSlotFour == 3)
        {
            CurrentMoney += fish3cost;   
        }
        else if (tableSlotOne == 4)
        {
            CurrentMoney += fish4cost;   
        }
        else if (tableSlotOne == 5)
        {
            CurrentMoney += fish5cost;   
        }
        tableSlotFour = 0;
    }
    public void KillFive()
    {
        if (tableSlotFive == 1)
        {
            CurrentMoney += fish1cost;   
        }
        else if (tableSlotFive == 2)
        {
            CurrentMoney += fish2cost;   
        }
        else if (tableSlotFive == 3)
        {
            CurrentMoney += fish3cost;   
        }
        else if (tableSlotOne == 4)
        {
            CurrentMoney += fish4cost;   
        }
        else if (tableSlotOne == 5)
        {
            CurrentMoney += fish5cost;   
        }
        tableSlotFive = 0;
    }

    public void ClosingTime()
    {
        closingTime = true;
        reset = true;
    }

    public void MenuOpen()
    {
        menuOpen = true;
    }

    public void MenuClosed()
    {
        menuOpen = false;
    }
}
