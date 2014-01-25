using UnityEngine;
using GameSystem;
using System.Collections;
using System.Collections.Generic;

namespace Gameplay
{
    class GameDaemon : GameSystem.SingletonMonoBehaviour< GameDaemon >
    {

        [SerializeField] private Light      m_mainLight  = null;

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

	    }
//------------------------------------------------------------------------

    } // class GameDaemon

} // namespace Gameplay
