using UnityEngine;
using System.Collections;

public class ClassEffect : ClassGeneric
{
    void Start()
    {
        Invoke("Kill", 3f);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
