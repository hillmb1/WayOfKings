using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace CreativeSpore.RpgMapEditor
{
public class Equipment : MonoBehaviour {
		public Dictionary<string, GameObject> hashT;
	public idvEquip equipManager;
		public Inventory charinv;
	public Vector3 player;
	public DirectionalAnimation weapAnim;
	public DirectionalAnimation m_animCtrl;
	public Sprite idolPos;
	public Vector3 IdleRight = new Vector3 (0.02f, 0f, -0.5f);
	public Vector3[] vOffDirRight = new Vector3[3];


	public Vector3[] vOffDirDown = new Vector3[3];
	public Vector3[] vOffDirLeft = new Vector3[3]; 


	public Vector3[] vOffDirUp = new Vector3[3];


	public SpriteRenderer WeaponSprite;
	public Sprite WeaponSpriteRight;
	public Sprite WeaponSpriteLeft;
	public Sprite WeaponSpriteUp;
	public Sprite WeaponSpriteDown;
		public string animName;

	private DirectionalAnimation m_charAnimCtrl;
		private PhysicCharBehaviour phy;

		public string typeOfE;
	// Use this for initialization
	void Start () {
			//charinv = this.GetComponent<Inventory> ();
			equipManager = new idvEquip ();
		m_charAnimCtrl = GetComponent<DirectionalAnimation>();
			hashT = new Dictionary<string, GameObject>();
			phy = GetComponent<PhysicCharBehaviour> ();
			hashT.Add ("Helm", equipManager.helm);
			hashT.Add ("Chest", equipManager.chest);
			hashT.Add ("Legs", equipManager.legs);
			hashT.Add ("Weapon", equipManager.weapon);
			hashT.Add ("Shield", equipManager.shield);
			hashT.Add ("Necklace", equipManager.necklace);
			hashT.Add ("Ring", equipManager.ring);
			animName = "Blank char";


	}
	
	// Update is called once per frame
	void Update () {
			EquipmentSystem eSys = GetComponent<PlayerInventory> ().characterSystem.GetComponent<EquipmentSystem>();
			ItemType[] itemTypeOfSlot = eSys.itemTypeOfSlots;
			string newanimName = "";
			for (int i = 0; i < eSys.slotsInTotal; i++) {
				
//				if (itemTypeOfSlot [i].Equals (ItemType.Head) && eSys.transform.GetChild (1).GetChild (i).childCount != 0) {
//					
//					if (GameObject.FindGameObjectWithTag ("Helm") == null) {
//						Instantiate (eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.equipModel, gameObject.transform);
//						GameObject helm = GameObject.FindGameObjectWithTag ("Helm");
//						helm.transform.position = helm.transform.parent.position;
//						helm.transform.localPosition = new Vector3 (0.0099f, 0.101f, -0.0001f);
//						helm.GetComponent<DirectionalAnimation> ().SetAnimDirection (m_charAnimCtrl.GetAnimDirection ());
//						helm.SetActive (true);
//
//					} else if (GameObject.FindGameObjectWithTag ("Helm") != null && GameObject.FindGameObjectWithTag ("Helm").GetComponent<WeapDetails> ().id != eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemID) {
//						Destroy (GameObject.FindGameObjectWithTag ("Helm"));
//						Instantiate (eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.equipModel, gameObject.transform);
//						GameObject helm = GameObject.FindGameObjectWithTag ("Helm");
//						helm.transform.position = helm.transform.parent.position;
//						helm.transform.localPosition = new Vector3 (0.0099f, 0.101f, -0.0001f);
//						helm.GetComponent<DirectionalAnimation> ().SetAnimDirection (m_charAnimCtrl.GetAnimDirection ());
//						helm.SetActive (true);
//					
//
//					} 
//				}
//				else if (itemTypeOfSlot [i].Equals (ItemType.Head) && eSys.transform.GetChild (1).GetChild (i).childCount == 0){
//						if (GameObject.FindGameObjectWithTag ("Helm") != null)
//							{
//							Destroy (GameObject.FindGameObjectWithTag ("Helm"));
//
//						}
//					}
				if (itemTypeOfSlot [i].Equals (ItemType.Head) && eSys.transform.GetChild (1).GetChild (i).childCount != 0) {
					if (newanimName == "") {
						newanimName = eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemName;
					} else {
						newanimName = eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemName;
					}

						
				}else if (itemTypeOfSlot [i].Equals (ItemType.Chest) && eSys.transform.GetChild (1).GetChild (i).childCount != 0) {
					if (newanimName == "") {
						newanimName = eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemName;
					} else {
						newanimName += " " + eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemName;
					}


				}

				else if (itemTypeOfSlot [i].Equals (ItemType.Weapon) && eSys.transform.GetChild (1).GetChild (i).childCount != 0) {
					if (newanimName == "") {
						newanimName = eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemName;
					} else {
						newanimName += " " + eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemName;
					}

				}
				else if (itemTypeOfSlot [i].Equals (ItemType.Hands) && eSys.transform.GetChild (1).GetChild (i).childCount != 0) {
					if (newanimName == "") {
						newanimName = eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemName;
					} else {
						newanimName += " " + eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemName;
					}

				}
				else if (itemTypeOfSlot [i].Equals (ItemType.Trouser) && eSys.transform.GetChild (1).GetChild (i).childCount != 0) {
					if (newanimName == "") {
						newanimName = eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemName;
					} else {
						newanimName += " " + eSys.transform.GetChild (1).GetChild (i).GetChild (0).gameObject.GetComponent<ItemOnObject> ().item.itemName;
					}

				}
			}

			if (newanimName == "") {
				newanimName = "Blank char";
			}

			if (newanimName != animName) {
				animName = newanimName;

				DirectionalAnimation[] list = GetComponents<DirectionalAnimation> ();
				for (int i = 0; i < list.Length; i++) {
					list [i].SetAnim (animName);
				}
			}
		
		


//			if (GameObject.FindGameObjectWithTag ("Chest") == null && equipManager.chest != null) {
//				Instantiate (equipManager.chest.gameObject, gameObject.transform);
//				GameObject chest = GameObject.FindGameObjectWithTag ("Chest");
//				chest.transform.position = chest.transform.parent.position;
//				chest.transform.localPosition = new Vector3 (0f,  0.062f,0f);
//				chest.GetComponent<DirectionalAnimation> ().SetAnimDirection (m_charAnimCtrl.GetAnimDirection());
//				chest.SetActive (true);
//			}
//			if (GameObject.FindGameObjectWithTag ("Legs") == null && equipManager.legs != null) {
//				Instantiate (equipManager.legs.gameObject, gameObject.transform);
//				GameObject legs = GameObject.FindGameObjectWithTag ("Legs");
//				legs.transform.position = legs.transform.parent.position;
//				legs.transform.localPosition = new Vector3 (-0.0699f,  -0.0702f,0f);
//				legs.GetComponent<DirectionalAnimation> ().SetAnimDirection (m_charAnimCtrl.GetAnimDirection());
//				legs.SetActive (true);
//			}
//			if (GameObject.FindGameObjectWithTag ("Weapon") == null && equipManager.weapon != null) {
//				Instantiate (equipManager.weapon.gameObject, gameObject.transform);
//				GameObject weapon = GameObject.FindGameObjectWithTag ("Weapon");
//				weapon.transform.position = weapon.transform.parent.position;
//				weapon.GetComponent<DirectionalAnimation> ().SetAnimDirection (m_charAnimCtrl.GetAnimDirection());
//				weapon.SetActive (true);
//			}
//			if (GameObject.FindGameObjectWithTag ("Shield") == null && equipManager.shield != null) {
//				Instantiate (equipManager.shield.gameObject, gameObject.transform);
//				GameObject shield = GameObject.FindGameObjectWithTag ("Shield");
//				shield.transform.position = shield.transform.parent.position;
//				shield.GetComponent<DirectionalAnimation> ().SetAnimDirection (m_charAnimCtrl.GetAnimDirection());
//
//				shield.SetActive (true);
//			}



		
	}


		public void animateEquip()
		{
			if (GameObject.FindGameObjectWithTag ("Helm") != null) {
				GameObject helm = GameObject.FindGameObjectWithTag ("Helm");
				helm.GetComponent<DirectionalAnimation> ().IsPlaying = true;
				typeOfE = "helm";

			}
			if (GameObject.FindGameObjectWithTag ("Chest") != null && equipManager.chest != null) {
				GameObject chest = GameObject.FindGameObjectWithTag ("Chest");
				chest.GetComponent<DirectionalAnimation> ().IsPlaying = true;
				typeOfE = "chest";
			}
			if (GameObject.FindGameObjectWithTag ("Legs") != null && equipManager.legs != null) {
				GameObject legs = GameObject.FindGameObjectWithTag ("Legs");
				legs.GetComponent<DirectionalAnimation> ().IsPlaying = true;
				typeOfE = "legs";
			}
			if (GameObject.FindGameObjectWithTag ("Weapon") != null) {
				GameObject weap = GameObject.FindGameObjectWithTag ("Weapon");
				weap.GetComponent<DirectionalAnimation> ().IsPlaying = true;
				typeOfE = "weap";

			}

		}

		public void endAnimateEquip()
		{
			if (GameObject.FindGameObjectWithTag ("Helm") != null) {
				GameObject helm = GameObject.FindGameObjectWithTag ("Helm");
				helm.GetComponent<DirectionalAnimation> ().IsPlaying = false;

			}
			if (GameObject.FindGameObjectWithTag ("Chest") != null) {
				GameObject chest = GameObject.FindGameObjectWithTag ("Chest");
				chest.GetComponent<DirectionalAnimation> ().IsPlaying = false;
			}
			if (GameObject.FindGameObjectWithTag ("Legs") != null) {
				GameObject legs = GameObject.FindGameObjectWithTag ("Legs");
				legs.GetComponent<DirectionalAnimation> ().IsPlaying = false;
			}
			if (GameObject.FindGameObjectWithTag ("Weapon") != null) {
				GameObject weap = GameObject.FindGameObjectWithTag ("Weapon");
				weap.GetComponent<DirectionalAnimation> ().IsPlaying = false;
			}
		}

		public void setAnimateEquip(Vector3 dir)
		{
			if (GameObject.FindGameObjectWithTag ("Helm") != null ) {
				GameObject helm = GameObject.FindGameObjectWithTag ("Helm");
				helm.GetComponent<DirectionalAnimation> ().SetAnimDirection (dir);

			}
			if (GameObject.FindGameObjectWithTag ("Chest") != null) {
				GameObject chest = GameObject.FindGameObjectWithTag ("Chest");
				chest.GetComponent<DirectionalAnimation> ().SetAnimDirection (dir);

			}
			if (GameObject.FindGameObjectWithTag ("Legs") != null) {
				GameObject legs = GameObject.FindGameObjectWithTag ("Legs");
				legs.GetComponent<DirectionalAnimation> ().SetAnimDirection (dir);

			}
			if (GameObject.FindGameObjectWithTag ("Weapon") != null) {
				GameObject weap = GameObject.FindGameObjectWithTag ("Weapon");
				weap.GetComponent<DirectionalAnimation> ().SetAnimDirection (dir);

			}
		}




		public void equipItem(GameObject item)
		{ 
			GameObject temp;
			hashT.TryGetValue (item.tag, out temp);
			if (temp != null) {
				
				//charinv.addItem (temp);
				hashT.Remove(item.tag);
				hashT.Add (item.tag, item);
			}
				
			
		}

		public void checkInv()
		{
			GameObject temp;
			if (equipManager.helm != hashT.TryGetValue ("Helm", out temp)) {
				
			}
			
		}
}

	[System.Serializable]
	public class idvEquip
	{
		public GameObject helm;
		public GameObject chest;
		public GameObject legs;
		public GameObject weapon;
		public GameObject shield;
		public GameObject necklace;
		public GameObject ring;


	}
}