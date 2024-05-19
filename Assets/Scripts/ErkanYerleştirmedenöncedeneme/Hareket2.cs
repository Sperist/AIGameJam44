
using UnityEngine;
using System.Collections;

public class hareket2 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private Vector3 previousPosition;
    private float timer = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousPosition = transform.position;
        StartCoroutine(RecordPosition());
    }

    void Update()
    {
        // sað sol hareket
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // zýplama
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        // geri sarma
        if (Input.GetButtonDown("GeriDönüþ"))
        {
            transform.position = previousPosition;
        }

        // Karakterin yürüme yönüne dönmesi
        if (move < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // Karakteri sola döndürme
        }
        else if (move > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // Karakteri saða döndürme
        }
    }

    // yerde mi deðil mi kontrol amaçlý
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    // 3 saniye önceki yeri sayar
    IEnumerator RecordPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            previousPosition = transform.position;
        }
    }
}
