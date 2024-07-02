using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    //variables publicas
    public float rotationLimit, rotationSpeed;

    //variables privadas
    private float originalYRotation, yRotation;
    private float orientation;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de variables
        originalYRotation = transform.localEulerAngles.y;
        yRotation = transform.localEulerAngles.y;
        orientation = 1;

    }



    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
    //Funcion para rotar
    void Rotation()
    {
        //
        if((transform.localEulerAngles.y <= originalYRotation - rotationLimit) || (transform.localEulerAngles.y >= originalYRotation + rotationLimit))
        {
            ChangeRotation();
        }

        //Rotamos
        yRotation += rotationSpeed * orientation * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, yRotation, transform.localEulerAngles.z);
    }

    void ChangeRotation()
    {
        orientation += -1;
    }
}
