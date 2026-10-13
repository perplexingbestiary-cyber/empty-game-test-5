using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class RequestController : MonoBehaviour
{
    //public int dayCount;
    //public TMP_Text Day;
    public int jamCount;
    public TMP_Text Jam;

    public JamAnimation jamAnimation;

    public float CurrentMoney;
    //public GameObject Money;
    public TMP_Text Money;
    
    public float purchaseAmount;
    public float fish1PurchaseAmount = 10;
    public float fish2PurchaseAmount = 12;
    public float fish3PurchaseAmount = 7;
    public float fish4PurchaseAmount = 15;
    public float fish5PurchaseAmount = 17;

    public float specLure = 0;

    public int jamPurchaseAmount;

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

    public TMP_Text fish1Text;
    public TMP_Text fish2Text;
    public TMP_Text fish3Text;
    public TMP_Text fish4Text;
    public TMP_Text fish5Text;

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

    public Button jamButton;

    public Button lineButton;
    public Button lineLengthButton;
    public Button crawfishTimeButton;
    public Button barrelTimeButton;
    public Button lineSpeedButton;
    public Button specLureButton;

    public Button skipCustomerButton;

    public Button installmentButton;
    public float installmentAmount;
    public TMP_Text InstallmentAmount;


    public Button endDayButton;

    public LureMovement lureMovement;
    public LineMovement lineMovement;
    public ObstacleSpawner obstacleSpawner;

    public GameObject BackgroundMiddle;
    public GameObject BackgroundTop;
    public GameObject CollectionMiddle;
    public GameObject UpgradeMiddle;
    public GameObject UpgradeMiddle1;
    public GameObject EndDayButton;
    public GameObject SkipCustomer;

    public int lineLength = 0;
    public int lineSpeed = 0;

    public TMP_Text speedLevel;
public TMP_Text lengthLevel;

public GameObject Lure1;
public GameObject Lure2;
public GameObject Lure3;
public GameObject SpecLure;




    public void Awake()
    {
        jamButton.onClick.AddListener(() =>
        {
            purchaseAmount = 10f;
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Select", gameObject);
            if(CurrentMoney >= purchaseAmount)
            {
                
                Purchase();
                jamCount += 1;
                Jam.GetComponent<TMP_Text>().text = "" + jamCount;

            }
        });
        fish1Button.onClick.AddListener(() =>
        {
            purchaseAmount = fish1PurchaseAmount;

            if(CurrentMoney >= fish1PurchaseAmount)
            {
                Purchase();
                fish1cost += 1f;
                fish1PurchaseAmount += 1f;
                fish1Text.GetComponent<TMP_Text>().text = "$" + fish1PurchaseAmount;

            }
        });
        fish2Button.onClick.AddListener(() =>
        {
            purchaseAmount = fish2PurchaseAmount;

            if(CurrentMoney >= fish2PurchaseAmount)
            {
                Purchase();
                fish2cost += 1f;
                fish2PurchaseAmount += 1f;
                fish2Text.GetComponent<TMP_Text>().text = "$" + fish2PurchaseAmount;

            }
        });
        fish3Button.onClick.AddListener(() =>
        {
            purchaseAmount = fish3PurchaseAmount;

            if(CurrentMoney >= fish3PurchaseAmount)
            {
                Purchase();
                fish3cost += 1f;
                fish3PurchaseAmount += 1f;
                fish3Text.GetComponent<TMP_Text>().text = "$" + fish3PurchaseAmount;

            }
        });
        fish4Button.onClick.AddListener(() =>
        {
           purchaseAmount = fish4PurchaseAmount;

            if(CurrentMoney >= fish4PurchaseAmount)
            {
                Purchase();
                fish4cost += 1f;
                fish4PurchaseAmount += 1f;
                fish4Text.GetComponent<TMP_Text>().text = "$" + fish4PurchaseAmount;

            }
        });
        fish5Button.onClick.AddListener(() =>
        {
            purchaseAmount = fish5PurchaseAmount;

            if(CurrentMoney >= fish5PurchaseAmount)
            {
                Purchase();
                fish5cost += 1f;
                fish5PurchaseAmount += 1f;
                fish5Text.GetComponent<TMP_Text>().text = "$" + fish5PurchaseAmount;

            }
        });
        lineButton.onClick.AddListener(() =>
        {
            purchaseAmount = 50f;
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Select", gameObject);
            if(lureMovement.line < 3)
            {
                
            
            if(CurrentMoney >= purchaseAmount)
            {
                
                Purchase();
       
        
                lureMovement.line += 1;
        if(lureMovement.line == 0)
        {
            Lure1.SetActive(false);
            Lure2.SetActive(false);
            Lure3.SetActive(false);
        }
        else if(lureMovement.line == 1)
        {
            Lure1.SetActive(true);
            Lure2.SetActive(false);
            Lure3.SetActive(false);
        }
        else if(lureMovement.line == 2)
        {
            Lure1.SetActive(true);
            Lure2.SetActive(true);
            Lure3.SetActive(false);
        }
        else if(lureMovement.line == 3)
        {
            Lure1.SetActive(true);
            Lure2.SetActive(true);
            Lure3.SetActive(true);
        }
            }

            }
        });
        lineLengthButton.onClick.AddListener(() =>
        {
            jamPurchaseAmount = 20;
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Select", gameObject);
            if(lineLength < 3)
            {
                /*
                if(CurrentMoney >= purchaseAmount)
                {
                    Purchase();
                    lureMovement.lineLength += 3;
                    lineLength += 1;
                } 
                */
                if(jamCount >= jamPurchaseAmount)
                {
                    JamPurchase();
                    lureMovement.lineLength += 3.5f;
                    lineLength += 1;
                    lengthLevel.text = "Lv." + (lineLength + 1);
                    

                }
            }
            
        });
        lineSpeedButton.onClick.AddListener(() =>
        {
            jamPurchaseAmount = 20;
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Select", gameObject);
            if(lineSpeed < 5)
            {
                /*
                if(CurrentMoney >= purchaseAmount)
                {
                    Purchase();
                    lureMovement.speed *= 1.1f;
                    lineMovement.speed *= 1.1f;
                    lineSpeed += 1;
                }
                */
                if(jamCount >= jamPurchaseAmount)
                {
                    JamPurchase();
                    lureMovement.speed *= 1.1f;
                    lineMovement.speed *= 1.1f;
                    lineSpeed += 1;
                    speedLevel.text = "Lv." + (lineSpeed + 1);
                }
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
        specLureButton.onClick.AddListener(() =>
        {
            jamPurchaseAmount = 100;
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Select", gameObject);
/*
            if(CurrentMoney >= purchaseAmount)
            {
                Purchase();
                lureMovement.specLure += 1;

            }
            */
            if(lureMovement.specLure < 1)
            {
                if(jamCount >= jamPurchaseAmount)
            {
                JamPurchase();
                
                lureMovement.specLure += 1;
                if(lureMovement.specLure == 1)
            {
                SpecLure.SetActive(true);
            }
            else
            {
                SpecLure.SetActive(false);
            }
                //specLure += 1;

            }
            }
             
        });
        /*
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
*/
            
    }

    public void Purchase()
    {
        CurrentMoney -= purchaseAmount;
        Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Purchase", gameObject);
    }
    public void JamPurchase()
    {
        jamCount -= jamPurchaseAmount;
        Jam.GetComponent<TMP_Text>().text = "" + jamCount;
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Purchase", gameObject);
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //dayCount = 1;
        //Day.GetComponent<TMP_Text>().text = "Day " + dayCount;
        jamCount = 0;
        Jam.GetComponent<TMP_Text>().text = "" + jamCount;

        //modify based off of save controller later
        installmentAmount = 5f;
        installmentAmount = Mathf.Ceil(installmentAmount * 100f) / 100f;

        fish1cost = 20f;
        fish2cost = 40f;
        fish3cost = 10f;
        fish4cost = 60f;
        fish5cost = 90f;

        tableSlotOne = 0;
        tableSlotThree = 0;
        tableSlotTwo = 0;
        tableSlotFour = 0;
        tableSlotFive = 0;
        
        CurrentMoney = 0;

        Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;

        fish1Text.GetComponent<TMP_Text>().text = "$" + fish1PurchaseAmount;
        fish2Text.GetComponent<TMP_Text>().text = "$" + fish2PurchaseAmount;
        fish3Text.GetComponent<TMP_Text>().text = "$" + fish3PurchaseAmount;
        fish4Text.GetComponent<TMP_Text>().text = "$" + fish4PurchaseAmount;
        fish5Text.GetComponent<TMP_Text>().text = "$" + fish5PurchaseAmount;
    }

    void Update()
    {
        /*
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
        */
        
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
    public void JamCaught()
    {
        jamCount += 1;
        Jam.GetComponent<TMP_Text>().text = "" + jamCount;
    }
    public void Fish1()
    {
        int jamChance = Random.Range(0, 10);
                if(jamChance == 1)
                {
                    jamAnimation.Jam();
                    jamCount += 1;
                    Jam.GetComponent<TMP_Text>().text = "" + jamCount;
                }
        CurrentMoney += fish1cost;
        Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;
    }
    public void Fish2()
    {
        int jamChance = Random.Range(0, 8);
                if(jamChance == 1)
                {
                    jamAnimation.Jam();
                    jamCount += 1;
                    Jam.GetComponent<TMP_Text>().text = "" + jamCount;
                }
        CurrentMoney += fish2cost;
        Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;
    }
    public void Fish3()
    {
        int jamChance = Random.Range(0, 9);
                if(jamChance == 1)
                {
                    jamAnimation.Jam();
                    jamCount += 1;
                    Jam.GetComponent<TMP_Text>().text = "" + jamCount;
                }
        CurrentMoney += fish3cost;
        Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;
    }
    public void Fish4()
    {
        int jamChance = Random.Range(0, 5);
                if(jamChance == 1)
                {
                    jamAnimation.Jam();
                    jamCount += 1;
                    Jam.GetComponent<TMP_Text>().text = "" + jamCount;
                }
        CurrentMoney += fish4cost;
        Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;
    }
    public void Fish5()
    {
        int jamChance = Random.Range(0, 3);
                if(jamChance == 1)
                {
                    jamAnimation.Jam();
                    jamCount += 1;
                    Jam.GetComponent<TMP_Text>().text = "" + jamCount;
                }
        CurrentMoney += fish5cost;
        Money.GetComponent<TMP_Text>().text = "$" + CurrentMoney;
    }
    public void FishJam()
    {
        jamAnimation.Jam();
    }
}
