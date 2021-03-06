using UnityEngine;
using System.Collections;

public class InventoryInstance : MonoBehaviour {

	//This class is specifically to implement singleton on inventory.
	#region Singleton and Persistence
	static InventoryInstance s_instance;
	void Awake () {
		if (s_instance == null) {
			DontDestroyOnLoad (gameObject);
			s_instance = this;

		} else if (s_instance != this) {
			Destroy (gameObject);
		}
	}
	#endregion

	// Use this for initialization5
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
