using UnityEngine;
using System.Collections;

public class ControllerKeys : ControllerGeneric
{
    public ClassKey classKey;
	
    public ControllerKeys()
    {
        this.classKey = GameObject.Find("Keys").GetComponent<ClassKey>();
    }

    public override void SendInput(System.Collections.Generic.Dictionary<string, object> input)
    {
        string name = (string)input["Name"];
        switch (name)
        {
            case "Directional":

                Press(
                    (Vector2)input["Axis"]
                    );
                break;
        }
    }

    public void Press(Vector2 directions)
    {
        if (directions.x == 1)
            FacadeKeys.PressDown(classKey, "Right");
        else if (directions.x == -1)
            FacadeKeys.PressDown(classKey, "Left");
        else if (directions.y == 1)
            FacadeKeys.PressDown(classKey, "Up");
        else if (directions.y == -1)
            FacadeKeys.PressDown(classKey, "Down");
        else
            FacadeKeys.PressDown(classKey, "Idle");
    }

    public override void TrackObject(GameObject gameObject)
    {
        gameObject.GetComponent<ClassKey>();
    }
}
