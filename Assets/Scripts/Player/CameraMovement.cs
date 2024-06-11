using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //variables publicas
    public float rotationSpeed, yMinRotation, yMaxRotation;

    //variables privadas
    private float yRotation;

    //funcion para mover la camara
    public void CameraRotation()
    {
        //verificamos si el cursor esta en alguno de los bordes (izq o der)
        //derecha
        if (Input.mousePosition.x >= Screen.width * 0.95f)
        {
            yRotation += rotationSpeed * Time.deltaTime;
        }
        //izquierda
        else if (Input.mousePosition.x <= Screen.width * 0.05f)
        {
            yRotation -= rotationSpeed * Time.deltaTime;
        }

        //Aplicamos angulo de rotacion
        yRotation = Mathf.Clamp(yRotation, yMinRotation, yMaxRotation);
        Camera.main.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
