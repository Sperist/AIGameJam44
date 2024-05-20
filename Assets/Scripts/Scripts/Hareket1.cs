using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class hareket1 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private Vector3 previousPosition;
    private float timer = 3f;
    private bool sagabak = true;
    private Vector3 scale;
    Animator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        previousPosition = transform.position;
        StartCoroutine(RecordPosition());
    }

    void Update()
    {
        // sağ sol hareket
        float move = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("Speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (move>0 && sagabak == false)
        {
            cevir();
        }
        if (move<0 && sagabak==true)
        {
            cevir();
        }

        // zıplama
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            playerAnimator.SetBool("Jump", true);
        }
        if (Mathf.Approximately(rb.velocity.y,0)&&playerAnimator.GetBool("Jump"))
        {
            playerAnimator.SetBool("Jump", false);
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

    void cevir()
    {
        sagabak = !sagabak;
        scale= gameObject.transform.localScale;
        scale.x = scale.x* -1;
        gameObject.transform.localScale = scale;
    }
}
