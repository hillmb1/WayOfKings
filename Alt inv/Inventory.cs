using UnityEngine;
using System.Collections;

public class Inventory2 : MonoBehaviour {
	IdvInventory inventory;
	// Use this for initialization
	void Start () {
		inventory = new IdvInventory ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addItem(GameObject addItem)
	{
		inventory.inv[inventory.itemCount] = addItem;
		inventory.itemCount++;
	}

	public void setInventory(GameObject[] inventory)
	{
		this.inventory.inv = inventory;
	}
	public GameObject[] getInventory()
	{
		return this.inventory.inv;
	}

}

	

	[System.Serializable]
	public class IdvInventory
	{
		public GameObject[] inv;
		public int itemCount;

		public IdvInventory()
		{
			inv = new GameObject[25];
			itemCount = 0;
		}

}
