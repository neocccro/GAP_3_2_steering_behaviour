using UnityEngine;
using System.Collections;

public class SeekBehaviourScript : MonoBehaviour {
	
	public Transform target;
	private float maxSpeed	=	10;
	private float mass		=	50;
	
	// Use this for initialization
	void Start () {
		rigidbody.velocity	=	new Vector3(0,1,1) * maxSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
		Seek();
		
	}
	
	void Seek () {
		
		// we berekenen eerst de afstand/Vector tot de 'target' (in dit voorbeeld de andere cubus)		
		Vector3 desiredStep	=	target.position - rigidbody.position;		
				
		// deze desiredStep mag niet groter zijn dan de maximale Speed
		//
		// als een vector ge'normalized' is .. dan houdt hij dezelfde richting
		// maar zijn lengte/magnitude is 1
		desiredStep.Normalize();
		
		// als je deze weer vermenigvuldigt met de maximale snelheid dan
		// wordt de lengte van deze Vector maxSpeed (aangezien 1 x maxSpeed = maxSpeed)
		// de x en y van deze Vector wordt zo vanzelf omgerekend
		Vector3 desiredVelocity			=	desiredStep	*	maxSpeed;
		
		// bereken wat de Vector moet zijn om bij te sturen om bij de desiredVelocity te komen
		Vector3 steeringForce			=	desiredVelocity - rigidbody.velocity;
		
		// uiteindelijk voegen we de steering force toe maar wel gedeeld door de 'mass'
		// hierdoor gaat hij niet in een rechte lijn naar de target
		// hoe zwaarder het object hoe moeilijker hij kan bijsturen
		rigidbody.velocity				=	rigidbody.velocity + steeringForce / mass;
			
		
	}
}
