using System.Collections.Generic;
using UnityEngine;

namespace FlyWeight
{
    public class EnemyFactory : MonoBehaviour
    {
        private Dictionary<string, Enemy> enemyDictionary = new Dictionary<string, Enemy>();

        public Enemy GetEnemy(Sprite sprite)
        {
            string key = sprite.name;
            if (!enemyDictionary.ContainsKey(key))
            {
                enemyDictionary[key] = new Enemy(sprite);
            }
            return enemyDictionary[key];
        }
    }
}
