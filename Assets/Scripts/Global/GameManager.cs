using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public List<string> Fixes = new List<string>();
    //Events
    public static event Action OnMateriumChange;
    public static event Action OnShipStatusChange;
    public static event Action OnEngineStatusChange;
    public static event Action OnWaveStatusChange;


    public List<Camera> ShipCameras = new List<Camera>();
    public GameLoop GLoop;

    public TMPro.TextMeshProUGUI COMMSYSTEM;

    public bool isPaused = false;
    public GameState state;

    private int _materiumAmount;
    private float _shipStatus;
    private float _engineStatus;
    private float _waveStatus;
    public bool GameOver = false;


    public float ShipStatus
    {
        get { return _shipStatus; }
        set
        {
            if (state != GameState.OffShip)
            {
            }
            _shipStatus = value;

            if(_shipStatus <= 0 && !GameOver)
            {
                GameOver = true;
                //game over man
                LevelManager.Instance.LoadScene("Failure");
                LevelManager.Instance.UnloadScene("Ship_Main");
                LevelManager.Instance.UnloadScene("Off_Ship_v2");
            }

            OnShipStatusChange?.Invoke();
        }
    }

    

    public float EngineStatus
    {
        get { return _engineStatus; }
        set
        {
            _engineStatus = value;
            OnEngineStatusChange?.Invoke();
        }
    }

    public void DestroyGO(float timeToLive, GameObject target){
        StartCoroutine(KillObject(timeToLive, target));
    }

    IEnumerator KillObject(float timeToLive, GameObject go)
    {
        float timeLeft = timeToLive;
        while (timeLeft>0)
        {
            if (!isPaused)
            {
                timeLeft -= Time.deltaTime;
                yield return null;
            }
        }

        Destroy(go);
    }

    public float WaveStatus
    {
        get { return _waveStatus; }
        set
        {
            _waveStatus = value;
            OnWaveStatusChange?.Invoke();
        }
    }

    public int MateriumAmount
    {
        get { return _materiumAmount; }
        set
        {
            _materiumAmount = value;
            OnMateriumChange?.Invoke();
        }
    }


    public enum GameState
    {
        OnShip,
        OffShip,
        Puzzle,
        Menu
    }

    private void Start()
    {
        GLoop = GetComponent<GameLoop>();
       
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
