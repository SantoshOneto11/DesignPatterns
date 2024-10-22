using UnityEngine;

namespace FlyWeight
{
    public class Enemy
    {
        private Sprite sprite;

        public Enemy(Sprite sprite)
        {
            this.sprite = sprite;
        }

        public void Display(Vector3 position, Transform parent)
        {
            GameObject enemyObj = new GameObject("Enemy01");
            enemyObj.transform.position = position;
            enemyObj.transform.SetParent(parent);

            SpriteRenderer sp = enemyObj.AddComponent<SpriteRenderer>();
            sp.sprite = sprite;
        }
    }
}
