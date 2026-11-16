using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    PlayerInput playerInput;

    [SerializeField] float movementForce = 10f;
    [SerializeField] float jumpForce = 5f;


    Vector2 movementInput;
   public bool isGrounded;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        // Modo para evitar colisionar con su collider
        Physics2D.queriesStartInColliders = false;

        isGrounded = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true) 
        {
            Jump(); 
        }

        // movementInput = Input.GetAxis("Horizontal");
        movementInput = playerInput.actions["Move"].ReadValue<Vector2>();   //me va a devolver un vector2 con el input del jugador
        Debug.Log($"Moviendome Update: {movementInput}");
    }

    void Jump()
    {

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }
     void FixedUpdate()
    {


        //Gestionar el isGrounded con un Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red, 0.45f);

        //Debug.Log($"Distance: {hit.distance}");
        if (hit.collider != null && hit.distance < 0.48f && rb.linearVelocityY < 0.01f)
        {
            isGrounded = true;
        }
        //Estamos tocando el suelo






        //Aplicamos la fuerza según el input 
        Debug.Log($"Moviendome: {movementInput}");
        rb.AddForce(Vector2.right * movementInput.x *  movementForce);  
    }



}
