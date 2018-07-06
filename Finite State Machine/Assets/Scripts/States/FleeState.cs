using UnityEngine;
using System.Collections;

public class FleeState : State
{
    private float startTime;

    public float duration = 2f;
    
    public override void Enter()
    {
        startTime = Time.time;
    }

    public override void Act()
    {
		transform.Translate(new Vector3(0.1f, 0, 0));
	}
	
	public override void Reason()
    {
        if(startTime + duration < Time.time)
        {
            // laten we switchen naar een nieuwe state
            GetComponent<StateMachine>().SetState(StateID.Mehing);
        }
    }
}
