using System;
using System.Linq;
using UnityEngine;

namespace HotlineMiami
{
    public class PertrolEnemy : Enemy
    {
        [Obsolete]
        private void Start()
        {
            InitEnemy();
            //SetWayPoints(FindObjectsOfType<WayPoints>().Select(x => x.transform).ToArray());
            SetWayPoints(wayPoints);
        }
        public override void Petrol()
        {
            throw new System.NotImplementedException(); //Not Implementing Since follow path is doing most work alredy.
        }


        public override void FollowPath()
        {
            if (wayPoints.Length == 0) return;

            Transform targetWayPoints = wayPoints[currentWayPointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoints.position, patrolSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetWayPoints.position) < 0.1f)
            {
                currentWayPointIndex = (currentWayPointIndex + 1) % wayPoints.Length;
            }
        }


        public override void ChasePlayer(Transform player)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.position) < attackRange)
            {
                ChangeState(ENEMY_STATE.ATTACK);
            }
        }


        public override void AttackPlayer()
        {
            transform.position = Vector3.Lerp(transform.position, player.position, attackSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, player.position) > attackRange)
            {
                ChangeState(ENEMY_STATE.INSPECT);
            }
        }

        public override void Inspect()
        {
            Utility.Logger.myLog("Enemy Inspecting", Utility.LogCategory.PHYSICS);
            Invoke("ReturnToPatrol", 2f);
        }


        public override void TakeDamage(int value)
        {
            enemyHealth -= value;
        }

        private void ReturnToPatrol()
        {
            ChangeState(ENEMY_STATE.PETROL);
        }
    }
}
