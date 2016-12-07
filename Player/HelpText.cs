using UnityEngine;
using System.Collections;

namespace CreativeSpore.RpgMapEditor
{
    [AddComponentMenu("RpgMapEditor/Behaviours/HelpText", 10)]
    public class HelpText : MonoBehaviour 
    {
        public GameObject TextObj;
        public float DistanceFromPlayerToAppear;

        private Renderer m_helpTextRenderer;
		private GameObject m_player;
		private bool enter;
		private bool middle;
		private bool exit;

	    // Use this for initialization
	    void Start () 
        {
			m_player = GameObject.FindGameObjectWithTag("Player");
            m_helpTextRenderer = TextObj.GetComponent<Renderer>();
			m_helpTextRenderer.enabled = false;
	    }
	
	    void Update () 
        {
//       bool isPlayerCloseEnough = Vector2.Distance(transform.position, m_player.transform.position) <= DistanceFromPlayerToAppear;
//            m_helpTextRenderer.enabled = isPlayerCloseEnough;
//            if (isPlayerCloseEnough)
//            {
//                Color textColor = m_helpTextRenderer.material.color;
//                textColor.a = Mathf.Clamp(0.2f + Mathf.Abs(Mathf.Sin(0.05f * Time.frameCount)), 0f, 1f);
//                m_helpTextRenderer.material.color = textColor;                
//            }	
	    }
		void OnTriggerEnter(Collider other)
		{
			if (other.isTrigger == false) {
				
				enter = true;
			}
		}
		void OnTriggerStay(Collider other)
		{
			if (other.isTrigger == false) {
				m_helpTextRenderer.enabled = true;

				Color textColor = m_helpTextRenderer.material.color;
				textColor.a = Mathf.Clamp (0.2f + Mathf.Abs (Mathf.Sin (0.05f * Time.frameCount)), 0f, 1f);
				m_helpTextRenderer.material.color = textColor;     
				
			}

		}
		void OnTriggerExit(Collider other)
		{
			if (other.isTrigger == false) {
				m_helpTextRenderer.enabled = false;
				
				exit = true;
			}


			                

		}


    }
}