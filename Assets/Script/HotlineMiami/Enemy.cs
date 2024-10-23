using UnityEngine;

namespace HotlineMiami
{
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        public float enemyHealth;
        public float maxHealth = 100f;
        public float patrolSpeed;
        public float chaseSpeed;
        public float attackSpeed;
        public float detectionRange;
        public float attackRange;

        protected ENEMY_STATE currentState;
        protected Transform[] wayPoints;
        protected int currentWayPointIndex = 0;
        protected Transform player;

        public void InitEnemy()
        {
            enemyHealth = maxHealth;
            player = Player.Instance.transform;
            currentState = ENEMY_STATE.PETROL;
        }
        public void ChangeState(ENEMY_STATE newState)
        {
            currentState = newState;
        }

        protected void SetWayPoints(Transform[] newWayPoints)
        {
            wayPoints = newWayPoints;
        }

        protected void Update()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            switch (currentState)
            {
                case ENEMY_STATE.PETROL:
                    FollowPath();
                    if (distanceToPlayer < detectionRange)
                    {
                        ChangeState(ENEMY_STATE.CHASE);
                    }
                    break;

                case ENEMY_STATE.INSPECT:
                    Inspect();
                    if (distanceToPlayer < detectionRange)
                    {
                        ChangeState(ENEMY_STATE.CHASE);
                    }
                    break;

                case ENEMY_STATE.CHASE:
                    ChasePlayer(player);
                    if (distanceToPlayer >= detectionRange)
                    {
                        ChangeState(ENEMY_STATE.INSPECT);
                    }
                    break;

                case ENEMY_STATE.ATTACK:
                    AttackPlayer();
                    break;

            }
        }
        public abstract void AttackPlayer();

        public abstract void ChasePlayer(Transform player);

        public abstract void Inspect();

        public abstract void Petrol();
        public abstract void FollowPath();
        public abstract void TakeDamage(int value);
    }
}
