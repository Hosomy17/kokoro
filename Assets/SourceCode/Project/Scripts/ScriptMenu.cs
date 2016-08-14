using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScriptMenu : ScriptGeneric
{
    void Start()
    {
        Screen.SetResolution(300, 500, true);
    }
    public void Play()
    {
        SceneManager.LoadScene("Choises - Tutorial");
    }

    public void Quit()  
    {
        Application.Quit();
    }
}
