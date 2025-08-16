using UnityEngine;

public class movimiientodelazona : MonoBehaviour
{
    public Transform areaMovimiento;
    public float velocidad = 1f;
    public Vector2 destino;
    public SpriteRenderer sr;
    public Vector2 posicioninicial;

        

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        NuevoDestino();
        posicioninicial = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
       
        
        Vector2 direccion = posicioninicial - destino;
        


        if (direccion.x >= 0){
            sr.flipX = true; 
        }else{
            sr.flipX = false; 
        }
        if (Vector2.Distance(transform.position, destino) < 0.1f){ 
        NuevoDestino();
        posicioninicial = transform.position;


        }
    }
       

    void NuevoDestino(){
        Vector2 centro = areaMovimiento.position;
        Vector2 tamano = areaMovimiento.localScale;
        float x = Random.Range(centro.x - tamano.x / 2f, centro.x + tamano.x / 2f);
        float y = Random.Range(centro.y - tamano.y / 2f, centro.y + tamano.y / 2f);

        destino = new Vector2(x, y);


    }
}
