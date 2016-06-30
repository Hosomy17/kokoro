using UnityEngine;
using System.Collections;

public class ClassSaw : ClassGeneric
{
    public float speed;
    public GameObject effectDestroy;
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("Kokoro");

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        GameObject obj = GameObject.Instantiate(effectDestroy);
        obj.transform.position = gameObject.transform.position;
        gameObject.Recycle();
    }

    void OnEnable()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}