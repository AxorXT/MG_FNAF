using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Funcion para salir del juego
    public void ExitGame()
    {
        Application.Quit();
    }

    //Funcion para cargar una escena especifica
    public void LoadScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }

    //Funcion para recargar la escena actual

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
