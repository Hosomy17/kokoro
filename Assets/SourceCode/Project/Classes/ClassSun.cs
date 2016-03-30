using UnityEngine;
using System.Collections;

public class ClassSun : ClassGeneric
{
    private AudioClip sfx;

    void Start()
    {
        Invoke("Kill", 9f);
        sfx = Resources.Load("Sounds\\SFX\\Coin") as AudioClip;
    }

     public void Kill()
    {
        BehaviourSound.Play(gameObject, sfx);
        Destroy(gameObject);
    }
}
