using UnityEngine;
using System.Collections;

public class ClassSpawn : ClassGeneric
{
    public GameObject spawned;
    void Start()
    {
        Invoke("Spawn",1f);
    }

    private void Spawn()
    {
        GameObject obj = spawned.Spawn(transform.position);
        obj.name = "Saw";
        Destroy(gameObject);
    }
}
