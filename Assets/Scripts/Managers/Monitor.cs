using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    //VARIABLES PUBLICAS
    public GameObject camerasPanel;
    public GameObject[] cameras;

    public AudioSource monitorAS, buttonAS;

    //variables privadas
    private int currentCamera;

    public static Monitor Instance {get; private set;}

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
        currentCamera = 0;
    }

    public void EnableCamera(int _index)
    {
        cameras[currentCamera].SetActive(false);
        cameras[_index].SetActive(true);
        currentCamera = _index;
        buttonAS.Play();
    }

    public void SetIsActive(bool _state)
    {
        cameras[currentCamera].SetActive(_state);
        camerasPanel.SetActive(_state);
        if (_state)
        {
            monitorAS.Play();
            EnergyManager.Instance.IncreaseConsumptionLevel();
        }
        else
        {
            monitorAS.Stop();
            EnergyManager.Instance.DecreaseConsumptionLevel();
        }
    }
}
