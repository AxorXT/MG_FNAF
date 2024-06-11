using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public void Interaction()
    {
        //si presiono clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            //creamos un rayo desde la camara hacia la posicion del cursor
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if(Physics.Raycast(ray, out _hit, 100))
            {
                //si el objeto tiene el componente de interaccion
                if(_hit.transform.gameObject.GetComponent<InteractableObject>() != null)
                {
                    //interactuamos con el objeto
                    _hit.transform.gameObject.GetComponent<InteractableObject>().Interact();
                }
            }
        }
    }
}
