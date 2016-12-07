using UnityEngine;
using System.Collections;


namespace CreativeSpore.RpgMapEditor
{
	//Method that is used to alter tiles onm map based on a "switch"
	[RequireComponent(typeof(BoxCollider))]
	public class OpenClose : MonoBehaviour
	{

		public KeyCode ActivationKey = KeyCode.Return;

		BoxCollider m_boxCollider;

		public bool changed;

		public AutoTileMap MyAutoTileMap;

		void Start()
		{
			Reset();
			changed = false;

		}

		void Reset()
		{
			m_boxCollider = GetComponent<BoxCollider>();
			m_boxCollider.isTrigger = true;
		}

		void Update()
		{
			
		}

		IEnumerator wait()
		{
			yield return new WaitForSeconds (1);
			changed = false;

		}

		void OnTriggerStay(Collider other)
		{
			PlayerController player = other.GetComponent<PlayerController>();
			if (player != null && Input.GetKey (ActivationKey)  && !changed)
			{
				//print (MyAutoTileMap.GetAutoTile (22, 19, 0).Id);
				if (MyAutoTileMap.GetAutoTile (20, 19, 0).Id == 163) {
					MyAutoTileMap.SetAutoTile (20, 19, 94, 0, true);
					MyAutoTileMap.SetAutoTile (20, 18, 94, 0, true);
					MyAutoTileMap.SetAutoTile (19, 19, 94, 0, true);
					MyAutoTileMap.SetAutoTile (19, 18, 94, 0, true);
					MyAutoTileMap.SetAutoTile (21, 19, 94, 0, true);
					MyAutoTileMap.SetAutoTile (21, 18, 94, 0, true);
				} else {
					MyAutoTileMap.SetAutoTile (20, 19, 163, 0, true);
					MyAutoTileMap.SetAutoTile (20, 18, 163, 0, true);
					MyAutoTileMap.SetAutoTile (19, 19, 163, 0, true);
					MyAutoTileMap.SetAutoTile (19, 18, 163, 0, true);
					MyAutoTileMap.SetAutoTile (21, 19, 163, 0, true);
					MyAutoTileMap.SetAutoTile (21, 18, 163, 0, true);
				}


				changed = true;
				StartCoroutine(wait ());


			}
		}


	}
}
