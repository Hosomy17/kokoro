using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ScriptLies : ScriptGeneric
{
    public GameObject arrows;
    public GameObject blocks;
    private GameObject blockUp;
    private GameObject blockDown;
    private string directionArrows;

	void Start ()
    {
        GetComponent<Gamepad>().controller = new ControllerKokoro();
        blockUp = GameObject.Find("Block_Up");
        blockDown = GameObject.Find("Block_Down");
        MoveArrows(-1);
        MoveBlocks(-1);
        directionArrows = "Down";

        InvokeRepeating("Squash", 0, 1);
        Invoke("NextScene", 26f);
    }

    void Update()
    {
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
        SceneManager.LoadScene("Moments - Tutorial");
    }
}
