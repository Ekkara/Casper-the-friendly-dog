using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collection : MonoBehaviour
{
    public void ExitApp() {
        Application.Quit();
    }
    public void ChangeSceneFunc(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
