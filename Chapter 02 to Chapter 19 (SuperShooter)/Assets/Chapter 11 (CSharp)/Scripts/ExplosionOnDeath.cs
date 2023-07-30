   
    using UnityEngine;

    public class ExplosionOnDeath : MonoBehaviour
    {
        public GameObject particlePrefab;
            
        void Awake()
        {
            var life = GetComponent<Life_Chapter8>();
            life.onDeath.AddListener(OnDeath);
        }

        void OnDeath()
        {
            Instantiate(particlePrefab, transform.position, transform.rotation);
        }
    }
    
    
    