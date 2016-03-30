using UnityEngine;
using System.Collections;

public class ClassSaw : ClassGeneric
{
    public float speed;
    public GameObject effectDestroy;

    void Start()
    {
        GameObject player = GameObject.Find("Kokoro");

        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.name == "Kokoro")
            GameObject.Find("GameManager").GetComponent<ScriptChoises>().LosePoint();

            GameObject obj = GameObject.Instantiate(effectDestroy);
            obj.transform.position = gameObject.transform.position;
            Destroy(gameObject);
    }
}