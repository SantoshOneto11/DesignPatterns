using UnityEditor.Playables;
using UnityEngine;

namespace FactoryPattern
{
    public static class FactoryWorker
    {
        public static bool isProd = true;
        public static IDrink GetCurrentDrink(GameObject gameObject)
        {
            return isProd ? gameObject.AddComponent<Tea>() : gameObject.AddComponent<Coffee>();
        }
    }
}
