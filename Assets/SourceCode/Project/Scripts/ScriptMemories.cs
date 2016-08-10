using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScriptMemories : ScriptGeneric
{
    public GameObject maze;
    public float velocity;
    private bool endChapter;

    private GameObject sound;
    private AudioSource music;
    void Start()
    {
        endChapter = true;
        sound = GameObject.Find("Kokoro Music");
        music = sound.GetComponent<AudioSource>();

        GetComponent<Gamepad>().controller = new ControllerKokoro();
        maze.GetComponent<Rigidbody2D>().velocity = Vector2.down * velocity;

        Invoke("Hurry", 3f);
    }

    void Update()
    {
        if (endChapter && music.time >= 194)
            NextScene();
    }

    private void Hurry()
    {
        maze.GetComponent<Rigidbody2D>().velocity = Vector2.down * (velocity * 1.4f);
    }

    public void NextScene()
    {
        endChapter = false;
        if (true)
            SceneManager.LoadScene("Regrets - Tutorial");
        else
        {
            Destroy(sound);
            SceneManager.LoadScene("Choises - Tutorial");
        }
    }

}
