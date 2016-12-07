using UnityEngine;
using System.Collections;
namespace CreativeSpore.RpgMapEditor
{
public class ControlStone : MonoBehaviour {

	public bool powered;
	public Sprite power;
	public Sprite nopower;
	public SpriteRenderer current;
	public GameObject target1;
	public GameObject target2;
	public GameObject target3;
	public GameObject target4;
	public GameObject target5;
	public GameObject target6;
	public bool main;
	public AutoTileMap MyAutoTileMap;
		public AutoTileMapData MyAutoTileMapData;
		public GameObject knight;
		public bool changed;




	// Use this for initialization
	void Start () {
		powered = false;
		changed = false;
		current = this.gameObject.transform.GetChild (0).GetComponent<SpriteRenderer>();
			if (!main)
				main = false;
							



	}

	void OnTriggerEnter(Collider other)
	{
			print ("words");
			powered = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (powered == false)
			current.sprite = nopower;
		else
			current.sprite = power;
		if (main == true && changed == false) {
				if (target1.GetComponent<ControlStone> ().powered == true &&
				   target2.GetComponent<ControlStone> ().powered == true &&
				   target3.GetComponent<ControlStone> ().powered == true &&
				   target4.GetComponent<ControlStone> ().powered == true &&
				   target5.GetComponent<ControlStone> ().powered == true &&
				   target6.GetComponent<ControlStone> ().powered == true) {
					powered = true;

					MyAutoTileMap.SetAutoTile (24, 31, 35, 0, true);
					MyAutoTileMap.SetAutoTile (24, 32, 35, 0, true);
					MyAutoTileMap.SetAutoTile (24, 30, 35, 0, true);
					Destroy (GameObject.FindGameObjectWithTag ("Knight"));
					knight = Instantiate (knight);
					knight.transform.position = new Vector3 (7.84f, -8.8f, -0.4f);
					changed = true;
					RpgMapEditor.RpgMapHelper.RemoveFogOfWar (transform.position, 25);
				}
				
		}
	}


	}}
