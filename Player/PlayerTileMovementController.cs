using UnityEngine;
using System.Collections;

namespace CreativeSpore.RpgMapEditor
{
    [AddComponentMenu("RpgMapEditor/Controllers/PlayerTileMovementController", 10)]
    [RequireComponent(typeof(TileMovementBehaviour))]
    public class PlayerTileMovementController : PlayerController
    {
		
        private TileMovementBehaviour m_tileMovementBehaviour;
		public Equipment equanim; 
		public bool canMove;
		public DirectionalAnimation attack;
		public Vector3 currDir;
        public BoxCollider weapCollid;
		public bool teleporting;
		public string TargetTeleporterName;
		public string newScene;


		#region Singleton and Persistence
		static PlayerTileMovementController s_instance;
		void Awake () {
			if (s_instance == null) {
				DontDestroyOnLoad (gameObject);
				s_instance = this;

			} else if (s_instance != this) {
				Destroy (gameObject);
			}
		}
		#endregion

		void teleport()
		{
			GameObject obj = GameObject.FindGameObjectWithTag ("Player");
			print ("Player works");
			GameObject targetTeleport = GameObject.Find(TargetTeleporterName);
			while (targetTeleport == null) {

				targetTeleport = GameObject.Find(TargetTeleporterName);
			}
			print ("Tele works");
			BoxCollider teleporterBhv2 = targetTeleport.GetComponent<BoxCollider>();
			print ("Collider works");


			Vector3 targetPos = teleporterBhv2.transform.position;
			print (targetPos);
			print ("wtf???");
			print (teleporterBhv2.transform.position);
			targetPos.z = transform.position.z;
			transform.position = targetPos;
			GetComponent<PhysicCharBehaviour> ().Dir = Vector3.zero;
		}


        protected override void Start()
        {
            base.Start();            
            m_tileMovementBehaviour = GetComponent<TileMovementBehaviour>();
			//equanim = gameObject.GetComponent<Equipment> ();
			canMove = true;
			attack = GetComponents<DirectionalAnimation> () [1];
			attack.enabled = false;
			currDir = m_phyChar.Dir;


        }

		public void reset(DirectionalAnimation source)
		{
			
			attack.IsPlaying = false;
			attack.enabled = false;
            Destroy(weapCollid);
			canMove = true;
		}

        public void attacking()
        {
            print("Attack!");
			weapCollid = this.gameObject.AddComponent<BoxCollider>();
			//weapCollid = this.gameObject.transform.GetChild(1).gameObject.AddComponent<BoxCollider>();
                switch (m_animCtrl.AnimDirection)
				{
				case eAnimDir.Up:

				    
                    weapCollid.isTrigger = true;

				    weapCollid.size = new Vector3(0.32f, 0.32f, 1f);
				    weapCollid.center= new Vector3(0f, 0.32f, 0f);
				   
				    break;

                case eAnimDir.Down:
                    weapCollid.isTrigger = true;
					weapCollid.size = new Vector3(0.32f, 0.32f, 1f);
					weapCollid.center = new Vector3(0f, -0.32f, 0f);
					
					break;

				case eAnimDir.Left:
                    weapCollid.isTrigger = true;
					weapCollid.size = new Vector3 (0.32f, 0.32f, 1f);

					weapCollid.center = new Vector3 (-0.32f, 0f, 0f);
					
					break;
				case eAnimDir.Right:
                    weapCollid.isTrigger = true;
					weapCollid.size = new Vector3(0.32f, 0.32f, 1f);

					weapCollid.center = new Vector3(0.32f, 0f, 0f);
					
					break;
				}
                print("You Attacked!");
                
        }

        void onTriggerStay(Collider other)
        {
            print("Started?");
            //if (other.transform.gameObject == GameObject.FindGameObjectWithTag("Player"))
            //{
            other.gameObject.GetComponent<EnemyHealth>().takeDamage(10);
            print("Enemy Damaged");
            //}
        }

		void onCollisionStay(Collision other)
		{
			print ("wtf");
		}

		private int m_lastTileIdx = -1;
		private int m_lastFogSightLength = 0;

        protected override void Update()
        {

			int tileIdx = RpgMapHelper.GetTileIdxByPosition(transform.position);

			if (tileIdx != m_lastTileIdx || m_lastFogSightLength != FogSightLength)
			{
				RpgMapHelper.RemoveFogOfWarWithFade(transform.position, FogSightLength);
			}

			m_lastFogSightLength = FogSightLength;
			m_lastTileIdx = tileIdx;


			if (teleporting == true && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == newScene) {
				teleporting = false;
				teleport ();

			}
            Vector3 savedDir = m_phyChar.Dir;
            
            m_phyChar.Dir = savedDir;

            m_tileMovementBehaviour.enabled = (Vehicle == null);

			//DirectionalAnimation[] anims = GetComponentsInChildren<DirectionalAnimation> ();

            if (m_tileMovementBehaviour.enabled)
            {	
				if (Input.GetKey (KeyCode.Space) && canMove) {
					attack.enabled = true;
					attack.SetAnimDirection (currDir);
					attack.IsPlaying = true;
                    attacking();
					attack.OnAnimationLoopOver += reset;
					canMove = false;
                    
				} else if (canMove) {
				

					if (Input.GetKey (KeyCode.RightArrow)) {
					
						if (Input.GetAxis ("Horizontal") < .2) {
							m_animCtrl.SetAnimDirection (Vector3.right);
							currDir = Vector3.right;
//						for (int i = 0; i < anims.Length; i++) {
//
//							anims[i].SetAnimDirection(Vector3.right);
//						}
						} else {
							m_animCtrl.SetAnimDirection (Vector3.right);
							currDir = Vector3.right;
							m_tileMovementBehaviour.ActivateTrigger (TileMovementBehaviour.eTrigger.MoveRight);
						}

					} else if (Input.GetKey (KeyCode.LeftArrow)) {
					
						if (Mathf.Abs (Input.GetAxis ("Horizontal")) < .2) {
							m_animCtrl.SetAnimDirection (Vector3.left);
							currDir = Vector3.left;

//						for (int i = 0; i < anims.Length; i++) {
//
//							anims[i].SetAnimDirection(Vector3.left);
//						}
						} else {
							m_animCtrl.SetAnimDirection (Vector3.left);
							currDir = Vector3.left;
							m_tileMovementBehaviour.ActivateTrigger (TileMovementBehaviour.eTrigger.MoveLeft);
						}

					} else if (Input.GetKey (KeyCode.UpArrow)) {
					
						if (Input.GetAxis ("Vertical") < .2) {
							m_animCtrl.SetAnimDirection (Vector3.up);
							currDir = Vector3.up;
//						for (int i = 0; i < anims.Length; i++) {
//
//							anims[i].SetAnimDirection(Vector3.up);
//						}
						} else {
							m_animCtrl.SetAnimDirection (Vector3.up);
							currDir = Vector3.up;
							m_tileMovementBehaviour.ActivateTrigger (TileMovementBehaviour.eTrigger.MoveUp);
						}

					} else if (Input.GetKey (KeyCode.DownArrow)) {
					
						if (Mathf.Abs (Input.GetAxis ("Vertical")) < .2) {
							m_animCtrl.SetAnimDirection (Vector3.down);
							currDir = Vector3.down;

//						for (int i = 0; i < anims.Length; i++) {
//
//							anims[i].SetAnimDirection(Vector3.down);
//						}
						} else {
							m_animCtrl.SetAnimDirection (Vector3.down);
							currDir = Vector3.down;
							m_tileMovementBehaviour.ActivateTrigger (TileMovementBehaviour.eTrigger.MoveDown);
						}

					}
				}
            }
        }             
    }
}
