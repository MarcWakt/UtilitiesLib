using System.ComponentModel.DataAnnotations;
using System.Reflection;
using UtilitiesLib.Interfaces;

namespace UtilitiesLib.Managers
{
    public class Singleton<T> : ISingleton<T>
    {
        [Required] public static T? Instance;
        public Singleton(T obj)
        {
            var constructors = typeof(T).GetConstructors();
            if (constructors.Length == 0 || constructors.Where(c => c.IsPublic).Count() > 0/* || constructors.Where(c => c.GetParameters().Length > 0)*/) throw new Exception("Constructor error. Existing public constructor or wrong amount of parameters");   
            Instance = obj;
        }
        public static T GetSingleton()
        {
            try{
                if (Instance == null) return Instance = (T)Activator.CreateInstance(typeof(T), true);
                else return Instance;
            }
            catch { throw new Exception("Singleton error"); }
        }
    }
}
