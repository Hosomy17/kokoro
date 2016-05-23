using UnityEngine;
using System.Collections;

public class ScriptMoments : MonoBehaviour
{
    public GameObject maze;
    public float velocity;
	void Start ()
    {
        GetComponent<Gamepad>().controller = new ControllerKokoro();
        maze.GetComponent<Rigidbody2D>().velocity = Vector2.up * velocity;

    }

}
