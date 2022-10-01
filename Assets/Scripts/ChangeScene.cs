using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void loadScene(int sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void quitScene()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
