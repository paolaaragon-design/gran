using UnityEngine;

public class Huevo : MonoBehaviour
{
    public GameObject huevo;
    public float intervalo = 10f;
    void Start()
    {
        InvokeRepeating(nameof(colocarHuevo), intervalo, intervalo);
    }
  
    void colocarHuevo(){
        Instantiate(huevo ,transform.position,Quaternion.identity);
    }
}