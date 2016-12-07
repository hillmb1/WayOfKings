using UnityEngine;
using System.Collections;
namespace CreativeSpore.RpgMapEditor{
public class EnemyAttack : MonoBehaviour {
	public int baseDamage = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void Attack()
//	{
//
//
//			switch (GetComponent<DirectionalAnimation>().AnimDirection)
//		{
//		case eAnimDir.Up:
//
//
//			Vector3 temp = transform.localPosition;
//
//
//			WeaponSprite.transform.localPosition = temp;
//
//			weapCollid.size = new Vector3(0.32f, 0.32f, 1f);
//
//			weapCollid.center= new Vector3(0f, 0.32f, 0f);
//			weapCollid.isTrigger = true;
//
//
//			break;
//		case eAnimDir.Down:
//
//			weapAnim.IsPlaying = true;
//			weapCollid.size = new Vector3(0.32f, 0.32f, 1f);
//
//			weapCollid.center = new Vector3(0f, -0.32f, 0f);
//			weapCollid.isTrigger = true;
//			break;
//		case eAnimDir.Left: 
//			weapAnim.SetAnimDirection(new Vector2(1f, 0f));
//
//			weapAnim.IsPlaying = true;
//			Vector3 temp2 = WeaponSprite.transform.localPosition;
//
//			WeaponSprite.transform.localPosition = temp2;
//
//			weapCollid.size = new Vector3 (0.32f, 0.32f, 1f);
//
//			weapCollid.center = new Vector3 (-0.32f, 0f, 0f);
//			weapCollid.isTrigger = true;
//
//			break;
//		case eAnimDir.Right:
//			weapAnim.SetAnimDirection(new Vector2(-1f, 0f));
//
//			weapAnim.IsPlaying = true;
//			weapCollid.size = new Vector3(0.32f, 0.32f, 1f);
//
//			weapCollid.center = new Vector3(0.32f, 0f, 0f);
//			weapCollid.isTrigger = true;
//			break;
//		}
//	}
	void OnTriggerStay(Collider other) 
	{
//		if( other.attachedRigidbody && (other.gameObject.layer != gameObject.layer) && other.gameObject.CompareTag("Player"))
//		{
//			other.gameObject.GetComponent<CharStats> ().takeDamage (baseDamage);
//		}
	}


}
}