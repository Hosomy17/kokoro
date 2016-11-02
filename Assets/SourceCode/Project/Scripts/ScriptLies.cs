﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScriptLies : ScriptGeneric
{
    public GameObject arrows;
    public GameObject blocks;
    private GameObject blockUp;
    private GameObject blockDown;
    private string directionArrows;
    public Image hp;

    private bool endChapter;

    private GameObject sound;
    private AudioSource music;

	void Start()
    {
        endChapter = true;
        sound = GameObject.Find("Kokoro Music");
        music = sound.GetComponent<AudioSource>();

        GetComponent<Gamepad>().controller = new ControllerKokoro();
        blockUp = GameObject.Find("Block_Up");
        blockDown = GameObject.Find("Block_Down");
        MoveArrows(1);
        MoveBlocks(-1);
        directionArrows = "Up";

        InvokeRepeating("Squash", 0, 1);
    }

    void Update()
    {
        if(hp.fillAmount <= 0)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Check Point", "Lies - Tutorial");
            GameManagerGeneric.Instance.SaveInfo(d);
            SceneManager.LoadScene("Game Over");
        }

        if (blocks.transform.position.y < -100)
        {
            BehaviourPhysics.Move(blocks, Vector2.up, 0);
            Vector3 pos = blocks.transform.position;
            pos.y = -100;
            blocks.transform.position = pos;
        }
        else if (blocks.transform.position.y > 100)
        {
            BehaviourPhysics.Move(blocks, Vector2.up, 0);
            Vector3 pos = blocks.transform.position;
            pos.y = 100;
            blocks.transform.position = pos;
        }

        if (endChapter && music.time >= 100)
            NextScene();
    }

    private void Squash()
    {

        Vector3 position;
        position = blockUp.transform.localPosition;
        position.y -= 1.8f;
        blockUp.transform.localPosition = position;

        position = blockDown.transform.localPosition;
        position.y += 1.8f;
        blockDown.transform.localPosition = position;
    }

    private void MoveBlocks(float velocity)
    {
        velocity *= Random.Range(30f, 40f);
        BehaviourPhysics.Move(blocks, Vector2.up, velocity);
    }

    private void MoveArrows(float velocity)
    {
        velocity *= Random.Range(100f,120f);
        BehaviourPhysics.Move(arrows, Vector2.up,velocity);
    }

    public void CollisionBlock(string block)
    {
        int lie;
        switch(block)
        {
            case "Block_Up":
                if(directionArrows == "Up")
                {
                    directionArrows = "Down";
                    arrows.BroadcastMessage("Turn");
                    MoveArrows(-1);

                    lie = Random.Range(0, 2);
                    if(lie == 0)
                    {
                        BehaviourAnimation.Play(blockUp,"Truth");
                        BehaviourAnimation.Play(blockDown, "Truth");
                        MoveBlocks(-1);
                    }
                    else
                    {
                        BehaviourAnimation.Play(blockUp, "Lie");
                        BehaviourAnimation.Play(blockDown, "Lie");
                        MoveBlocks(1);
                    }
                }
                break;
            case "Block_Down":
                if (directionArrows == "Down")
                {
                    directionArrows = "Up";
                    arrows.BroadcastMessage("Turn");
                    MoveArrows(1);

                    lie = Random.Range(0, 2);
                    if (lie == 0)
                    {
                        BehaviourAnimation.Play(blockUp, "Truth");
                        BehaviourAnimation.Play(blockDown, "Truth");
                        MoveBlocks(1);
                    }
                    else
                    {
                        BehaviourAnimation.Play(blockUp, "Lie");
                        BehaviourAnimation.Play(blockDown, "Lie");
                        MoveBlocks(-1);
                    }    
                }
                break;
        }
    }

    public void NextScene()
    {
        endChapter = false;
        if (true)
            SceneManager.LoadScene("Moments - Tutorial");
        else
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
