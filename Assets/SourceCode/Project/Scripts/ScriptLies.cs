using UnityEngine;
using System.Collections;

public class ScriptLies : ScriptGeneric
{

	
	void Start ()
    {
        GetComponent<Gamepad>().controller = new ControllerKokoro();
	}
}
