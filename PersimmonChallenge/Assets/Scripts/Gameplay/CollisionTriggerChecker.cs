using UnityEngine;
using GameSystem;
using System.Collections.Generic;

namespace Gameplay
{
    class CollisionTriggerChecker : MonoBehaviour
    {
        [SerializeField] public GameObject     m_receiver    = null;

//////////////////////////////////////////////////////////////////////////
// 
// BehaviourBase
// 
//////////////////////////////////////////////////////////////////////////

        void Awake()
        {
            Collider col    = GetComponent<Collider>();
            if (col != null)
            {
                col.isTrigger = true;
            }
        }
//------------------------------------------------------------------------

        void OnTriggerEnter(Collider other)
        {
            if (m_receiver != null)
            {
                m_receiver.SendMessage("OnTriggerEnter",other);
            }
        }
//------------------------------------------------------------------------

    } // class CollisionTriggerChecker



} // namespace Gameplay
