using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    //variables publicas
    public UnityEvent OnInteract;

    //Funcion de Interaccion
    public void Interact()
    {
        //activar el evento
        OnInteract.Invoke();
    }
}
