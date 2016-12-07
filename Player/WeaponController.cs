using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace CreativeSpore.RpgMapEditor
{
    [AddComponentMenu("RpgMapEditor/Controllers/WeaponController", 10)]
	public class WeaponController : MonoBehaviour {
		
		public bool Attacking;
		public bool firstAbilityUsed = false;
		public GameObject obj1;
		public GameObject obj2;
		public GameObject obj3;
		public GameObject Abilityprefab;
		public Vector3 player;
		public DirectionalAnimation weapAnim;
		public DirectionalAnimation m_animCtrl;
		public Sprite idolPos;
		public Vector3 IdleRight = new Vector3 (0.02f, 0f, -0.5f);
		public Vector3[] vOffDirRight = new Vector3[3];


		public Vector3[] vOffDirDown = new Vector3[3];
		public Vector3[] vOffDirLeft = new Vector3[3]; 


		public Vector3[] vOffDirUp = new Vector3[3];


		public SpriteRenderer WeaponSprite;

		public Sprite WeaponSpriteRight;
		public Sprite WeaponSpriteLeft;
		public Sprite WeaponSpriteUp;
		public Sprite WeaponSpriteDown;
		public GameObject weapon;


		// Use this for initialization
		void Start () 
		{
			Attacking = false;
			m_animCtrl =transform.parent.gameObject.GetComponent<DirectionalAnimation> ();

			weapAnim = GetComponent<DirectionalAnimation>();
			weapAnim.AnimSpeed = 7;
			weapAnim.IsPlaying = false;
			WeaponSprite = GetComponentInChildren<SpriteRenderer> ();
			weapAnim.OnAnimationLoopOver += returnToIdle;

		}
		
		// Update is called once per frame
		void Update ()
		{
			weapAnim.AnimDirection = m_animCtrl.AnimDirection;
			if(Attacking == false){
				Quaternion qRot = WeaponSprite.transform.localRotation;

				if (weapAnim.AnimDirection == eAnimDir.Right) {

					WeaponSprite.sprite = WeaponSpriteRight;
					idolPos = WeaponSpriteRight;
					Vector3 vOff = vOffDirRight [(int)m_animCtrl.CurrentFrame % vOffDirRight.Length];
					WeaponSprite.transform.localPosition = vOff;

				} else if (weapAnim.AnimDirection == eAnimDir.Left) 
					{
					WeaponSprite.sprite = WeaponSpriteLeft;
					Vector3 vOff = vOffDirLeft [(int)m_animCtrl.CurrentFrame % vOffDirLeft.Length];
					idolPos = WeaponSpriteLeft;
					WeaponSprite.transform.localPosition = vOff;

				} else if (weapAnim.AnimDirection == eAnimDir.Down)
					{
					WeaponSprite.sprite = WeaponSpriteDown;
					idolPos = WeaponSpriteDown;
					Vector3 vOff = vOffDirDown [(int)m_animCtrl.CurrentFrame % vOffDirDown.Length];

					WeaponSprite.transform.localPosition = vOff;

				} else { // UP
					WeaponSprite.sprite = WeaponSpriteUp;
					idolPos = WeaponSpriteUp;
					Vector3 vOff = vOffDirUp [(int)m_animCtrl.CurrentFrame % vOffDirDown.Length];
					WeaponSprite.transform.localPosition = vOff;

				}
			
		}

			if( Input.GetKey(KeyCode.Space) && !firstAbilityUsed  && Attacking == false) 
		{
				weapon = GameObject.FindGameObjectWithTag ("Weapon");
				BoxCollider weapCollid;
				Attacking = true;



			
				if (weapon.GetComponent<BoxCollider> () == null) {
					weapon.AddComponent<BoxCollider> ();
				}
				weapCollid = weapon.GetComponent<BoxCollider> ();
				switch (weapAnim.AnimDirection)
				{
				case eAnimDir.Up:
					weapAnim.IsPlaying = true;

					Vector3 temp = WeaponSprite.transform.localPosition;


					WeaponSprite.transform.localPosition = temp;

					weapCollid.size = new Vector3(0.32f, 0.32f, 1f);

					weapCollid.center= new Vector3(0f, 0.32f, 0f);
					weapCollid.isTrigger = true;


					break;
				case eAnimDir.Down:

					weapAnim.IsPlaying = true;
					weapCollid.size = new Vector3(0.32f, 0.32f, 1f);

					weapCollid.center = new Vector3(0f, -0.32f, 0f);
					weapCollid.isTrigger = true;
					break;
				case eAnimDir.Left: 
					weapAnim.SetAnimDirection(new Vector2(1f, 0f));

					weapAnim.IsPlaying = true;
					Vector3 temp2 = WeaponSprite.transform.localPosition;

					WeaponSprite.transform.localPosition = temp2;

					weapCollid.size = new Vector3 (0.32f, 0.32f, 1f);

					weapCollid.center = new Vector3 (-0.32f, 0f, 0f);
					weapCollid.isTrigger = true;

					break;
				case eAnimDir.Right:
					weapAnim.SetAnimDirection(new Vector2(-1f, 0f));

					weapAnim.IsPlaying = true;
					weapCollid.size = new Vector3(0.32f, 0.32f, 1f);

					weapCollid.center = new Vector3(0.32f, 0f, 0f);
					weapCollid.isTrigger = true;
					break;
				}

			


		}
		
			else if( Input.GetKey(KeyCode.V) && !(firstAbilityUsed) && Attacking == false) 
			{
				
				firstAbilityUsed = true;
				player = this.transform.position;
				 
				switch (m_animCtrl.AnimDirection)
				{
				case eAnimDir.Up:
					player.y += 0.32f;
					if (obj3 == null) {
						
						obj1 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);
						obj1.GetComponent<BoxCollider> ().size = new Vector3 (0.64f, 0.64f, 1f);
						obj1.transform.localScale = new Vector3 (0.5f, 0.5f, 1f);
						obj1.transform.localPosition = new Vector3 (obj1.transform.localPosition.x, obj1.transform.localPosition.y, 0.25f);

						player.y += 0.32f;
						obj2 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);
						obj2.transform.localScale = new Vector3 (0.75f, 0.75f, 1f);
						player.y += 0.32f;
						obj3 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);

						Destroy ((GameObject)obj1, 0.1f);
						Destroy (obj2, 0.3f);
						Destroy (obj3, 0.5f);
					}
					break;
				case eAnimDir.Down:
					if (obj3 == null) {
						player.y += -0.32f;

						obj1 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);
						obj1.GetComponent<BoxCollider> ().size = new Vector3 (0.64f, 0.64f, 1f);
						player.y += -0.32f;
						player.z -= 0.001f;
						obj2 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);

						player.y += -0.32f;
						player.z -= 0.001f;
						obj3 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);
						obj1.transform.localScale = new Vector3 (0.5f, 0.5f, 1f);
						obj2.transform.localScale = new Vector3 (0.75f, 0.75f, 1f);

						Destroy (obj1, 0.1f);
						Destroy (obj2, 0.3f);
						Destroy (obj3, 0.5f);
					}
					break;
				case eAnimDir.Left: 
					if (obj3 == null) {
						player.x += -0.32f;

						obj1 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);
						obj1.transform.localScale = new Vector3 (0.5f, 0.5f, 1f);
						obj1.GetComponent<BoxCollider> ().size = new Vector3 (0.64f, 0.64f, 1f);

						player.x += -0.32f;
						obj2 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);
						obj2.transform.localScale = new Vector3 (0.75f, 0.75f, 1f);
						player.x += -0.32f;
						obj3 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);
					
						Destroy ((GameObject)obj1, 0.1f);
						Destroy (obj2, 0.3f);
						Destroy (obj3, 0.5f);
					}
					break;
				case eAnimDir.Right:
					if (obj3 == null) {
						player.x += 0.32f;
						obj1 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);
						obj1.transform.localScale = new Vector3 (0.5f, 0.5f, 1f);
						obj1.GetComponent<BoxCollider> ().size = new Vector3 (0.64f, 0.64f, 1f);

						player.x += 0.32f;
						obj2 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);
						obj2.transform.localScale = new Vector3 (0.75f, 0.75f, 1f);
						player.x += 0.32f;
						obj3 = (GameObject)Instantiate (Abilityprefab, player, this.transform.rotation);
					
						Destroy ((GameObject)obj1, 0.1f);
						Destroy (obj2, 0.3f);
						Destroy (obj3, 0.5f);
						StartCoroutine (wait4());
					}
					break;
				}
//				while (firstAbilityUsed == false) {
//					if (obj3 == null) {
//						firstAbilityUsed = true;
//					}
//				}
				firstAbilityUsed = false;
			}

		}

		IEnumerator wait4()
		{
			yield return new WaitForSeconds (1f);
		}



		public void returnToIdle (DirectionalAnimation source)
		{
			
			GameObject.FindGameObjectWithTag ("Weapon").GetComponentInChildren<SpriteRenderer> ().sprite = idolPos;
			weapAnim.IsPlaying = false;
			
			Attacking = false;
		}
	}
}
