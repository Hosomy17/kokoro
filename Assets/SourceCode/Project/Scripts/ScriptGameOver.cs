using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptGameOver : ScriptTutorial
{
    private GameManagerGeneric gm;
    void Awake()
    {
        var sound = GameObject.Find("Kokoro Music");
        Destroy(sound);
        gm = GameManagerGeneric.Instance;
    }

    void Start()
    {
        List<string> keys = new List<string>();
        keys.Add("Check Point");

        Dictionary<string, object> d = new Dictionary<string, object>();
        d = gm.GetInfo(keys);

        string scene = d["Check Point"] as string;
        gm.LoadScene(scene);
    }
}
