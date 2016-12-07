using UnityEngine;
using System.Collections;

public class MaintainHPbar : MonoBehaviour {

	//This class is specifically to implement singleton.
	#region Singleton and Persistence
	static MaintainHPbar s_instance;
	void Awake () {
		if (s_instance == null) {
			DontDestroyOnLoad (gameObject);
			s_instance = this;

		} else if (s_instance != this) {
			Destroy (gameObject);
		}
	}
	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
