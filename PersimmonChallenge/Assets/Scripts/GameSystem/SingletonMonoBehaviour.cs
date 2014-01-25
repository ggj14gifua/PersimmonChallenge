using UnityEngine;

namespace GameSystem
{
    /// <summary>
    /// MonoBehaviour用Singleton。
    /// </summary>
    class SingletonMonoBehaviour< TMyClass > : MonoBehaviour where TMyClass : MonoBehaviour
    {
        private static  TMyClass    s_instance  = null;


//////////////////////////////////////////////////////////////////////////
// 
// Property
// 
//////////////////////////////////////////////////////////////////////////

        public static TMyClass Instance
        {
            get
            {
                if( s_instance == null )
                {
                    s_instance = (TMyClass)FindObjectOfType( typeof(TMyClass) );
                }

                return s_instance;
            }
            private set
            {
                s_instance  = value;
            }
        }
//------------------------------------------------------------------------

//////////////////////////////////////////////////////////////////////////
// 
// BehaviourBase
// 
//////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Unity:スクリプトのインスタンスがロードされたときに呼び出される。
        /// </summary>
        protected virtual void Awake()
        {
            if( this != Instance )
            {
                Destroy( this );
            }
        }
//------------------------------------------------------------------------

    } // class SingletonMonoBehaviour

} // namespace GameSystem
