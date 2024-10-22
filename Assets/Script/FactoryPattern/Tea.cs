using FactoryPattern;
using UnityEngine;

namespace FactoryPattern
{
    public class Tea : MonoBehaviour, IDrink
    {
        string IDrink.GetDrink()
        {
            return "This is Tea";
        }
    }
}
