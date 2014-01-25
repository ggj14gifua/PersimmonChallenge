using UnityEngine;
using GameSystem;
using System.Collections.Generic;

namespace Gameplay
{
    class GameDaemon : GameSystem.SingletonMonoBehaviour< GameDaemon >
    {
        [SerializeField] private Light          m_mainLight     = null;
        [SerializeField] private GameObject     m_spotLights    = null;
        [SerializeField] private float          m_rotSpeed      = 1.0f;

        private List< GameObject >   m_spotLightList     = new List< GameObject >();

        public Light MainLight { get { return m_mainLight; } set { m_mainLight = value; } }

//////////////////////////////////////////////////////////////////////////
// 
// BehaviourBase
// 
//////////////////////////////////////////////////////////////////////////

        protected override void Awake()
        {
            base.Awake();

//             foreach( Transform child in m_spotLights.transform )
//             {
//                 m_spotLightList.Add( child.gameObject );
//             }
            //m_spotLightList.AddRange( m_spotLights.GetComponentsInChildren< Light >() );
        }
//------------------------------------------------------------------------

	    void Start()
	    {

        }
//------------------------------------------------------------------------

	    void Update()
	    {
            Vector3 lightRotAngles = MainLight.transform.localRotation.eulerAngles;
            MainLight.transform.rotation = Quaternion.Euler(lightRotAngles.x, lightRotAngles.y + Time.deltaTime * m_rotSpeed, lightRotAngles.z);


	    }
//------------------------------------------------------------------------

//////////////////////////////////////////////////////////////////////////
// 
// Public
// 
//////////////////////////////////////////////////////////////////////////

        public GameObject FindNearSpotLight( GameObject i_object )
        {
            GameObject  nearLight     = null;
            float       minLenSqr     = 0.0f;

            Vector3 objPos  = i_object.transform.position;
            foreach (var light in m_spotLightList)
            {
                Vector3 lightPos    = light.transform.position;
                float   lenSqr      = ( objPos - lightPos ).sqrMagnitude;

                if( nearLight == null )
                {
                    nearLight   = light;
                    minLenSqr   = lenSqr;
                    continue;
                }

                if( lenSqr < minLenSqr )
                {
                    nearLight   = light;
                    minLenSqr   = lenSqr;
                }
            }

            return nearLight;
        }
//------------------------------------------------------------------------

    } // class GameDaemon

} // namespace Gameplay
