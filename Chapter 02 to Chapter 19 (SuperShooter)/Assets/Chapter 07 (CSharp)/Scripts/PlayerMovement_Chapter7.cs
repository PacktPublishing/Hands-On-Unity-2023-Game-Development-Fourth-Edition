using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement_Chapter7 : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    
    private Vector2 movementValue;
    private float lookValue;
    private Rigidbody rb;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }
    
    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>() * speed;
    }

    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }
        
    void Update()
    {
        rb.AddRelativeForce(
            movementValue.x * Time.deltaTime,
            0,
            movementValue.y * Time.deltaTime);
            
        rb.AddRelativeTorque(0, lookValue* Time.deltaTime, 0);
    }
}