using UnityEngine;
using UnityEngine.InputSystem; 

public class movimientodeljugador : MonoBehaviour
{
    public Vector2 entrada;
    public Rigidbody2D rb;
    public float velocidad = 5f;
    private Animator animator;
    public GameObject trigoPreFab;
    public GameObject jitomatePrefab;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = velocidad * entrada;
        
            
    }


    public void  Movimiento(InputAction.CallbackContext contexto){

        Vector2 valorEntrada = contexto.ReadValue<Vector2>();

         animator.SetBool("estaCaminando", true);

        // Determinar el eje dominante
        if (Mathf.Abs(valorEntrada.x) > Mathf.Abs(valorEntrada.y))
        {
            // Movimiento horizontal
            entrada = new Vector2(Mathf.Sign(valorEntrada.x), 0);
        }
        else if (Mathf.Abs(valorEntrada.y) > 0)
        {
            // Movimiento vertical
            entrada = new Vector2(0, Mathf.Sign(valorEntrada.y));
        }
        else
        {
            entrada = Vector2.zero;
        }
        //asignar valores a los parametros entradaX y entradaY
        animator.SetFloat("entradaX", entrada.x);
        animator.SetFloat("entradaY", entrada.y);

        if (contexto.canceled) {
            animator.SetBool("estaCaminando", false);

        }
    }
    public void ColocarTrigo(InputAction.CallbackContext contexto){
        if (contexto.started){
            Instantiate(trigoPreFab, transform.position , Quaternion.identity);
        }


    }

    public void Colocarjitomate(InputAction.CallbackContext contexto)
    {
        if (contexto.started)
        {
            Instantiate(jitomatePrefab, transform.position, Quaternion.identity);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Nido"))
        {
            Destroy(collision.gameObject);
            GameManager.instancia.agregarhuevo();
        }
        else if (collision.CompareTag("Trigo"))
        {
            Destroy(collision.gameObject);
            GameManager.instancia.agregartrigo();
        }
    }
}
  

    
