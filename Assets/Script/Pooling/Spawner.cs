using UnityEngine;

namespace PoolContainer
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private PoolObject objectPool;
        private float spawnInterval = 4f;
        private float timeSinceLastSpawn;

        private void Update()
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn > spawnInterval)
            {
                SpawnObject();
                timeSinceLastSpawn = 0f;
            }
        }

        private void SpawnObject()
        {
            GameObject obj = objectPool.GetObject();
            obj.transform.position = Random.insideUnitSphere * 5f;
            obj.transform.rotation = Quaternion.identity;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            objectPool.ReturnObject(collision.gameObject);
        }
    }
}
