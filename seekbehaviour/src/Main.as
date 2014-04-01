package 
{
	import flash.display.Sprite;
	import flash.events.Event;
	
	/**
	 * ...
	 * @author Berend Weij
	 */
	public class Main extends Sprite 
	{
		
		private var ball : Ball;
		
		public function Main():void 
		{
			if (stage) init();
			else addEventListener(Event.ADDED_TO_STAGE, init);
		}
		
		private function init(e:Event = null):void 
		{
			removeEventListener(Event.ADDED_TO_STAGE, init);
			
			
			ball = new Ball();
			
			addChild(ball);
			
			addEventListener(Event.ENTER_FRAME, update);
		}
		
		private function update(e : Event) : void
		{
			
			ball.seek(new Vector2D(mouseX, mouseY));
			
			
			ball.update();
		}
		
	}
	
}