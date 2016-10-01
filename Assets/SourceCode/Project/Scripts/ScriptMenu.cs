using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScriptMenu : ScriptGeneric
{
    private int flagFull;
    void Start()
    {
        flagFull = PlayerPrefs.GetInt("FullScreen", -1);
        if (flagFull == 1)
            Screen.SetResolution(300, 500, true);
        else
            Screen.SetResolution(300, 500, false);
    }
    public void Play()
    {
        SceneManager.LoadScene("Choises - Tutorial");
    }

    public void Quit()  
    {
        Application.Quit();
    }

    public void ChangeFull()
    {
        Debug.Log(flagFull);
        flagFull *= -1;

        if (flagFull == 1)
            Screen.SetResolution(300, 500, true);
        else
            Screen.SetResolution(300, 500, false);

        PlayerPrefs.SetInt("FullScreen", flagFull);
    }
}
