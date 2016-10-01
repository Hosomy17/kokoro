using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ClassKokoro : ClassGeneric
{
    public float speed;
    private GameObject gameManager;
    public Image hp;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "Sun")
        {
            gameManager.GetComponent<ScriptChoises>().GivePoint();
            c.gameObject.GetComponent<ClassSun>().Kill();
        }
        else if(c.gameObject.name == "Saw")
        {
            gameManager.GetComponent<ScriptChoises>().LosePoint();
        }
        else if(c.gameObject.name == "Dreams")
        {
            SceneManager.LoadScene("Happy End");
        }
        else if(c.gameObject.name == "Death1")
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Check Point", "Moments - Tutorial");
            GameManagerGeneric.Instance.SaveInfo(d);
            SceneManager.LoadScene("Game Over");
        }
        else if (c.gameObject.name == "Death2")
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Check Point", "Memories - Tutorial");
            GameManagerGeneric.Instance.SaveInfo(d);
            SceneManager.LoadScene("Game Over");
        }
    }

    void OnCollisionStay2D(Collision2D c)
    {
        if(c.gameObject.name == "Blocks")
        {
            hp.fillAmount -= 0.03f;
        }
        if(c.gameObject.name == "FakeBlocks")
        {
            hp.fillAmount += 0.005f;
        }
    }
}
