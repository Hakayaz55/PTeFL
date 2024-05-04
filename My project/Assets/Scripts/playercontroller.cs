using UnityEngine;

public class mainplayercontroler : MonoBehaviour
{
    public Animator animator; // Karakterin Animator bileşeni
    private Rigidbody2D rb; // Karakterin Rigidbody2D bileşeni
    private Vector3 velocity;
    private float speedAmount = 5f;
    private float jumpForce = 7f; // Zıplama gücü

    void Start()
    {
        // Rigidbody2D bileşenini alıyoruz
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Hareket kontrolü için kullanıcı girdilerini alıyoruz
        float moveHorizontal = Input.GetAxis("Horizontal");
        velocity = new Vector3(moveHorizontal, 0f, 0f);
        
        // Hareketi karakterin pozisyonuna uyguluyoruz
        transform.position += velocity * speedAmount * Time.deltaTime;
        
        // Hız değişkenini animatöre ayarlıyoruz
        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));

        // Karakterin yönünü kontrol ediyoruz
        if (moveHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (moveHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        // Zıplama kontrolü
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Karakterin hareket edip etmediğini kontrol ediyoruz
        if (Mathf.Abs(moveHorizontal) > 0)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }
    
    public bool canAttack()
    {
        return horizontalInput == 0 ();
    }
}
