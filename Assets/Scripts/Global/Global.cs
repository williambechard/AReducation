using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    public static Global Instance;
  
    public List<string> scenesToLoad = new List<string>();

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

    private void Start()
    {
        foreach(string name in scenesToLoad)
        {
            
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        }
    }

}
