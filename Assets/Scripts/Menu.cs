using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{  
    public void ChangeScene(int SceneChangeNum)
    {
        SceneManager.LoadScene(SceneChangeNum);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
