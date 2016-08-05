using UnityEngine;
using System.Collections;
using System;

public class ClassBlock : ClassGeneric
{
    void OnTriggerEnter2D(Collider2D c)
    {
        try
        {
            GameObject.Find("GameManager").GetComponent<ScriptObeesessions>().CollisionBlock(gameObject.name);
        }
        catch (Exception e)
        {
            //Debug.LogException(e);
        }

        try
        {
            GameObject.Find("GameManager").GetComponent<ScriptLies>().CollisionBlock(gameObject.name);
        }
        catch (Exception e)
        {
            //Debug.LogException(e);
        }
    }
}
