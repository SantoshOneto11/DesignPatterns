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

            string s = Utility.Logger.ConvertSHA256("Hello");
            string k = Utility.Logger.ConvertSHA256WithKey("Hello", "key");
            Utility.Logger.myLog("Without Key --> " + s);
            Utility.Logger.myLog("WithKey --> " + k);
            Utility.Logger.myLog(k, Utility.LogLevels.WARN);
            Utility.Logger.myLog(k, Utility.LogCategory.UI);
        }
    }

}
