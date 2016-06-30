using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScriptRegrets : MonoBehaviour
{
    public GameObject points;
    public GameObject effectSpawn;
    public GameObject sun;

    public int toltalPoints = 0;

    void Start()
    {
        GetComponent<Gamepad>().controller = new ControllerKokoro();
        GameObject obj = Resources.Load("Numbers/Numbers_" + toltalPoints) as GameObject;
        obj = GameObject.Instantiate(obj);
        obj.transform.position = points.transform.position;
        Destroy(points);
        points = obj;

        
        Invoke("SpawnSun", 2f);
        Invoke("SpawnSun", 8f);

        Invoke("SpawnSaw", 4f);
        Invoke("SpawnSaw", 4.25f);
        Invoke("SpawnSaw", 4.5f);
        Invoke("SpawnSaw", 4.75f);
        Invoke("SpawnSaw", 4f);

        Invoke("SpawnSaw", 5f);
        Invoke("SpawnSaw", 5.25f);
        Invoke("SpawnSaw", 5.5f);
        Invoke("SpawnSaw", 5.75f);
        Invoke("SpawnSaw", 6f);

        Invoke("NextScene", 25f);

    }

    void Update()
    {

    }

    public void GivePoint()
    {
        toltalPoints++;
        if (toltalPoints > 10)
            toltalPoints = 10;

        GameObject obj = Resources.Load("Numbers/Numbers_" + toltalPoints) as GameObject;
        obj = GameObject.Instantiate(obj);
        obj.transform.position = points.transform.position;
        Destroy(points);
        points = obj;
    }

    public void LosePoint()
    {
        toltalPoints--;
        if (toltalPoints < 0)
            toltalPoints = 0;

        GameObject obj = Resources.Load("Numbers/Numbers_" + toltalPoints) as GameObject;
        obj = GameObject.Instantiate(obj);
        obj.transform.position = points.transform.position;
        Destroy(points);
        points = obj;
    }

    public void SpawnSaw()
    {
        float x = Random.Range(-83f, 83f);
        float y = Random.Range(-150f, 150f);
        Vector2 pos = new Vector2(x, y);

        GameObject.Instantiate(effectSpawn, pos, Quaternion.identity);

        Invoke("SpawnSaw", 5.5f);
    }

    public void SpawnSun()
    {
        float x = Random.Range(-83f, 83f);
        float y = Random.Range(-150f, 150f);
        Vector2 pos = new Vector2(x, y);

        GameObject obj = sun.Spawn(pos);
        obj.name = "Sun 1";

        Invoke("SpawnSun", 4f);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Obesessions - Tutorial");
    }
}