
namespace GameSystem
{
    public class Singleton< TMyClass> where TMyClass : class
    {
        private static TMyClass    s_instance = null;

        protected Singleton()
        {
            
        }
//------------------------------------------------------------------------

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
                    s_instance = System.Activator.CreateInstance( typeof( TMyClass ), true ) as TMyClass;
                }
                return s_instance;
            }
        }
//------------------------------------------------------------------------
       
    } // class Singleton

} // namespace GameSystem
