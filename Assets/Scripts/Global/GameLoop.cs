using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLoop : MonoBehaviour
{
    /*
    [SerializeField] List<Level> allLevels = new List<Level>();
    [SerializeField] Level currentLevel;

    public static event Action<string> OnIncident;

    [SerializeField] private IncidentController[] allIncidentControllers;
    public Incident currentIncident;
    public float waveSpeed;
    public int waveIndex;
    public float wave=0;
    public float waveIncrement;

    public static event Action OnWaveStart;

    public void BeginGameLoop()
    {
        waveIndex = 0;
        wave = 0;
        allIncidentControllers = FindObjectsOfType<IncidentController>();
        currentLevel = allLevels[0];
        if (currentLevel.mandatoryDeck != null) currentLevel.mandatoryDeck.Init();
        if (currentLevel.randomDeck != null) currentLevel.randomDeck.Init();
        nextIncident();
        StartCoroutine(ProcessWave());
    }

    

    IEnumerator ProcessWave()
    {
        
        while (waveIndex<7)
        {
            if (GameManager.Instance != null)
            {
                if (!GameManager.Instance.isPaused)
                {
                    wave += waveIncrement * Time.deltaTime;
                    GameManager.Instance.WaveStatus = wave;
                    if (wave > 100)
                    {
                        OnWaveStart?.Invoke();
                        wave = 0;
                        waveIndex++;

                        if (waveIndex == 6)
                        {
                            //boss wave
                        }
                      
                    }
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }


    public void nextIncident()
    {
        //check for mandatory Incidents
        Incident _incident = currentLevel.mandatoryDeck.nextIncident();
        if (_incident == null)
        {
            //try other deck
            currentIncident = _incident;
        }
        else
        {
            currentIncident = _incident;
            //List<IncidentController> targets = new List<IncidentController>();
            foreach (Effects iEffect in _incident.Effects)
            {
                for(int index =0; index < iEffect.Target.Count; index++)
                {
                    //try to grab from scene
                    foreach (IncidentController IC in allIncidentControllers)
                    {

                        
                            if (IC.name == iEffect.Target[index])
                            {

                                GameObject p = Instantiate(iEffect.IAction[index]);
                                p.transform.SetParent(IC.transform);

                            }
                        


                    }
                }
                
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
