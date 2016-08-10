using UnityEngine;
using System.Collections;

public class ClassShield : ClassGeneric
{
    public ScriptThrills scriptThrills;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "Saw")
        {
            scriptThrills.AddHp(0.02f);
        }
    }
}
