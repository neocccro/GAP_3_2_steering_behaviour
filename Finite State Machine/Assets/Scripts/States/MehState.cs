using UnityEngine;
using System.Collections;

public class MehState : State
{

    [SerializeField]
    private int times = 1;

    private int counter;
    
    public override void Enter()
    {
        counter = 0;
    }

    public override void Act()
    {
        print("meh");
        counter++;
    }

    public override void Reason()
    {
        if (counter > times)
        {
            // laten we switchen naar een nieuwe state
            GetComponent<StateMachine>().SetState(StateID.Wandering);
        }
    }
}
