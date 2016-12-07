
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float maxHp;
    public float baseHp;
	public float currentHp;
	// Use this for initialization
	void Start () {
		baseHp = 100f;
		maxHp = baseHp;
		currentHp = maxHp;
	}

	// Update is called once per frame
	void Update () {
		if (currentHp <= 0f) {
			gameObject.SetActive (false);
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

	void OnTriggerEnter(Collider other)
	{
		if (other.isTrigger != false) {
			print ("Attacked enemy");
			currentHp -= other.gameObject.GetComponent<PlayerInventory> ().currentDamage;
		} else if (other.isTrigger == false) {
			print ("Attacked by enemy");
			other.gameObject.GetComponent<PlayerInventory> ().currentHealth -= 10f;
		}
	}

}
