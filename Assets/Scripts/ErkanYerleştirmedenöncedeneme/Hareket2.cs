
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
        // sa� sol hareket
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // z�plama
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        // geri sarma
        if (Input.GetButtonDown("GeriD�n��"))
        {
            transform.position = previousPosition;
        }

        // Karakterin y�r�me y�n�ne d�nmesi
        if (move < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // Karakteri sola d�nd�rme
        }
        else if (move > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // Karakteri sa�a d�nd�rme
        }
    }

    // yerde mi de�il mi kontrol ama�l�
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    // 3 saniye �nceki yeri sayar
    IEnumerator RecordPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            previousPosition = transform.position;
        }
    }
}
