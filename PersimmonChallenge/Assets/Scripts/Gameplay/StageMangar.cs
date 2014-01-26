using UnityEngine;
using GameSystem;
using System.Collections.Generic;

namespace Gameplay
{
    class StageMangar : MonoBehaviour
    {
        [SerializeField] private GameObject     m_startPosition     = null;
        [SerializeField] private float          m_stageDistance     = 50.0f;
        [SerializeField] private string         m_goalResource      = "Prefabs/Buiding_Fix";
        [SerializeField] private Material       m_goalMaterial      = null;


//////////////////////////////////////////////////////////////////////////
// 
// BehaviourBase
// 
//////////////////////////////////////////////////////////////////////////

        void Awake()
        {
            GameObject obj  = GameObject.Instantiate( Resources.Load( m_goalResource ) ) as GameObject;
            AttachParentGameObject(obj, gameObject);
            
            Vector3 endPosition     = m_startPosition.transform.localPosition;
            endPosition.z          -= m_stageDistance;
            obj.transform.localPosition = endPosition;
            obj.name                = "EndPoint";

            MeshRenderer meshRenderer   = obj.GetComponentInChildren<MeshRenderer>();
            meshRenderer.material       = m_goalMaterial;

            Collider collider = obj.GetComponentInChildren<Collider>();
            if (collider != null)
            {
                CollisionTriggerChecker colChecker  = collider.gameObject.AddComponent<CollisionTriggerChecker>();
                colChecker.m_receiver               = gameObject;
            }
        }
//------------------------------------------------------------------------

        void OnTriggerEnter(Collider other)
        {
			Scene.NextScene = "Result";
            Scene.canNextScene = true;
        }
//------------------------------------------------------------------------

//////////////////////////////////////////////////////////////////////////
// 
// Private
// 
//////////////////////////////////////////////////////////////////////////

        public void AttachParentGameObject( GameObject io_child, GameObject i_parent )
        {
            if( io_child == null || i_parent == null )
            {
                return;
            }

            Vector3 localPosition = io_child.transform.localPosition;
            Vector3 localScale = io_child.transform.localScale;
            Quaternion localRotation = io_child.transform.localRotation;

            io_child.transform.parent = i_parent.transform;

            io_child.transform.localPosition = localPosition;
            io_child.transform.localScale = localScale;
            io_child.transform.localRotation = localRotation;
        }
//------------------------------------------------------------------------

    } // class StageMangar



} // namespace Gameplay
