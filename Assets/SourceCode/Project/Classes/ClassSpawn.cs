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
        GameObject obj = GameObject.Instantiate(spawned);
        obj.transform.position = transform.position;
        Destroy(gameObject);
    }
}
