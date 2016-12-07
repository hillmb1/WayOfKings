using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace CreativeSpore.RpgMapEditor
{
    public class NPCDialogue : MonoBehaviour
    {

        
            

            private GameObject m_player;
            


		private bool showingDialogue;



		private string dialogueMessage;
		public List<Dialogue> dialogueMessages = new List<Dialogue>();

		public GUISkin skinn;
		public int index;



            // Use this for initialization
            void Start()
            {
                m_player = GameObject.FindGameObjectWithTag("Player");
			index = 0;
                
                

            }

		void Update () 
		{
			if (showingDialogue) {
				if (Input.GetKeyDown (KeyCode.Return)) {
					index++;
					index = index % dialogueMessages.Count;
					GenerateDialogue ();
				}
			}
		}

		void OnGUI()
		{
			GUI.skin = skinn;
			GUI.depth = 0;
			if(showingDialogue)
			{
				GUI.Box (new Rect(10, Screen.height - 130, Screen.width - 20, 120), dialogueMessage, "Dialogue");
				GUI.Box (new Rect(Screen.width/2-50,Screen.height-50,100,50 ), new Dialogue().dialogue = "Press Enter", "Dialogue2");
			}
		}

		void OnTriggerEnter(Collider col)
		{
			if(col.GetComponent<PlayerTileMovementController>() != null && showingDialogue == false)
			{
				GenerateDialogue();
				showingDialogue = true;
			}
		}

		public void GenerateDialogue()
		{
			
			dialogueMessage = dialogueMessages[index].dialogue;
		}

		void OnTriggerExit(Collider col)
		{
			if(col.GetComponent<PlayerTileMovementController>() != null)
			{
				showingDialogue = false;
			}
		}
	}

	[System.Serializable]
	public class Dialogue
	{
		public string dialogue;
	}
}