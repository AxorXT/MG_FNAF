using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatronico : MonoBehaviour
{
    //variables publicas
    public float timeToMove, probabilityOfMoving;
    public Transform[] position;
    public Door door;

    public GameObject jumpscareMesh;

    //variables privadas
    private int positionIndex;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de variables
        positionIndex = 0;
        StartCoroutine(MovementCoroutine(Random.Range(timeToMove - 5f, timeToMove + 5f)));
    }

    //funcion de movimiento
    void Move()
    {
        //Calcular la probabilidad para moverse
        if (Random.Range(0f, 100f) <= probabilityOfMoving)
        {
            //verificamos si estamos en la puerta
            if (positionIndex == position.Length - 1)
            {
                //verificamos que la puerta este abierta
                if (door == null || door.IsOpen())
                {
                    //Atacamos
                    StopAllCoroutines();
                    attack();
                    return;
                }
                else
                {
                    //Nos regresamos al inicio
                    positionIndex = 0;
                    transform.position = position[positionIndex].position;
                    transform.rotation = position[positionIndex].rotation;
                }
            }
            //si aun no estamos en la puerta
            else
            {
                //Nos moveremos a la siguiente posicion
                positionIndex++;
                transform.position = position[positionIndex].position;
                transform.rotation = position[positionIndex].rotation;
            }
        }
        //Iniciamos la corrutina para el siguiente movimiento
        StartCoroutine(MovementCoroutine(Random.Range(timeToMove - 5f, timeToMove + 5f)));
    }

    //funcion para atacar
    public void attack()
    {
        jumpscareMesh.SetActive(true);
        LevelManager.Instance.PlayerDead();
    }

    //Corrutina de movimiento
    IEnumerator MovementCoroutine(float _time)
    {
        //Esperamos el tiempo para hacer movimiento
        yield return new WaitForSeconds(_time);

        //Intentamos movernos
        Move();
    }
}
