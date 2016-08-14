using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScriptEnd : ScriptGeneric
{
    public ParticleSystem particleSystem;
    public GameObject kokoro;
    public GameObject dreams;
    
    void Start()
    {
        GetComponent<Gamepad>().controller = new ControllerKokoro();
        Invoke("NextScene", 50f);
    }

    void Update()
    {
        var distance = Vector2.Distance(kokoro.transform.position, dreams.transform.position) / 5000;
        distance += 0.1f;
        if (distance > 1f)
            distance = 1f;

        var shape = particleSystem.shape;
        shape.radius = distance * 100;
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Bad End");
    }
}
