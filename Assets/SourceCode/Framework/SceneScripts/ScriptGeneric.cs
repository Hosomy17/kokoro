using UnityEngine;
using System.Collections;

public class ScriptGeneric : MonoBehaviour
{

    private GameManagerGeneric gameManager;

	void Awake ()
    {
        gameManager = GameManagerGeneric.Instance;
	}
}
