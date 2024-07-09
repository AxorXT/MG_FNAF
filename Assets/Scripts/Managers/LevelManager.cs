using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    //variables publicas
    public int numHours, secPerHour;
    public Text timerText;
    public GameObject losePanel;

    public UnityEvent GameOver, Win, Lose;

    //variables privadas
    private int time;

    //singleton
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de variables
        time = 0;
        timerText.text = time + ":00";
        InvokeRepeating("UpdateTime", secPerHour, secPerHour);
    }

    //funcion para cambiar la hora
    void UpdateTime()
    {
        time++;
        timerText.text = time + ":00";
        if(time == 6)
        {
            GameOver.Invoke();
            Win.Invoke();
        }
    }

    public void PlayerDead()
    {
        StartCoroutine(JumpscareCoroutine());
    }

    //Corrutina para perder (jumpscare)
    IEnumerator JumpscareCoroutine()
    {
        GameOver.Invoke();
        Lose.Invoke();
        yield return new WaitForSeconds(1.5f);
        losePanel.SetActive(true);
    }
}
