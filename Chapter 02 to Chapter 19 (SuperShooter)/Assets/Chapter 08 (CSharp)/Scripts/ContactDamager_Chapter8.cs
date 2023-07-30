using UnityEngine;

public class ContactDamager_Chapter8 : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        Life_Chapter8 life = other.GetComponent<Life_Chapter8>();
        if (life != null)
        {
            life.amount -= damage;
        }
    }
}