using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public float fireRate;
    public GameObject bullet;
    public InputAction mousePress;
    public InputAction mousePos;
    float lastFire = 0;
    Transform parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePress.Enable();
        mousePos.Enable();
        parent = transform.parent;
        transform.position = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (mousePress.IsPressed())
        {
            if (Time.time > lastFire + 1f/fireRate)
            {
                lastFire = Time.time;
                GameObject newBullet = Instantiate(bullet);
                Projectile_Bullet bulletScript = newBullet.GetComponent<Projectile_Bullet>();
                Vector2 mouseScreenPos = mousePos.ReadValue<Vector2>();
                int randomX = Random.Range(-100, 100);  // 0 to 9
                int randomY = Random.Range(-100, 100);  // 5 to 14
                mouseScreenPos.x += randomX;
                mouseScreenPos.y += randomY;
                bulletScript.Initialize(parent.transform.position, mouseScreenPos);
            }
        }
    }
}
