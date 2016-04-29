using UnityEngine;
using System.Collections;

public class ClassBlock : ClassGeneric
{
    void OnTriggerEnter2D(Collider2D c)
    {
        GameObject.Find("GameManager").GetComponent<ScriptLies>().CollisionBlock(gameObject.name);
    }
}
