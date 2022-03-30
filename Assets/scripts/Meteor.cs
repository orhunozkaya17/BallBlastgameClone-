using UnityEngine;
using TMPro;
public class Meteor : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int health;
    [SerializeField] float jumpForce;
    [SerializeField] TMP_Text textHealth;
    float[] leftAndRight = new float[2] { -1f,1f};
    bool issShowing;
   
    void Start()
    {
        issShowing = true;
        rb.gravityScale = 0;
        updateHealthUI();
        float direction = leftAndRight[Random.Range(0, 2)];
        float screenOffSet = Game.Instance.screenWitdht*1.3f;

        transform.position = new Vector2(screenOffSet * direction, transform.position.y);
        rb.velocity = new Vector2(-direction , 0);
        Invoke("fallDown",Random.Range(screenOffSet-2.5f,screenOffSet-1f));
    }
    void fallDown()
    {
        issShowing = false;
        rb.gravityScale = 1;
        rb.AddTorque(Random.Range(-20f, 20f));
    }
    public void TakeDamage(int damage)
    {
        if (health > 1)
        {
            health -= damage;
        }
        else
        {
            Die();
        }
        updateHealthUI();
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public void updateHealthUI()
    {
        textHealth.text = health.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cannon"))
        {
            Debug.Log("gameover");
        }
        else if (collision.CompareTag("missile"))
        {
            TakeDamage(1);
            Misslies.instance.DespawnMissile(collision.gameObject);
        }
        else if (!issShowing &&collision.CompareTag("wall"))
        {
            float posX = transform.position.x;
            if (posX > 0)
            {
                rb.AddForce(Vector2.left * 150f);
            }
            else
            {
                rb.AddForce(Vector2.right * 150f);
            }
            rb.AddTorque(posX*4f);
        }
        else if (collision.CompareTag("ground"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.AddTorque(-rb.angularVelocity * 4f);
        }
    }
}
