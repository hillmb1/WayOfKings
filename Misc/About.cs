using UnityEngine;
using System.Collections;

public class About : MonoBehaviour {
	public GUISkin skinn;
	private bool showingDialogue;
	// Use this for initialization
	void Start () {
		showingDialogue = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void about()
	{
		
		showingDialogue = !showingDialogue ;
	}
	void OnGUI()
	{
		GUI.skin = skinn;
		GUI.depth = 0;
		if(showingDialogue)
		{
			
			GUI.Box (new Rect(10, Screen.height - 130, Screen.width - 20, 120),"Way of Kings" + "/n" + "Matthew Hill" + "/n" + "2016" , "Dialogue");
			}
	}
}
