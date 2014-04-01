package  
{
	import flash.display.Sprite;
	/**
	 * ...
	 * @author Berend Weij
	 */
	public class Vehicle extends Sprite
	{
		
		// onze belangrijkste Vectors: velocity (beweging) en positie
		private var _velocity			:	Vector2D	=	new Vector2D(3, 3);
		private var _position			:	Vector2D	=	new Vector2D(0, 0);
		
		// extra sprite om de groene pijl in te tekenen
		private var _vectorGraphic		:	Sprite;
		
		private var _maxSpeed			:	Number	=	1;
		private var _mass				:	Number	=	1;
		private var _slowingRadius		:	Number	=	100;
		
		private var _arrivedDistance	:	Number	=	10;
		private var _breakingForce		:	Number	=	0.9;
		
		private var _path				:	Array	=	[];
		
		public function Vehicle() 
		{
			_vectorGraphic	=	new Sprite();
			addChild(_vectorGraphic);
		}
		
		public function update():void
		{
			
			// beweeg het object door middel van de Euler formule positie = positie + velocity
			_position = _position.add(_velocity);
			
			// we moeten de positie nog doorvertalen naar de 'visuele' positie van deze sprite
			x = _position.x;
			y = _position.y;
			
			followPath();
		}
		
		public function seek(target:Vector2D) : void
		{
			// we berekenen eerst de afstand/Vector tot de 'target' (in dit voorbeeld de muis)
			var desiredStep:Vector2D		=	target.subtract(_position);
			
			// we kunnen deze lijn laten zien door drawVector aan te roepen
			//desiredStep.drawVector(_vectorGraphic.graphics, 0x00FF00);
			
			// deze desiredStep mag niet groter zijn dan de maximale Speed
			//
			// als een vector ge'normalized' is .. dan houdt hij dezelfde richting
			// maar zijn lengte/magnitude is 1
			desiredStep.normalize();
		
			// als je deze weer vermenigvuldigt met de maximale snelheid dan
			// wordt de lengte van deze Vector maxSpeed (aangezien 1 x maxSpeed = maxSpeed)
			// de x en y van deze Vector wordt zo vanzelf omgerekend
			var desiredVelocity:Vector2D			=	desiredStep.multiply(maxSpeed);
			
			// bereken wat de Vector moet zijn om bij te sturen om bij de desiredVelocity te komen
			var steeringForce:Vector2D = desiredVelocity.subtract(_velocity);
			
			// uiteindelijk voegen we de steering force toe maar wel gedeeld door de 'mass'
			// hierdoor gaat hij niet in een rechte lijn naar de target
			// hoe zwaarder het object hoe moeilijker hij kan bijsturen
			steeringForce.divide(_mass);
			
			// uiteindelijk tellen we de velocity en de stuurkracht bij elkaar op
			_velocity.add(steeringForce);
			
			// rotation = the velocity's angle converted to degrees
			rotation = _velocity.angle * 180 / Math.PI;
		}
		
		public function followPath() : void
		{
			// eerst constroleren we of er nog wel een pad is om te volgen
			if (path.length == 0)
			{
				// als er geen pad is dan remmen we onze snelheid langzaam af
				_velocity.multiply(_breakingForce);
				// en we stoppen deze functie
				return;
			}
			
			// als er nog een pad te volgen is dan pakken we het eerste punt waar we naartoe moeten
			// aangezien we er berekeningen mee gaan doen maken we een copy/clone
			var waypoint	:	Vector2D =  path[0].cloneVector();
			
			// we weten nu waar we naartoe willen.
			// als we dichtbij genoeg zijn dan gaan we door naar het volgende punt
			var dist	:	Number = waypoint.distance(_position);
			if (dist < _arrivedDistance) {
				// als we bij het punt zijn dan mag deze waypoint worden verwijderd
				path.splice(0, 1);
				// en we stoppen deze functie
				return;
			}
			
			// als er een waypoint is waar we nog niet zijn gearriveerd
			// dan proberen we er naar toe te sturen
			seek(waypoint);
		}
		
		public function get maxSpeed():Number 
		{
			return _maxSpeed;
		}
		
		public function set maxSpeed(value:Number):void 
		{
			_maxSpeed = value;
		}
		
		public function get mass():Number 
		{
			return _mass;
		}
		
		public function set mass(value:Number):void 
		{
			_mass = value;
		}
		
		public function get slowingRadius():Number 
		{
			return _slowingRadius;
		}
		
		public function set slowingRadius(value:Number):void 
		{
			_slowingRadius = value;
		}
		
		public function get path() : Array
		{
			return _path;
		}
		public function set path(value : Array) : void
		{
			_path	=	value;
		}
		
		public function addWayPoint(value : Vector2D) : void
		{
			path.push(value);
		}
	}

}