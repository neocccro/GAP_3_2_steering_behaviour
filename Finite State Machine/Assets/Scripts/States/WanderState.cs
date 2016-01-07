using UnityEngine;
using System.Collections;

public class WanderState : State {

	[SerializeField]
	private float speed = 1f;

	[SerializeField]
	private float arrivalDistance = 0f;

	[SerializeField]
	private float sightDistance = 2.5f;

	[SerializeField]
	private GameObject player;

	private Vector2 targetPosition = new Vector2();
	
	public override void Enter(){
		// we switchen naar deze state: dus kies alvast een nieuwe target position
		chooseTargetLocation();
	}

	void chooseTargetLocation(){
		// kiest een locatie binnen het veld van de camera
		Vector3 world = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		
		targetPosition.x = Random.Range(-world.x, world.x);
		targetPosition.y = Random.Range(-world.y, world.y);
	}

	public override void Act(){
		float step = speed * Time.deltaTime;
		float distance;

		transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
		distance = Vector2.Distance(transform.position, targetPosition);

		if(distance < arrivalDistance)
			chooseTargetLocation();
	}

	public override void Reason(){
		float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);

		if(distanceToPlayer < sightDistance){
			// laten we switchen naar een nieuwe state
			GetComponent<StateMachine>().SetState( StateID.Alerting);
		}

	}


}
