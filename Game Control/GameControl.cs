using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
	
	public float experience;
	public List<int> inv;
	public List<Item> invTemp;
	public List<Item> equipTemp;
	public List<int> equip;
	public int gold;
	private PlayerInventory pi;
	public String scene;
	public string charName;
	public float maxHP;
	public float maxMP;
	public float maxDmg;
	public float maxArm;

	public static GameControl control;
	public ItemDataBaseList itemDatabase;

	#region Singleton and Persistence
	void Awake () {


		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
	
		} else if (control != this) {
			Destroy (gameObject);
		}
	}
	#endregion

	public void start()
	{
		

	}


	// Update is called once per frame
	void Update () {
	
	}

	void OnEnabled()
	{
		
	}

	void OnDisabled()
	{
		
	}

	void loaded (Scene arg0, LoadSceneMode arg1)
	{
		
		itemDatabase = (ItemDataBaseList)Resources.Load("ItemDatabase");
		GameObject p = GameObject.FindGameObjectWithTag ("Player");
		pi = p.GetComponent<PlayerInventory> ();

		for (int i = 0; i < inv.Count; i++) {
			pi.inventory.SetActive (true);
			pi.inventory.GetComponent<Inventory> ().addItemToInventory (inv [i]);

			//pi.inventory.SetActive (false);
		}
		print (equip.Count);
		for (int i = 0; i < equip.Count; i++) {
			pi.characterSystem.SetActive (true);
			ItemType[] listp = pi.characterSystem.GetComponent<EquipmentSystem> ().itemTypeOfSlots;
			GameObject item = (GameObject)Instantiate(pi.inventory.GetComponent<Inventory>().getPrefab());
			item.GetComponent<ItemOnObject>().item = itemDatabase.getItemByID(equip[i]);
			print ("add");
			//for (int i2 = 0; i2 < pi.characterSystem.transform.GetChild (1).transform.childCount; i2++)
			//{
				//if (pi.characterSystem.transform.GetChild (1).transform.GetChild(i2).childCount == 0)
				//{
					
					for (int j = 0; j < listp.Length; j++) {
						if (listp [j] == item.GetComponent<ItemOnObject> ().item.itemType) {

							item.transform.SetParent (pi.characterSystem.transform.GetChild (1).transform.GetChild (j));
							item.GetComponent<RectTransform> ().localPosition = Vector3.zero;
							item.transform.GetChild (0).GetComponent<Image> ().sprite = item.GetComponent<ItemOnObject> ().item.itemIcon;
							item.GetComponent<ItemOnObject> ().item.indexItemInList = pi.characterSystem.GetComponent<Inventory> ().ItemsInInventory.Count - 1;
							break;
						}
					}
				//}
			//}

			//pi.characterSystem.SetActive (false);
		}
		Inventory pii = pi.characterSystem.GetComponent<Inventory> ();
		//for (int k = 0; k < pii.ItemsInInventory.Count; k++)
		//{
			for (int i = 0; i < pii.transform.childCount; i++)
			{
				if (pi.characterSystem.transform.GetChild(1).transform.GetChild(i).childCount != 0)
				{
				pi.characterSystem.transform.GetChild (1).transform.GetChild (i).GetChild (0).GetComponent<ConsumeItem> ().item = pi.characterSystem.transform.GetChild (1).transform.GetChild (i).GetChild (0).GetComponent<ItemOnObject> ().item;
					pi.characterSystem.transform.GetChild (1).transform.GetChild (i).GetChild(0).GetComponent<ConsumeItem> ().consumeIt();
				pi.OnGearItem (pi.characterSystem.transform.GetChild (1).transform.GetChild (i).GetChild (0).GetComponent<ConsumeItem> ().item);
					
					
				}
			}
		//}

		pi.maxHealth = maxHP;
		pi.maxMana = maxMP;
		pi.maxDamage = maxDmg;
		pi.maxArmor = maxArm;

	}

	//Method to save game data as a binary file to help
	//curb game save alteration
	public void Save()
	{	
		//Finds player object
		pi = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerInventory>();

		//Check if file exists
		if (File.Exists (Application.persistentDataPath + "/PlayerData.dat")) {
			// Delete it.
			File.Delete (Application.persistentDataPath + "/PlayerData.dat");
		}
			
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");

		inv = new List<int>();
		PlayersData data = new PlayersData ();
		invTemp = pi.inventory.GetComponent<Inventory>().ItemsInInventory;

		for (int i = 0; i < invTemp.Count; i++) {
			inv.Add( invTemp [i].itemID);
		}

		data.maxHP = pi.maxHealth;
		data.maxMP = pi.maxMana;
		data.maxDmg = pi.maxDamage;
		data.maxArm = pi.maxArmor;

		data.inv = inv;
		equipTemp = pi.characterSystem.GetComponent<Inventory>().ItemsInInventory;

		for (int i = 0; i < equipTemp.Count; i++) {
			equip.Add( equipTemp [i].itemID);
		}

		data.equip = equip;
		data.scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
		data.charName = charName;

		//int gold;

		bf.Serialize (file, data);
		file.Close ();
	}

	////Method to load game data from a binary file
	public void Load()
	{
		
		SceneManager.sceneLoaded += loaded;
		if (File.Exists (Application.persistentDataPath + "/PlayerData.dat")) {
			
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
			PlayersData data = (PlayersData)bf.Deserialize (file);

			scene = data.scene;
			charName = data.charName;
			inv = data.inv;
			equip = data.equip;
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
			maxHP = data.maxHP;
			maxMP = data.maxMP;
			maxDmg = data.maxDmg;
			maxArm = data.maxArm;

			//health = data.health;
			//experience = data.experience;

			file.Close ();


				

		}
	}
}



//Serializable PlayerData object that is written to binary file
[Serializable]
class PlayersData
{
	//public float experience;
	public string charName;
	public List<int> inv;
	public List<int> equip;
	public String scene;
	public float maxHP;
	public float maxMP;
	public float maxDmg;
	public float maxArm;
	//public int gold;



}
