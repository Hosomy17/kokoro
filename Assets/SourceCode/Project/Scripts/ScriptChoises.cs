using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScriptChoises : ScriptGeneric
{
    public GameObject points;
    public GameObject effectSpawn;
    public GameObject sun;
    public GameObject sound;

    public int toltalPoints = 0;

    void Start()
    {
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

        Invoke("NextScene", 70.2f);

        DontDestroyOnLoad(sound);
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

        GameObject obj = GameObject.Instantiate(sun, pos, Quaternion.identity) as GameObject;
        obj.name = "Sun";

        Invoke("SpawnSun", 3f);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Lies");
    }
}
