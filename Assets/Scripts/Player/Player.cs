using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables privadas
    private CameraMovement cameraMovement;
    private Interactor interactor;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = GetComponent<CameraMovement>();
        interactor = GetComponent<Interactor>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraMovement.CameraRotation();
        interactor.Interaction();
    }
}
