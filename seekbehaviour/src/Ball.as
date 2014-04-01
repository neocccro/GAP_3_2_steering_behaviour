package  
{
	import flash.display.Sprite;
	/**
	 * ...
	 * @author Berend Weij
	 */
	public class Ball extends Vehicle
	{
		
		// de class 'Ball' extend de Vehicle. Hierdoor heeft hij functies zoals 'seek'
		// ook andere objecten kunnen nu eenvoudig de Vehicle class extenden
		public function Ball() 
		{
			var size : int = 30;
			this.graphics.beginFill(0xFF0000);
			this.graphics.lineStyle(1, 0xFF0000);
			this.graphics.lineTo(-size/2, -size/2);
			this.graphics.lineTo(-size/2, size/2);
			this.graphics.lineTo(0, 0);
						
			maxSpeed	=	10;
			mass		=	25;
		}
	}

}