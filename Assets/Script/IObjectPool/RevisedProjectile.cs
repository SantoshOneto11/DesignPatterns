using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace UnityObjectPool
{
    public class RevisedProjectile : MonoBehaviour
    {
        [SerializeField] private float timeoutDelay = 3.0f;

        private IObjectPool<RevisedProjectile> objectPool;
        public IObjectPool<RevisedProjectile> ObjectPool { set => objectPool = value; }

        public void Deactivate()
        {
            StartCoroutine(DeactivateRoutine(timeoutDelay));
        }

        IEnumerator DeactivateRoutine(float delay)
        {
            yield return new WaitForSeconds(delay);

            objectPool.Release(this);
            Debug.Log("Object Sent to Pool");
        }
    }
}
