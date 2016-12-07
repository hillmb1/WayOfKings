using UnityEngine;
using System.Collections;

//Deprecated weapon class.

namespace CreativeSpore.RpgMapEditor{
public class WeapDetails : MonoBehaviour {

	public DirectionalAnimation EquipSprite;
	public Sprite EquipSpriteRight;
	public Sprite EquipSpriteLeft;
	public Sprite EquipSpriteUp;
	public Sprite EquipSpriteDown;
	public int id;
	public DirectionalAnimation m_baseAnimCtrl;
	public Vector3[] vOffDirRight = new Vector3[3];
	public Vector3[] vOffDirDown = new Vector3[3];
	public Vector3[] vOffDirLeft = new Vector3[3]; 
	public Vector3[] vOffDirUp = new Vector3[3];

	// Use this for initialization
	void Start () {
			
		m_baseAnimCtrl = transform.parent.gameObject.GetComponent<DirectionalAnimation> ();
		EquipSprite = GetComponent<DirectionalAnimation> ();
	}
	
	// Update is called once per frame
	void Update () {
			

		if (m_baseAnimCtrl.AnimDirection == eAnimDir.Right) {
			EquipSprite.SetAnimDirection(Vector2.right);

			//qRot.eulerAngles = new Vector3 (0f, 0f, 0f);

			} else if (m_baseAnimCtrl.AnimDirection == eAnimDir.Left) 
			{
				EquipSprite.SetAnimDirection(Vector2.left);

			} else if (m_baseAnimCtrl.AnimDirection == eAnimDir.Down)
			{
				EquipSprite.SetAnimDirection(Vector2.down);

			} else { // UP
				EquipSprite.SetAnimDirection(Vector2.up);

			}
		
		
	
	}
}
}