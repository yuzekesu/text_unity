using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Projectile_Bullet : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public uint movementSpeed;
    public float existTime;
    float rotation;
    Vector2 velocity;
    float time;
    Vector2 mouseScreenPos;

    public void Initialize(Vector3 position, Vector2 mouseScreenPos)
    {
        gameObject.transform.position = position;
        this.mouseScreenPos = mouseScreenPos;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 objectPos = gameObject.transform.position;
        Vector2 value = mouseWorldPos - objectPos;
        rotation = Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg;
        rigidbody.rotation = rotation;
        velocity = Vector2.Normalize(value);
        time =  Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float rand = Random.Range(0.3f, 1f);
        if (Time.time - time < existTime * rand)
        {
            rigidbody.linearVelocity = velocity * movementSpeed;
        }
        else
        {
            time = Time.time;
            Destroy(gameObject);
        }
    }
}
