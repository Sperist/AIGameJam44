using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float attackRange = 1.5f;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;
    public int attackDamage = 10;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange)
        {
            // Player'a doðru yürüme
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            // Saldýrý
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // Saldýrý animasyonu oynat
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Oyuncuya zarar ver
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
