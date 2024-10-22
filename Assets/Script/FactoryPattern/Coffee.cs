using FactoryPattern;
using UnityEngine;

namespace FactoryPattern
{
    public class Coffee : MonoBehaviour, IDrink
    {
        string IDrink.GetDrink()
        {
            return "This is Coffee";
        }
    }
}

