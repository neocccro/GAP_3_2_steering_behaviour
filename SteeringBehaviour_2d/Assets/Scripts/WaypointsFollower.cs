using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// deze Class kan functies aanroepen in SteeringVehicle.cs
public class WaypointsFollower : MonoBehaviour {

	// todo: zorg ervoor dat dit component een lijst met waypoints/Vectors kan bevatten (instelbaar vanuit de editor)
	[SerializeField]
	private List<Vector2> wayPoints = new List<Vector2>();

	[SerializeField]
	private SteeringVehicle vehicle;

	[SerializeField]
	private float minimumArriveDistance = 0.5f;

	void Start () {
		// todo: als er al waypoints beschikbaar zijn: ga richting de eerste waypoint

		NextWayPoint();

	}

	void Update () {
		// todo: checken of we al in de buurt zijn van de eerstvolgende waypoint: zo ja -> ga door naar het volgende waypoint (setTarget() op SteeringVehicle.cs)
		float distance = Vector2.Distance(vehicle.Target, transform.position);

		if(distance < minimumArriveDistance)
			NextWayPoint();
		
	}

	void NextWayPoint(){
		if(wayPoints.Count == 0)
			return;

		Vector2 nextTarget = wayPoints[0];
		wayPoints.RemoveAt(0);
		vehicle.setTarget(nextTarget);

	}

	// zorg ervoor dat er een addWayPoint method is
	public void AddWayPoint( Vector2 newWayPoint ){
		wayPoints.Add( newWayPoint );

		if(wayPoints.Count == 1)
			NextWayPoint();
	}
	
}
