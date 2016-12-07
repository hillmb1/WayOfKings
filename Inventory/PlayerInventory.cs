using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInventory : MonoBehaviour
{
	public GameControl control;
    public GameObject inventory;
    public GameObject characterSystem;
    public GameObject craftSystem;
	public GameObject menu;
    private Inventory craftSystemInventory;
    private CraftSystem cS;
    private Inventory mainInventory;
    private Inventory characterSystemInventory;
    private Tooltip toolTip;
	public bool death;

    private InputManager inputManagerDatabase;

    public GameObject HPMANACanvas;
	public bool done;

    Text hpText;
    Text manaText;
    Image hpImage;
    Image manaImage;


    public float maxHealth = 100;
    public float maxMana = 100;
    public float maxDamage = 10;
    public float maxArmor = 0;

    public float currentHealth = 100;
	public float currentMana = 100;
	public float currentDamage = 10;
	public float currentArmor = 0;

    
    public void OnEnable()
    {
		print ("Enables Item");
        Inventory.ItemEquip += OnBackpack;
        Inventory.UnEquipItem += UnEquipBackpack;

        Inventory.ItemEquip += OnGearItem;
        Inventory.ItemConsumed += OnConsumeItem;
        Inventory.UnEquipItem += OnUnEquipItem;

        Inventory.ItemEquip += EquipWeapon;
        Inventory.UnEquipItem += UnEquipWeapon;
    }

    public void OnDisable()
    {
        Inventory.ItemEquip -= OnBackpack;
        Inventory.UnEquipItem -= UnEquipBackpack;

        Inventory.ItemEquip -= OnGearItem;
        Inventory.ItemConsumed -= OnConsumeItem;
        Inventory.UnEquipItem -= OnUnEquipItem;

        Inventory.UnEquipItem -= UnEquipWeapon;
        Inventory.ItemEquip -= EquipWeapon;
    }

    void EquipWeapon(Item item)
    {
//		print ("Weapon 1");
//        if (item.itemType == ItemType.Weapon)
//        {
//			print ("weapon 2");
//			for (int i = 0; i < item.itemAttributes.Count; i++) {
//				if (item.itemAttributes [i].attributeName == "Health")
//					maxHealth += item.itemAttributes [i].attributeValue;
//				if (item.itemAttributes [i].attributeName == "Mana")
//					maxMana += item.itemAttributes [i].attributeValue;
//				if (item.itemAttributes [i].attributeName == "Armor")
//					maxArmor += item.itemAttributes [i].attributeValue;
//				if (item.itemAttributes [i].attributeName == "Damage") {
//					maxDamage += item.itemAttributes [i].attributeValue;
//
//					print ("wtf");
//					print (maxDamage);
//				}
//			}
//			if (HPMANACanvas != null)
//			{
//				UpdateManaBar();
//				UpdateHPBar();
//			}
//        }
    }

    void UnEquipWeapon(Item item)
    {
//        if (item.itemType == ItemType.Weapon)
//        {
//			for (int i = 0; i < item.itemAttributes.Count; i++)
//			{
//				if (item.itemAttributes[i].attributeName == "Health")
//					maxHealth -= item.itemAttributes[i].attributeValue;
//				if (item.itemAttributes[i].attributeName == "Mana")
//					maxMana -= item.itemAttributes[i].attributeValue;
//				if (item.itemAttributes[i].attributeName == "Armor")
//					maxArmor -= item.itemAttributes[i].attributeValue;
//				if (item.itemAttributes[i].attributeName == "Damage")
//					maxDamage -= item.itemAttributes[i].attributeValue;
//			}
//			if (HPMANACanvas != null)
//			{
//				UpdateManaBar();
//				UpdateHPBar();
//			}
//        }
    }

    void OnBackpack(Item item)
    {
        
    }

    void UnEquipBackpack(Item item)
    {
        
    }

    

    void dropTheRestItems(int size)
    {
        
    }

    void Start()
	{
		death = false;
		done = false;
		GameObject canvas = GameObject.FindGameObjectWithTag ("Canvas");
		menu = canvas.transform.GetChild(8).gameObject;

		control =  GameObject.FindGameObjectWithTag ("Control").GetComponent<GameControl>();	

		if (HPMANACanvas != null) {
			HPMANACanvas.transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = control.charName;
			hpText = HPMANACanvas.transform.GetChild (2).GetChild (0).GetComponent<Text> ();

			manaText = HPMANACanvas.transform.GetChild (3).GetChild (0).GetComponent<Text> ();

			hpImage = HPMANACanvas.transform.GetChild (2).GetComponent<Image> ();
			manaImage = HPMANACanvas.transform.GetChild (3).GetComponent<Image> ();

			UpdateHPBar ();
			UpdateManaBar ();
		} else {
			HPMANACanvas = GameObject.FindGameObjectWithTag ("Hpmp");
			HPMANACanvas.transform.GetChild (1).GetChild (0).GetComponent<Text> ().text = control.charName;
		}

        
            inputManagerDatabase = (InputManager)Resources.Load("InputManager");

		craftSystem = canvas.transform.GetChild(4).gameObject;
            cS = craftSystem.GetComponent<CraftSystem>();


        
		toolTip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
		inventory = canvas.transform.GetChild(0).gameObject;
		mainInventory = inventory.GetComponent<Inventory>();
		characterSystem = canvas.transform.GetChild(3).gameObject;
		characterSystemInventory = characterSystem.GetComponent<Inventory>();
        if (craftSystem != null)
            craftSystemInventory = craftSystem.GetComponent<Inventory>();



			


    }

    void UpdateHPBar()
    {
        hpText.text = (currentHealth + "/" + maxHealth);
        float fillAmount = currentHealth / maxHealth;
        hpImage.fillAmount = fillAmount;
    }

    void UpdateManaBar()
    {
        manaText.text = (currentMana + "/" + maxMana);
        float fillAmount = currentMana / maxMana;
        manaImage.fillAmount = fillAmount;
    }


    public void OnConsumeItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
            {
                if ((currentHealth + item.itemAttributes[i].attributeValue) > maxHealth)
                    currentHealth = maxHealth;
                else
                    currentHealth += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Mana")
            {
                if ((currentMana + item.itemAttributes[i].attributeValue) > maxMana)
                    currentMana = maxMana;
                else
                    currentMana += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Armor")
            {
                if ((currentArmor + item.itemAttributes[i].attributeValue) > maxArmor)
                    currentArmor = maxArmor;
                else
                    currentArmor += item.itemAttributes[i].attributeValue;
            }
            if (item.itemAttributes[i].attributeName == "Damage")
            {
                if ((currentDamage + item.itemAttributes[i].attributeValue) > maxDamage)
                    currentDamage = maxDamage;
                else
                    currentDamage += item.itemAttributes[i].attributeValue;
            }
        }
        if (HPMANACanvas != null)
        {
        UpdateManaBar();
            UpdateHPBar();
        }
    }

    public void OnGearItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
                maxHealth += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Mana")
                maxMana += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Armor")
                maxArmor += item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Damage")
                maxDamage += item.itemAttributes[i].attributeValue;
        }
        if (HPMANACanvas != null)
        {
            UpdateManaBar();
            UpdateHPBar();
        }
    }

    public void OnUnEquipItem(Item item)
    {
        for (int i = 0; i < item.itemAttributes.Count; i++)
        {
            if (item.itemAttributes[i].attributeName == "Health")
                maxHealth -= item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Mana")
                maxMana -= item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Armor")
                maxArmor -= item.itemAttributes[i].attributeValue;
            if (item.itemAttributes[i].attributeName == "Damage")
                maxDamage -= item.itemAttributes[i].attributeValue;
        }
        if (HPMANACanvas != null)
        {
            UpdateManaBar();
            UpdateHPBar();
       }
    }

	void OnGUI()
	{
		if (death)
			GUI.Box (new Rect(10, Screen.height - 130, Screen.width - 20, 120), "You Died", "");

	}


    // Update is called once per frame
    void Update()
    {
		UpdateHPBar ();
		UpdateManaBar ();

		if (currentHealth <= 0) {
			death = true;
			this.transform.gameObject.SetActive (false);
			Destroy(GameObject.FindGameObjectWithTag ("MainCamera"));
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync ("Spawn Town");
			
		}
		if (done == false) {
			menu.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (() => {control.Save();});
			done = true;
		}
			currentDamage = maxDamage;

        if (Input.GetKeyDown(inputManagerDatabase.CharacterSystemKeyCode))
        {
            if (!characterSystem.activeSelf)
            {
				print ("open");
                characterSystemInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                characterSystemInventory.closeInventory();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.InventoryKeyCode))
        {
            if (!inventory.activeSelf)
            {
                mainInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                mainInventory.closeInventory();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.CraftSystemKeyCode))
        {
            if (!craftSystem.activeSelf)
                craftSystemInventory.openInventory();
            else
            {
                if (cS != null)
                    cS.backToInventory();
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                craftSystemInventory.closeInventory();
            }
        }

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!menu.activeSelf)
				menu.SetActive(true);
			else
			{
				menu.SetActive (false);
			}
		}

    }

}
