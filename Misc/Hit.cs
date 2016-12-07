using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerStay(Collider other)
	{
		print ("wtf");
	}
	void onTriggerEnter(Collider other)
	{
		print ("wtf");
	}
	void onTriggerExit(Collider other)
	{
		print ("wtf");
	}
}
