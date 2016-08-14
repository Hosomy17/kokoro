using UnityEngine;
using System.Collections;

public class ScriptGameOver : ScriptTutorial
{
    void Awake()
    {
        var sound = GameObject.Find("Kokoro Music");
        Destroy(sound);
    }
}
