using UnityEngine;
using System.Collections;

public class geridönüşDeneme : MonoBehaviour
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
        // sağ sol hareket
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // zıplama
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        // geri sarma
        if (Input.GetButtonDown("GeriDönüş"))
        {
            transform.position = previousPosition;
        }
    }

    // yerde mi değil mi kontrol amaçlı
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
