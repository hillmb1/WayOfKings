using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

//File that defines the ability to start a new game.

public class New_Game : MonoBehaviour {
	public GameObject input;
	public GameControl gameCntrl;
	public string scene;


	// Use this for initialization
	void Start () {
		//scene = "Dungeon";
	}

	// Update is called once per frame
	void Update () {
	
	}

	//New game function
	//Called by New Game button on main menu.
	public void NewGame(){

		// IF the PlayerData.dat exists.
		if (File.Exists (Application.persistentDataPath + "/PlayerData.dat")) {
			// Delete it.
			File.Delete (Application.persistentDataPath + "/PlayerData.dat");
		}

		//Keeps this camera from destroying the singleton version found inside game scenes.
		GameControl.control.charName = input.GetComponent<InputField>().textComponent.text;
		Destroy(GameObject.FindGameObjectWithTag("MainCamera"));

		UnityEngine.SceneManagement.SceneManager.LoadScene ("Spawn Town");

	}
}
