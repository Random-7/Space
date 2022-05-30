using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public static  SceneControl sceneControl;
    void Awake()
    {
        if (sceneControl == null)
            sceneControl = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
