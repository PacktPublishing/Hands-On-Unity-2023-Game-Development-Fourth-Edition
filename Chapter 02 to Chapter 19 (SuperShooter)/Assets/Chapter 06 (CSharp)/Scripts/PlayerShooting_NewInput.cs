using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting_NewInput : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject clone = Instantiate(prefab);

            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }
    }
}