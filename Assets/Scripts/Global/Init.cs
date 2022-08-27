using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    public List<string> MandatoryScenesToLoad = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        //load up Master if it isnt already loaded
        if (!SceneManager.GetSceneByName("Global").IsValid())
            SceneManager.LoadSceneAsync("Global", LoadSceneMode.Additive);

        foreach(string s in MandatoryScenesToLoad)
        {
            if (!SceneManager.GetSceneByName(s).IsValid())
                SceneManager.LoadSceneAsync(s, LoadSceneMode.Additive);
        }
        
    }

    public void loadScene(string name) => LevelManager.Instance.LoadScene(name);
    

    public void loadSceneAdditive(string name) => LevelManager.Instance.LoadSceneAdditive(name);
    

   
}
