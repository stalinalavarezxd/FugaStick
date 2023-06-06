using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 4;
    public float jumpForce = 200;
    public int vida=3;
    public int score=0;
    public GameObject Vida;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
            //spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidbody2D.velocity = new Vector2(-runSpeed, rigidbody2D.velocity.y);
            //spriteRenderer.flipX = true;

        }
        else
       if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("itsjumping", true);
            rigidbody2D.AddForce(new Vector2 (0, jumpForce));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            animator.SetBool("itsjumping", false);
          
        }     
       
        
        if (collision.gameObject.tag == "obstaculo" || collision.gameObject.tag=="obstaculo2")
        {
            vida--;
            if (vida <= 0)
            {
                Destroy(Vida);
                Destroy(gameObject);
                gameManager.gameOver = true;
                print("!!PERDISTE!!");
            }
            else
            {
                if (vida <= 2)
                {
                    GameObject vidaObject = GameObject.Find("Vida" + (3 - vida));
                    if (vidaObject != null)
                    {
                        Destroy(vidaObject);
                    }
                }
                else
                {
                    GameObject vidaObject = GameObject.Find("Vida1");
                    if (vidaObject != null)
                    {
                        Destroy(vidaObject);
                    }
                    Debug.Log("Has chocado. Vidas restantes: " + vida);
                }

            }
            // Calcular la dirección del choque
            Vector2 pushDirection = transform.position - collision.transform.position;
            // Normalizar el vector de dirección
            pushDirection.Normalize();
            // Definir la dirección hacia arriba
            Vector2 upwardForce = new Vector2(0, 1);
            // Definir la dirección hacia el lado del choque
            Vector2 sideForce = new Vector2(pushDirection.y, -pushDirection.x);
            // Aplicar la fuerza de empuje
            rigidbody2D.AddForce((upwardForce + sideForce) * jumpForce);
            // Evitar que el personaje se quede atascado en el obstáculo
            rigidbody2D.velocity = Vector2.zero;
            
            if (collision.gameObject.tag == "obstaculo2")
            {
                // Rebote hacia abajo
                rigidbody2D.AddForce(new Vector2(jumpForce, -jumpForce));
            }

        }
        if(collision.gameObject.tag == "moneda")
        {
            score++;
            Destroy(collision.gameObject); // Destruir la moneda
            Debug.Log(score);
        }
        


    }
}
