using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CreativeSpore.RpgMapEditor
{
	//PathFinding class for Enemies
	//Uses simple A* flavor alg to follow player
	public class NewAI : MonoBehaviour {

		public Vector3 curr;
		public Vector3 targetTile;
		private bool ableToMove;
		//private float m_fAxisX = 0;
		//private float m_fAxisY = 0;
		public Vector3 spawnTile;
		public Vector3 low;
		public Vector3 move;
		public AutoTile TargetTile = null;
		protected DirectionalAnimation m_animCtrl;
		protected PhysicCharBehaviour m_phyChar;
		protected TileMovementBehaviour tmov;
		public bool foundTarg;

	// Use this for initialization
	void Start () {
		m_animCtrl = GetComponent<DirectionalAnimation>();
		m_phyChar = GetComponent<PhysicCharBehaviour>();
		targetTile = this.transform.position;
		ableToMove = true;
		spawnTile = targetTile;
		tmov = GetComponent<TileMovementBehaviour> ();
		curr = transform.position;
		foundTarg = false;

}

// Update is called once per frame
void LateUpdate () {

	curr = this.transform.position;

	targetTile = spawnTile;

	//Is the player close enough to trigger AI?
	GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
	int i = 0;
	for (i = 0; i < players.Length; i++) {
		if ((curr - players [i].transform.position).magnitude < 2f && (this.transform.position - players [i].transform.position).magnitude > .30f) {
			targetTile = players [i].transform.position;
			foundTarg = true;
			break;
		}
	}
			if (foundTarg) {
				//Find best move to reach goal
				move = findPath ();

				//Ajust decision to activate movement system
				if (curr.x + move.x != targetTile.x + .3f
				  || curr.x + move.x != targetTile.x - .3f
				  || curr.y + move.y != targetTile.y + .3f
				  || curr.y + move.y != targetTile.y - .3f) {
			 
					m_animCtrl.SetAnimDirection (new Vector2 (move.x, move.y));

					if (Mathf.Abs (move.y) >= Mathf.Abs (move.x) && move.y > 0) {
						tmov.ActivateTrigger (TileMovementBehaviour.eTrigger.MoveUp);
					} else if (Mathf.Abs (move.y) >= Mathf.Abs (move.x) && move.y < 0) {
						tmov.ActivateTrigger (TileMovementBehaviour.eTrigger.MoveDown);
					} else if (Mathf.Abs (move.y) <= Mathf.Abs (move.x) && move.x < 0) {
						tmov.ActivateTrigger (TileMovementBehaviour.eTrigger.MoveLeft);
					} else if (Mathf.Abs (move.y) <= Mathf.Abs (move.x) && move.x > 0) {
						tmov.ActivateTrigger (TileMovementBehaviour.eTrigger.MoveRight);
					}
				}
			}

}

//		public bool IsPassable() 
//		{
//			AutoTileMap autoTileMap = AutoTileMap.Instance;
//
//			if (autoTileMap.IsValidAutoTilePos(TileX, TileY))
//			{
//				for( int iLayer = autoTileMap.GetLayerCount() - 1; iLayer >= 0; --iLayer )
//				{
//					if( autoTileMap.MapLayers[iLayer].LayerType == eLayerType.Ground )
//					{
//						AutoTile autoTile = autoTileMap.GetAutoTile(TileX, TileY, iLayer);
//						eTileCollisionType collType = autoTile.Id >= 0 ? autoTileMap.Tileset.AutotileCollType[autoTile.Id] : eTileCollisionType.EMPTY;
//						if( collType == eTileCollisionType.PASSABLE || collType == eTileCollisionType.WALL )
//						{
//							return true;
//						}
//						else if( collType == eTileCollisionType.BLOCK || collType == eTileCollisionType.FENCE )
//						{
//							return false;
//						}
//					}
//				}
//			}
//			return false;
//		}

	//A* Style pathfinding
	public Vector3 findPath()
	{
			AutoTile m_CurTile;
			AutoTile m_CurTile2;
			AutoTile m_CurTile3;
			Vector3 targetMapPos;
		float[,] map = new float[3,3]; //Represents the 8 surrounding the object
		float idx = -(1f* .32f); //far left tile Column
		float idy = (1f* .32f); //Top most Row of tiles
		float lowest = 100f;

		low = new Vector3 (0f, 0f, 0f);
		//Loops through each row 
		for (int i = 0; i < 3; i ++){
			//Loops through each tile in this row
			for (int j = 0; j < 3; j++) {
					
					float temp = Vector3.Distance(this.transform.position + new Vector3(idx, idy, 0f), targetTile);

				
				map [i, j] = temp;
					m_CurTile = RpgMapHelper.GetAutoTileByPosition(this.transform.position + new Vector3(idx, idy, 0f), 0);
					m_CurTile2 = RpgMapHelper.GetAutoTileByPosition(this.transform.position + new Vector3(idx, idy, 0f), 1);
					m_CurTile3 = RpgMapHelper.GetAutoTileByPosition(this.transform.position + new Vector3(idx, idy, 0f), 2);
				    //targetMapPos = new Vector2(m_CurTile.TileX, m_CurTile.TileY);
					targetMapPos = RpgMapHelper.GetTileCenterPosition(m_CurTile.TileX, m_CurTile.TileY);
					eTileCollisionType collType = AutoTileMap.Instance.GetAutotileCollisionAtPosition( targetMapPos );
					eTileCollisionType collType2 = AutoTileMap.Instance.GetAutotileCollisionAtPosition( targetMapPos );
					eTileCollisionType collType3 = AutoTileMap.Instance.GetAutotileCollisionAtPosition( targetMapPos );
					if ((i == 0 && j == 0) || (i == 2 && j == 0) || (i == 0 && j == 2) || (i == 2 && j == 2) || (i == 1 && j == 1)
						 || collType != eTileCollisionType.PASSABLE 
							) {
						temp = 100f;
					}
					
				if (temp < lowest) {
					lowest = temp;

					low = new Vector3 (idx, idy, 0f);
				}

				idx += .32f;

			}

			idy -= .32f;

			idx = -.32f;
		}

		Vector3 decision = low;

		return decision;

	}

}
	}