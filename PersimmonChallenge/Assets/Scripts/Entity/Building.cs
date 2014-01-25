using UnityEngine;
using GameSystem;

namespace Entity
{
    class Building : MonoBehaviour
    {
        private enum ELightType
        {
            Directional,
            Spot,
        }

        [SerializeField] private GameObject     m_buildingObject    = null;
        [SerializeField] private GameObject     m_shadowObject      = null;
        [SerializeField] private ELightType     m_lightType         = ELightType.Directional;
        [SerializeField] private float          m_spotAngle         = 0.0f;
        [SerializeField] private float          m_spotLength        = 2.0f;
        
        private MeshRenderer                    m_buildingRenderer  = null;
        private MeshRenderer                    m_shadowRenderer    = null;

        private const float BASEMESH_SIZE   = 10.0f;
        private const float BASEHALF_SIZE   = BASEMESH_SIZE * 0.5f;

        private const float CTRL_SCLAE      = 1.1f;

//////////////////////////////////////////////////////////////////////////
// 
// BehaviourBase
// 
//////////////////////////////////////////////////////////////////////////

	    void Awake()
        {
            m_buildingRenderer  = m_buildingObject.GetComponent< MeshRenderer >();
            m_shadowRenderer    = m_shadowObject.GetComponent< MeshRenderer >();
        }
//------------------------------------------------------------------------

        void Start()
        {
            UpdateShadow();
        }
//------------------------------------------------------------------------

        void Update()
        {
            UpdateShadow();
        }
//------------------------------------------------------------------------


//////////////////////////////////////////////////////////////////////////
// 
// Private
// 
//////////////////////////////////////////////////////////////////////////

        private void UpdateShadow()
        {
            if (m_lightType == ELightType.Spot)
            {
                m_shadowRenderer.enabled        = true;
                m_buildingRenderer.castShadows  = false;
            }
            else
            {
                m_shadowRenderer.enabled        = false;
                m_buildingRenderer.castShadows  = true;
            }

            UpdateShadowRotation();
            UpdateShadowScale();
            UpdateShadowPosition();
        }
//------------------------------------------------------------------------

        private void UpdateShadowRotation()
        {
            if (m_lightType == ELightType.Spot)
            {
//                 GameObject  lightObj    = Gameplay.GameDaemon.Instance.FindNearSpotLight(gameObject);
//                 Vector3     curPos      = transform.position;
//                 Vector3     lightPos    = lightObj.transform.position;
//                 Vector3     lightDir    = curPos - lightPos;
//                 lightDir.y = 0.0f;
//                 lightDir.Normalize();
// 
// 
//                 float angle             = Vector3.Angle( Vector3.forward, lightDir );
//                 if (curPos.x < lightPos.x)
//                 {
//                     angle = -angle;
//                 }


                Vector3 shadowRotAngles = m_shadowObject.transform.rotation.eulerAngles;
                m_shadowObject.transform.rotation = Quaternion.Euler(shadowRotAngles.x, /*angle*/m_spotAngle, shadowRotAngles.z);

            }
            else
            {
                Light   mainLight           = Gameplay.GameDaemon.Instance.MainLight;

                Vector3 lightRotAngles      = mainLight.transform.localRotation.eulerAngles;
                Vector3 shadowRotAngles     = m_shadowObject.transform.rotation.eulerAngles;
                m_shadowObject.transform.rotation = Quaternion.Euler( shadowRotAngles.x, lightRotAngles.y, shadowRotAngles.z );
            }
            
        }
//------------------------------------------------------------------------

        private void UpdateShadowScale()
        {
            {
                Vector3 buildingScale       = m_buildingObject.transform.localScale;
                float   radiusScale         = buildingScale.x >= buildingScale.z ? buildingScale.x : buildingScale.z;
                Vector3 shadowScale         = m_shadowObject.transform.localScale;
                shadowScale.x   = shadowScale.z     = radiusScale / BASEMESH_SIZE;
                m_shadowObject.transform.localScale = shadowScale;


            }

            if (m_lightType == ELightType.Spot)
            {
                Vector3 scale   = m_shadowObject.transform.localScale;
                scale.z         = m_spotLength / BASEMESH_SIZE;
                m_shadowObject.transform.localScale = scale;
            }
            else
            {
                Light   mainLight           = Gameplay.GameDaemon.Instance.MainLight;

                Vector3 lightRotAngles      = mainLight.transform.localRotation.eulerAngles;
                if( lightRotAngles.x >= 90.0f )
                {
                    return;
                }

                float   rad     = lightRotAngles.x * Mathf.PI / 180;
                float   tan     = Mathf.Tan( rad );
                float   height  = m_buildingObject.transform.localScale.y * 2.0f;
                float   length  = height / tan;
                Vector3 scale   = m_shadowObject.transform.localScale;
                scale.z         = length  / BASEMESH_SIZE * CTRL_SCLAE;
                m_shadowObject.transform.localScale = scale;
            }
            
        }
//------------------------------------------------------------------------

        private void UpdateShadowPosition()
        {
            Vector3 lightRotAngles  = Vector3.zero;
            if (m_lightType == ELightType.Spot)
            {
                lightRotAngles      = m_shadowObject.transform.localRotation.eulerAngles;
            }
            else
            {
                Light mainLight     = Gameplay.GameDaemon.Instance.MainLight;
                lightRotAngles      = mainLight.transform.localRotation.eulerAngles;
            }

            
            Quaternion  rot         = Quaternion.AngleAxis( lightRotAngles.y, Vector3.up );
            Vector3     direction   = rot * Vector3.forward;
            Vector3     pos         = m_buildingObject.transform.localPosition;
            pos.y                  -= m_buildingObject.transform.localScale.y;
            if (m_lightType == ELightType.Spot)
            {
                pos.y              += m_buildingObject.transform.localScale.y * 0.5f;
                pos.y              += 0.01f;
            }
            pos                    += direction * BASEHALF_SIZE * m_shadowObject.transform.localScale.z;

            m_shadowObject.transform.localPosition = pos;
        }
//------------------------------------------------------------------------


    } // class Building

} // namespace Entity
