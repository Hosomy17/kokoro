using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ControllerKokoro : ControllerGeneric
{
    public ClassKokoro classKokoro;

    public ControllerKokoro()
    {
        this.classKokoro = GameObject.Find("Kokoro").GetComponent<ClassKokoro>();
    }

    public override void SendInput(Dictionary<string, object> input)
    {
        string name =(string) input["Name"];
        switch(name)
        {
            case "Directional":
                
                Move(
                    (Vector2) input["Axis"]
                    );
                break;
        }
    }

    public void Move(Vector2 directions)
    {
        FacadeKokoro.Move(classKokoro, directions);
        
        if(directions.x == 0)
        {
            FacadeKokoro.Idle(classKokoro, Vector2.right);
        }
        if(directions.y == 0)
        {
            FacadeKokoro.Idle(classKokoro, Vector2.up);
        }
    }

    public override void TrackObject(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }
}
