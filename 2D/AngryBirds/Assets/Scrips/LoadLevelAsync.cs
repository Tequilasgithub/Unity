using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAsync : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(1024,768,false);
        Invoke("Load",3);
    }
    void Load()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
