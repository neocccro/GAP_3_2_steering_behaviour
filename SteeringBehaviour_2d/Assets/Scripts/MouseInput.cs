using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

	SteeringVehicle steeringVehicle;
	GameObject targetIcon;

	// Use this for initialization
	void Start () {
		steeringVehicle = GetComponent<SteeringVehicle>();
		targetIcon = GameObject.FindWithTag("target");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			steeringVehicle.setTarget(targetPosition);
			targetIcon.transform.position = targetPosition;
		}
	}
}
