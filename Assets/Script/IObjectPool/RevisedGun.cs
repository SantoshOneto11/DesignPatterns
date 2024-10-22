using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace UnityObjectPool
{
    public class RevisedGun : MonoBehaviour
    {
        private IObjectPool<RevisedProjectile> objectPool;
        private bool collectionCheck = true;

        private int defaultCapacity = 20;
        private int maxCapacity = 100;

        [SerializeField] RevisedProjectile projectiePrefab;

        private void Awake()
        {
            objectPool = new ObjectPool<RevisedProjectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool,
                OnDestroyPooledObject, collectionCheck, defaultCapacity, maxCapacity);
        }

        private RevisedProjectile CreateProjectile()
        {
            RevisedProjectile projectile = Instantiate(projectiePrefab);
            projectile.ObjectPool = objectPool;
            return projectile;
        }

        private void OnGetFromPool(RevisedProjectile projectile)
        {
            projectile.gameObject.SetActive(true);
        }

        private void OnReleaseToPool(RevisedProjectile projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        private void OnDestroyPooledObject(RevisedProjectile projectile)
        {
            Destroy(projectile.gameObject);
        }

        private void FixedUpdate()
        {
            //Some Logic Goes here
        }
    }
}
