using UnityEngine;
using GameSystem;

namespace Entity
{
    class Building : MonoBehaviour
    {
        [SerializeField] private GameObject     m_buildingObject    = null;
        [SerializeField] private GameObject     m_shadowObject      = null;

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
            UpdateShadowRotation();
            UpdateShadowScale();
            UpdateShadowPosition();
        }
//------------------------------------------------------------------------

        private void UpdateShadowRotation()
        {
            Light   mainLight           = Gameplay.GameDaemon.Instance.MainLight;

            Vector3 lightRotAngles      = mainLight.transform.localRotation.eulerAngles;
            Vector3 shadowRotAngles     = m_shadowObject.transform.rotation.eulerAngles;
            m_shadowObject.transform.rotation = Quaternion.Euler( shadowRotAngles.x, lightRotAngles.y, shadowRotAngles.z );
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
//------------------------------------------------------------------------

        private void UpdateShadowPosition()
        {
            Light mainLight         = Gameplay.GameDaemon.Instance.MainLight;
            Vector3 lightRotAngles  = mainLight.transform.localRotation.eulerAngles;

            Quaternion  rot         = Quaternion.AngleAxis( lightRotAngles.y, Vector3.up );
            Vector3     direction   = rot * Vector3.forward;
            Vector3     pos         = m_buildingObject.transform.localPosition;
            pos.y                  -= m_buildingObject.transform.localScale.y;
            pos                    += direction * BASEHALF_SIZE * m_shadowObject.transform.localScale.z;

            m_shadowObject.transform.localPosition = pos;
        }
//------------------------------------------------------------------------


    } // class Building

} // namespace Entity
