using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScriptChoises : ScriptGeneric
{
    public GameObject points;
    public GameObject effectSpawn;
    public GameObject sun;
    public GameObject sound;

    private bool endChapter;

    private AudioSource music;

    public int toltalPoints = 0;

    void Start()
    {
        endChapter = true;
        GetComponent<Gamepad>().controller = new ControllerKokoro();
        GameObject obj = Resources.Load("Numbers/Numbers_"+toltalPoints) as GameObject;
        obj = GameObject.Instantiate(obj);
        obj.transform.position = points.transform.position;
        Destroy(points);
        points = obj;

        Invoke("SpawnSaw",9f);
        Invoke("SpawnSun", 3f);
        Invoke("SpawnSun", 10f);

        Invoke("SpawnSaw", 40f);
        Invoke("SpawnSaw", 40.25f);
        Invoke("SpawnSaw", 40.5f);
        Invoke("SpawnSaw", 40.75f);
        Invoke("SpawnSaw", 41f);

        Invoke("SpawnSaw", 43f);
        Invoke("SpawnSaw", 43.25f);
        Invoke("SpawnSaw", 43.5f);
        Invoke("SpawnSaw", 43.75f);
        Invoke("SpawnSaw", 44f);

        //Invoke("NextScene", 70f);

        DontDestroyOnLoad(sound);

        music = sound.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (endChapter && music.time >= 70)
            NextScene();
    }

    public void LosePoint()
    {
        toltalPoints = 0;
        GameObject obj = Resources.Load("Numbers/Numbers_" + toltalPoints) as GameObject;
        obj = GameObject.Instantiate(obj);
        obj.transform.position = points.transform.position;
        Destroy(points);
        points = obj;

    }

    public void GivePoint()
    {
        toltalPoints++;
        if(toltalPoints <= 10)
        {
            GameObject obj = Resources.Load("Numbers/Numbers_" + toltalPoints) as GameObject;
            obj = GameObject.Instantiate(obj);
            obj.transform.position = points.transform.position;
            Destroy(points);
            points = obj;
        }
    }

    public void SpawnSaw()
    {
        float x = Random.Range(-83f, 83f);
        float y = Random.Range(-150f, 150f);
        Vector2 pos = new Vector2(x, y);

        GameObject.Instantiate(effectSpawn, pos, Quaternion.identity);

        Invoke("SpawnSaw", 5f);
    }

    public void SpawnSun()
    {
        float x = Random.Range(-83f, 83f);
        float y = Random.Range(-150f, 150f);
        Vector2 pos = new Vector2(x, y);

        GameObject obj = sun.Spawn(pos);
        obj.name = "Sun";

        Invoke("SpawnSun", 3f);
    }

    public void NextScene()
    {
        endChapter = false;
        if (true)
            SceneManager.LoadScene("Lies - Tutorial");
        else
        {
            Destroy(sound);
            SceneManager.LoadScene("Choises - Tutorial");
        }
    }
}
