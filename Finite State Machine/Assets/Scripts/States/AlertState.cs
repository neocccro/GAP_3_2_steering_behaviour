using UnityEngine;
using System.Collections;

public class AlertState : State {

	[SerializeField]
	private float alertDuration = 4f;

	private float currentAlarmTime;

	public override void Enter(){
		currentAlarmTime = 0f;
	}

	public override void Act()
    {
        float size = Mathf.Pow(2, Random.Range(0f, 2f) - 1);
		transform.localScale = new Vector3(size, size, size);
		currentAlarmTime += Time.deltaTime;
	}

	public override void Reason()
    {
		if(currentAlarmTime > alertDuration)
        {
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<StateMachine>().SetState( StateID.Fleeing);
        }
	}

}