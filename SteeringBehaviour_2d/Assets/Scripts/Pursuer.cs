using UnityEngine;
using System.Collections;

public class Pursuer : MonoBehaviour {

	[SerializeField]
	private float minPursueDistance = 1;

	[SerializeField]
	private GameObject target;

	private SteeringVehicle vehicle;

	// Use this for initialization
	void Start () {
		vehicle = GetComponent<SteeringVehicle>();
	}
	
	// Update is called once per frame
	void Update () {
		// we gaan dit later nog mooier maken met State Machines en delegates :)

		checkTargetDistance();

	}

	void checkTargetDistance(){
		float distance = Vector2.Distance(transform.position, target.transform.position);
		if(distance < minPursueDistance){
			pursueTarget();
		} else {
			// zou niet perse elke frametick uitgevoerd hoeven worden
			stopPursuing();
		}
	}

	void pursueTarget(){
		vehicle.setTarget(target.transform.position);
	}

	void stopPursuing(){
		vehicle.setTarget(this.transform.position);
	}
}
