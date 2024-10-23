using UnityEngine;
namespace HotlineMiami
{
    public interface IEnemy
    {
        void Petrol();
        void ChasePlayer(Transform player);
        void Inspect();
        void AttackPlayer();
        void TakeDamage(int value);
        void ChangeState(ENEMY_STATE newState);
    }

    public enum ENEMY_STATE { PETROL, INSPECT, CHASE, ATTACK };
}
