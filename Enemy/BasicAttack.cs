using UnityEngine;
using System.Collections;
namespace CreativeSpore.RpgMapEditor
{
public class BasicAttack : MonoBehaviour {

	public float Speed = 0.1f;
	public Vector3 Dir = new Vector3();
	public float TimeToLive = 5f;
	public float DamageQty = 0.5f;

	public GameObject OnDestroyFx;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) 
	{
		if( other.attachedRigidbody && (other.gameObject.layer != gameObject.layer) )
		{
			//apply damage here
			//DamageData.ApplyDamage(other.attachedRigidbody.gameObject, DamageQty, Dir);
			Destroy(other.gameObject);
		}
	}
}
}