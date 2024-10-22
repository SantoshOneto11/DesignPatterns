using UnityEngine;
using UnityEngine.UI;

namespace Observer
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] PlayerHealth playerHealth;
        [SerializeField] Slider Slider;
        [SerializeField] Image clock;
        [SerializeField] Button hitBtn, healBtn;

        private void Start()
        {
            hitBtn.onClick.AddListener(() => playerHealth.TakeDamage(5));
            healBtn.onClick.AddListener(() => playerHealth.Heal(5));
        }

        private void OnEnable()
        {
            playerHealth.OnHealthChange += UpdateHealthUI;
        }

        private void UpdateHealthUI(int value)
        {
            float newValue = (float)value;
            Slider.value = newValue / 100;
            clock.fillAmount = newValue / 100;
            Debug.Log((newValue / 100).ToString());
        }

        private void OnDisable()
        {
            playerHealth.OnHealthChange -= UpdateHealthUI;
        }
    }
}
