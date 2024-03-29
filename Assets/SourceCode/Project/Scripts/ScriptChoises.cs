﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ScriptChoises : ScriptGeneric
{
    public GameObject points;
    public GameObject effectSpawn;
    public GameObject sun;
    private GameObject sound;
    public AutoZoom autoZoom;

    private bool endChapter;

    private AudioSource music;

    public int toltalPoints = 0;

    void Start()
    {
        endChapter = true;
        sound = GameObject.Find("Kokoro Music");
        GetComponent<Gamepad>().controller = new ControllerKokoro();
        GameObject obj = Resources.Load("Numbers/Numbers_"+toltalPoints) as GameObject;
        obj = GameObject.Instantiate(obj);
        obj.transform.position = points.transform.position;
        Destroy(points);
        points = obj;

        Invoke("SpawnSaw", 4f);
        Invoke("SpawnSun", 3f);
        Invoke("SpawnSun", 5f);

        Invoke("Zoom", 35.5f);
        Invoke("SpawnSaw", 35f);
        Invoke("SpawnSaw", 35.25f);
        Invoke("SpawnSaw", 35.5f);
        Invoke("SpawnSaw", 35.75f);
        Invoke("SpawnSaw", 36f);

        Invoke("SpawnSaw", 38f);
        Invoke("SpawnSaw", 38.25f);
        Invoke("SpawnSaw", 38.5f);
        Invoke("SpawnSaw", 38.75f);
        Invoke("SpawnSaw", 39f);

        music = sound.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (endChapter && music.time >= 70)
            NextScene();
    }

    public void Zoom()
    {
        autoZoom.limit = 50;
        autoZoom.velocity = 10;
    }

    public void LosePoint()
    {
        toltalPoints -= 3;

        if (toltalPoints < 0)
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
        if (toltalPoints <= 10)
        {
            GameObject obj = Resources.Load("Numbers/Numbers_" + toltalPoints) as GameObject;
            obj = GameObject.Instantiate(obj);
            obj.transform.position = points.transform.position;
            Destroy(points);
            points = obj;
        }
        else
            toltalPoints = 10;
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
        if (toltalPoints >= 10)
            SceneManager.LoadScene("Lies - Tutorial");
        else
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Check Point", "Choises - Tutorial");
            GameManagerGeneric.Instance.SaveInfo(d);
            SceneManager.LoadScene("Game Over");
        }
    }
}
