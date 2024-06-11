using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonComponent : MonoBehaviour, IInteractable
{
    //variables publicas
    public Material materialOff, materialOn, materialDisable;
    public UnityEvent OnActivated, OnDeactivated;

    //variables privadas
    private bool buttonState;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de variables
        buttonState = false;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = materialOff;
    }

    public void Switch()
    {
        //si el boton esta encendido
        if (buttonState)
        {
            //lo apagamos
            buttonState = false;
            meshRenderer.material = materialOff;
            OnDeactivated.Invoke();
        }
        //si esta apagado
        else
        {
            //lo encendemos
            buttonState = true;
            meshRenderer.material = materialOn;
            OnActivated.Invoke();
        }
    }

    public void Interact()
    {
        Switch();
    }
}
