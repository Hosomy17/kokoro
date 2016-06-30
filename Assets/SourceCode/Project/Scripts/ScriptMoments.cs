using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class ScriptMoments : MonoBehaviour
{
    public GameObject maze;
    public float velocity;

	void Start ()
    {
        GetComponent<Gamepad>().controller = new ControllerKokoro();
        maze.GetComponent<Rigidbody2D>().velocity = Vector2.up * velocity;

        Invoke("Hurry", 12f);

        Invoke("NextScene", 30f);
    }

    private void Hurry()
    {
        maze.GetComponent<Rigidbody2D>().velocity = Vector2.up * (velocity * 1.25f);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Regrets - Tutorial");
    }

}
