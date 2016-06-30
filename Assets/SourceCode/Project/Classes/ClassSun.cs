using UnityEngine;
using System.Collections;

public class ClassSun : ClassGeneric
{
    private AudioClip sfx;

    void Start()
    {
        sfx = Resources.Load("Sounds\\SFX\\Coin") as AudioClip;
    }

    public void Kill()
    {
        BehaviourSound.Play(gameObject, sfx);
        gameObject.Recycle();
    }

    void OnEnable()
    {
        Invoke("Kill", 9f);
    }

    void OnDisable()
    {
        CancelInvoke("Kill");
    }
}
