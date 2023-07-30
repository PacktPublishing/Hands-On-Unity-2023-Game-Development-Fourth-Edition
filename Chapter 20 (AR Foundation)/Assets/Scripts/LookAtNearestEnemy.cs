   

    using UnityEngine;

    public class LookAtNearestEnemy : MonoBehaviour
    {
        void Update()
        {
            if(EnemyManager.instance.all.Count == 0) return;
            
            var nearestEnemy = EnemyManager.instance.all[0];

            for (var i = 1; i < EnemyManager.instance.all.Count; i++)
            {
                var enemy = EnemyManager.instance.all[i];
                var enemyPos = enemy.transform.position;
                var nearEnemyPos = nearestEnemy.transform.position;
                
                var distToNear = Vector3.Distance(nearEnemyPos, transform.position);
                var distToEnemy = Vector3.Distance(enemyPos, transform.position);

                if (distToEnemy < distToNear)
                    nearestEnemy = enemy;
            }

            transform.forward = nearestEnemy.transform.position - transform.position;
        }
    }
    
    
    