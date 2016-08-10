using UnityEngine;
using System.Collections;

public static class FacadeKeys
{

    public static void PressDown(ClassKey classKey, string key)
    {
        BehaviourAnimation.Play(classKey.gameObject, key);

        switch(key)
        {
            case "Right":
                MoveShield(classKey, new Vector2(60, 0));
                break;
            case "Left":
                MoveShield(classKey, new Vector2(-60, 0));
                break;
            case "Up":
                MoveShield(classKey, new Vector2(0, 60));
                break;
            case "Down":
                MoveShield(classKey, new Vector2(0,-60));
                break;
            case "Idle":
                MoveShield(classKey, new Vector2(1000, 1000));
                break;
        }
    }

    public static void MoveShield(ClassKey classKey, Vector2 pos)
    {
        classKey.shield.transform.position = pos;
    }

}
