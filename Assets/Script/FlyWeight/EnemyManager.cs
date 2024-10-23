using UnityEngine;

namespace FlyWeight
{
    public class EnemyManager : MonoBehaviour
    {
        public Sprite enemySprite;
        private EnemyFactory enemyFactory;

        private void Start()
        {
            enemyFactory = new EnemyFactory();

            for (int i = 0; i < 10; i++)
            {
                Enemy enemy = enemyFactory.GetEnemy(enemySprite);
                Vector3 position = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f));
                enemy.Display(position, transform);
            }            
        }
    }
}
