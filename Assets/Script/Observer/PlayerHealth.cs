using System;
using UnityEngine;

namespace Observer
{
    public class PlayerHealth : MonoBehaviour
    {
        private int _health = 100;
        public int Health => _health;

        //Events
        public event Action<int> OnHealthChange;

        public void TakeDamage(int value)
        {
            _health -= value;
            if (_health < 0) _health = 0;

            OnHealthChange.Invoke(Health);
        }

        public void Heal(int value)
        {
            _health += value;
            if (_health > 100) _health = 100;

            OnHealthChange.Invoke(Health);
        }
    }
}
