using UnityEngine;
using UnityEngine.Events;

public class Life_Chapter8 : MonoBehaviour
{
    public float amount;
    public UnityEvent onDeath;

    void Update()
    {
        if (amount <= 0)
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
}