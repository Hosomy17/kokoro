using UnityEngine;
using System.Collections;

public class ClassKokoro : ClassGeneric
{
    public float speed;

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "Sun")
        {
            GameObject.Find("GameManager").GetComponent<ScriptChoises>().GivePoint();
            c.gameObject.GetComponent<ClassSun>().Kill();
        }
    }
}
