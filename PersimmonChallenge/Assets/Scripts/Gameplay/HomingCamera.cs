using UnityEngine;
using GameSystem;
using System.Collections.Generic;

namespace Gameplay
{
    class HomingCamera : MonoBehaviour
    {
        [SerializeField] private GameObject m_lookAt    = null;
        [SerializeField] private float      m_distance  = 4.0f;

//////////////////////////////////////////////////////////////////////////
// 
// BehaviourBase
// 
//////////////////////////////////////////////////////////////////////////

        void Awake()
        {
            UpdateHomingPosition();
        }
//------------------------------------------------------------------------

	    void Start()
	    {

        }
//------------------------------------------------------------------------

	    void Update()
	    {
            UpdateHomingPosition();
	    }
//------------------------------------------------------------------------

//////////////////////////////////////////////////////////////////////////
// 
// Private
// 
//////////////////////////////////////////////////////////////////////////

        private void UpdateHomingPosition()
        {
            Vector3 lookAtPosition  = m_lookAt.transform.position;
            Vector3 cameraPosition  = transform.position;
            cameraPosition.z        = lookAtPosition.z + m_distance;

            transform.position      = cameraPosition;
           
        }
//------------------------------------------------------------------------


    } // class HomingCamera



} // namespace Gameplay
