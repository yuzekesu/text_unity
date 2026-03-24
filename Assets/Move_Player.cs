using UnityEngine;
using UnityEngine.InputSystem;

public class Move_Player : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public uint movementSpeed;
    public InputAction keyboard;
    public InputAction mouse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keyboard.Enable();
        mouse.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Handle_Keyboard();
        Handle_Mouse();


    }
    void Handle_Mouse()
    {
        Vector2 screenPos = mouse.ReadValue<Vector2>();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector2 objectPos = gameObject.transform.position;
        Vector2 value = worldPos - objectPos;
        rigidbody.rotation = Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg;
    }
    void Handle_Keyboard ()
    {
        if (keyboard.IsPressed())
        {
            Vector2 value = keyboard.ReadValue<Vector2>();
            rigidbody.linearVelocity = value * movementSpeed;
        }
        else
        {
            rigidbody.linearVelocity = Vector2.zero;
        }
    }
}
