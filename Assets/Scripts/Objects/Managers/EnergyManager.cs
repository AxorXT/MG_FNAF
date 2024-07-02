using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class EnergyManager : MonoBehaviour
{
    //Variable publicas
    public float energy, consumptionRate;
    public UnityEvent OnDischarged;

    public Image usageFiller;
    public Text powerleftText;

    //Variables Privadas
    private int consumptionLevel;
    private bool isDischarged; 

    //Singleton
    public static EnergyManager Instance { get; private set; }

    private void Awake()
    {
        //verificacion del single
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
        consumptionLevel = 0;
        isDischarged = false;
        UpdateUi();
    }

    // Update is called once per frame
    void Update()
    {
        //Si no estamos descargados
        if(!isDischarged)
        {
            Consumption();
        }
    }

    //Funcion de consumo de energia
    void Consumption()
    {
        //Si aun tenemos energia
        if(energy > 0f)
        {
            energy -= consumptionRate * consumptionLevel * Time.deltaTime;
            UpdateUi();
        }
        //sI YA NO TENEMOS ENERGIA
        else
        {
            UpdateUi();
            isDischarged=true;
            OnDischarged.Invoke();
        }
    }

    //Funcion para aumentar el nivel de consumo
    public void IncreaseConsumptionLevel()
    {
        consumptionLevel++;
    }

    public void DecreaseConsumptionLevel()
    {
        consumptionLevel--;
    }
    void UpdateUi()
    {
        powerleftText.text = (int)energy + "%";
        usageFiller.fillAmount = consumptionLevel / 5f;
    }
}
