using UnityEngine;
using GameSystem;
using System.Collections;
using System.Collections.Generic;

namespace Gameplay
{
    class GameDaemon : GameSystem.SingletonMonoBehaviour< GameDaemon >
    {
        [SerializeField] private Light      m_mainLight     = null;
        [SerializeField] private float      m_rotSpeed      = 1.0f;

        public Light MainLight { get { return m_mainLight; } set { m_mainLight = value; } }

//////////////////////////////////////////////////////////////////////////
// 
// BehaviourBase
// 
//////////////////////////////////////////////////////////////////////////

        protected override void Awake()
        {
            base.Awake();
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

    } // class GameDaemon

} // namespace Gameplay
