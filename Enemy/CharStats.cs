using UnityEngine;
using System.Collections;

public class CharStats : MonoBehaviour {
	public int maxHp;
	public int baseHp = 10;
	public int currentHp;
	// Use this for initialization
	void Start () {
		maxHp = baseHp;
		currentHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHp <= 0) {
//			gameObject.SetActive (false);
		}
	
	}

	public void takeDamage(int damage)
	{
		currentHp -= damage;
	}

	public void retoreMaxHp()
	{
		currentHp = maxHp;
	}

	public void restoreHp(int health)
	{
		currentHp += health;
	}


}
