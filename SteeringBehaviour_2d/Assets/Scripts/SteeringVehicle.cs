using UnityEngine;
using System.Collections;

public class SteeringVehicle : MonoBehaviour {

	/** gesorteerd op alfabet */
	[SerializeField]
	private float maxSpeed	=	5;

	[SerializeField]
	private float mass		=	20;

	private Rigidbody2D rigidBody;
	private Vector2 target;

	private int[,] numbers;

	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();

		numbers = new int[10,10];
		numbers[1,1] = 5;
		numbers[3,2] = 10;

		Debug.Log ("numbers[1]: " + numbers[1]);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Seek();
	}

	public void setTarget(Vector2 target) {
		this.target = target;
	}

	void Seek () {

		// we berekenen eerst de afstand/Vector tot de 'target' (in dit voorbeeld de andere cubus)		
		Vector2 desiredStep	=	target - rigidBody.position;

		// deze desiredStep mag niet groter zijn dan de maximale Speed
		//
		// als een vector ge'normalized' is .. dan houdt hij dezelfde richting
		// maar zijn lengte/magnitude is 1
		desiredStep.Normalize();
		
		// als je deze weer vermenigvuldigt met de maximale snelheid dan
		// wordt de lengte van deze Vector maxSpeed (aangezien 1 x maxSpeed = maxSpeed)
		// de x en y van deze Vector wordt zo vanzelf omgerekend
		Vector2 desiredVelocity			=	desiredStep	*	maxSpeed;
		
		// bereken wat de Vector moet zijn om bij te sturen om bij de desiredVelocity te komen
		Vector2 steeringForce			=	desiredVelocity - rigidBody.velocity;

		// uiteindelijk voegen we de steering force toe maar wel gedeeld door de 'mass'
		// hierdoor gaat hij niet in een rechte lijn naar de target
		// hoe zwaarder het object hoe moeilijker hij kan bijsturen
		rigidBody.velocity				=	rigidBody.velocity + steeringForce / mass;

		// @ code templates laten zien


		// de goede kant op kijken
		float angle = Mathf.Atan2(rigidBody.velocity.y, rigidBody.velocity.x) * Mathf.Rad2Deg;
		rigidBody.MoveRotation(angle);
		
	}
}
