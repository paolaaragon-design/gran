using UnityEngine;
using UnityEngine.UIElements;

public class inventariocontrollerUI : MonoBehaviour
{
    private Label labelhuevos;
    private int huevosprevios = -1;

    void OnEnable(){
        var root = GetComponent<UIDocument>().rootVisualElement;
        labelhuevos = root.Q<Label>("labelHuevos");


    }
   
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instancia.contarhuevo != huevosprevios){
            huevosprevios = GameManager.instancia.contarhuevo;
        labelhuevos.text = $"Huevos: {huevosprevios}";
        }
    }
}
