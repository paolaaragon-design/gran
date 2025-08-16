using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int contarhuevo;
    public int contartrigo;

    void Awake(){

        if(instancia == null){
            instancia = this;
        }else{
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
      }

      public void agregarhuevo(){
        contarhuevo++;
        Debug.Log(contarhuevo);
    }
   

    public void agregartrigo()
    {
        contartrigo++;
        Debug.Log(contartrigo);
    }
}
