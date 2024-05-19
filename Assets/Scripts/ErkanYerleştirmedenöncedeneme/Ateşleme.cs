
using UnityEngine;

public class ateşleme1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed = 10f; // Burada mermi hızını tanımlıyoruz.

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;
            Fire(direction);
        }
    }

    private void Fire(Vector2 directionToMouse)
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            Quaternion.Euler(0, 0, Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg)
        );
        bullet.GetComponent<Rigidbody2D>().velocity = directionToMouse * speed;
        Destroy(bullet, 2.0f);
    }
}
