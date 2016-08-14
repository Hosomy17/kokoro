using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScriptThrills : ScriptGeneric
{
    public GameObject keys;
    public Image hp;
    public GameObject effectSpawn;
    public List<Vector2> positions;

    private bool endChapter;

    private GameObject sound;
    private AudioSource music;

	void Start ()
    {
        endChapter = true;
        sound = GameObject.Find("Kokoro Music");
        music = sound.GetComponent<AudioSource>();

        GetComponent<Gamepad>().controller = new ControllerKeys();
        positions.Add(new Vector2(1f, 0.5f));
        positions.Add(new Vector2(0f, 0.5f));
        positions.Add(new Vector2(0.5f, 1f));
        positions.Add(new Vector2(0.5f, 0f));

        InvokeRepeating("SpawnSaw", 0f, 1f);
        InvokeRepeating("SpawnSaw", 23.5f, 1f);
        InvokeRepeating("SpawnSaw", 33.3f, 1f);

    }
	
	void Update ()
    {
        if (endChapter && music.time >= 250)
            NextScene();
    }

    public void AddHp(float point)
    {
        float total = hp.fillAmount;
        total += point;
        if (total > 1)
            total = 1;
        if(total < 0)
            total = 0;
        hp.fillAmount = total;

        if(hp.fillAmount <= 0)
            SceneManager.LoadScene("Game Over");
    }

    public void SpawnSaw()
    {
        int r = Random.Range(0, 4);
        Vector2 pos = positions[r];
        Vector2 posScr = Camera.main.ViewportToWorldPoint(pos);
        GameObject.Instantiate(effectSpawn, posScr, Quaternion.identity);
    }

    public void NextScene()
    {
        endChapter = false;
        if (true)
            SceneManager.LoadScene("End");
        else
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
