using UnityEngine;
using GameSystem;
using System.Collections.Generic;

namespace Gameplay
{
    class GameDaemon : GameSystem.SingletonMonoBehaviour< GameDaemon >
    {
        [SerializeField] private GameObject                 m_lightListObj  = null;
        [SerializeField] private List< LightLayer >         m_lightLayerList   = new List< LightLayer >();

        private List< Light >           m_directionalLightList  = new List< Light >();
        private List< GameObject >      m_spotLightList         = new List< GameObject >();



        // public Light MainLight { get { return m_mainLight; } set { m_mainLight = value; } }

//////////////////////////////////////////////////////////////////////////
// 
// BehaviourBase
// 
//////////////////////////////////////////////////////////////////////////

        protected override void Awake()
        {
            base.Awake();

            m_directionalLightList.AddRange(m_lightListObj.GetComponentsInChildren<Light>());

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
			if ( Pause.s_pauseFlag == false )
			{
	            foreach (var light in m_directionalLightList)
	            {
	                Vector3 lightRotAngles          = light.transform.localRotation.eulerAngles;
	                LightLayer lightLayer = m_lightLayerList.Find(info => (int)info.m_layer == light.gameObject.layer );
	                light.transform.rotation        = Quaternion.Euler(lightRotAngles.x, lightRotAngles.y + Time.deltaTime * lightLayer.m_speed, lightRotAngles.z);
	            }
			}
	    }
//------------------------------------------------------------------------

//////////////////////////////////////////////////////////////////////////
// 
// Public
// 
//////////////////////////////////////////////////////////////////////////


        public Light FindDirectionalLight(GameObject i_obj)
        {
            return m_directionalLightList.Find(light => light.gameObject.layer == i_obj.layer);
        }
//------------------------------------------------------------------------

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

        [System.Serializable]
        private class LightLayer
        {
            public enum ELayer
            {
                Normal = 8,
                HiSpeed,
                Reverse,
                ReverseHiSpeed,
            }

            public ELayer   m_layer = ELayer.Normal;
            public float    m_speed = 0.0f;
        }
//------------------------------------------------------------------------

    } // class GameDaemon



} // namespace Gameplay
