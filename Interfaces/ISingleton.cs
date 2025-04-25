using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLib.Interfaces
{
    /// <summary>
    /// Interface that implements the Singleton class. Uses the Singleton pattern to make sure that only one instance of class exists at a given time.
    /// </summary>
    /// <typeparam name="T">Singleton class, requires a private constructor without parameters</typeparam>
    public interface ISingleton<T>
    {
        /// <summary>
        /// Gets a reference to singleton, or creates a new singleton instance and returns that if none is found
        /// </summary>
        /// <returns></returns>
        public static abstract T GetSingleton();
    }
}
