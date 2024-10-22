using System.Collections.Generic;
using UnityEngine;

namespace PoolContainer
{
    public class PoolObject : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int poolSize = 10;

        [SerializeField] private List<GameObject> pool;

        private void Awake()
        {
            pool = new List<GameObject>(poolSize);
            for (int i = 0; i < poolSize; i++)
            {
                CreateNewObject();
            }
        }

        private GameObject CreateNewObject()
        {
            GameObject newObj = Instantiate(prefab);
            newObj.SetActive(false);
            pool.Add(newObj);
            return newObj;
        }

        public GameObject GetObject()
        {
            foreach (var pooledObject in pool)
            {
                if (!pooledObject.activeInHierarchy)
                {
                    pooledObject.SetActive(true);
                    return pooledObject;
                }
            }
            return CreateNewObject();
        }

        public void ReturnObject(GameObject obj)
        {
            Debug.Log("Object Sent to Pool");
            obj.SetActive(false);
        }
    }
}
