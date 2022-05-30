using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNav : MonoBehaviour
{
    [SerializeField] SceneControl sceneControl;
    public void ButtonClicked(int i)
    {
        sceneControl.LoadScene(i);
    }
    
    public void Exit()
    {
        print("exit");
    }
}
