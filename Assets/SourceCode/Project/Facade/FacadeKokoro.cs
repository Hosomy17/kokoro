using UnityEngine;
using System.Collections;

public static class FacadeKokoro
{
    public static void Move(ClassKokoro classKokoro, Vector2 directions)
    {
        BehaviourPhysics.Move(classKokoro.gameObject, directions, classKokoro.speed);
    }

    public static void Idle(ClassGeneric classKokoro, Vector2 directions)
    {
        BehaviourPhysics.Move(classKokoro.gameObject, directions, 0);
    }
}
