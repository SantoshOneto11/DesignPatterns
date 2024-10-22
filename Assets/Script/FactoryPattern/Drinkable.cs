using TMPro;
using UnityEngine;

namespace FactoryPattern
{
    public class Drinkable : MonoBehaviour
    {
        [SerializeField] private TMP_Text msgTxt;
        private IDrink _drink;

        private void Start()
        {
            _drink = FactoryWorker.GetCurrentDrink(gameObject);
            msgTxt.text = _drink.GetDrink();
        }
    }

}
