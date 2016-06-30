using UnityEngine;
using System.Collections;

public class ClassKokoro1 : ClassKokoro
{
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "Sun 1")
        {
            gameManager.GetComponent<ScriptRegrets>().LosePoint();
            c.gameObject.GetComponent<ClassSun>().Kill();
        }
        else if (c.gameObject.name == "Saw")
        {
            gameManager.GetComponent<ScriptRegrets>().GivePoint();
        }
    }
}
