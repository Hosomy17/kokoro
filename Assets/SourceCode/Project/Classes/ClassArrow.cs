using UnityEngine;
using System.Collections;

public class ClassArrow : ClassGeneric
{
    public void Turn()
    {
        if (gameObject.transform.eulerAngles.z == 0)
            BehaviourAnimation.Play(gameObject, "TurnDown");
        else
            BehaviourAnimation.Play(gameObject, "TurnUp");
    }
}
