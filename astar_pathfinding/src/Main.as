package 
{
	import flash.display.Graphics;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.geom.Point;
	import nl.mediacollege.grid.Grid;
	import nl.mediacollege.grid.AStar;
	
	/**
	 * ...
	 * @author Berend Weij
	 */
	public class Main extends Sprite 
	{
		
		// variabele om het grid in op te slaan
		// het grid hebben we in het geheugen nodig als 'representatie' van de wereld
		private var _grid : Grid;
		
		// deze variabelen zijn alleen nodig om de cellen visueel weer te kunnen geven (als voorbeeld)
		private var _cellWidth : int = 30;
		private var _cellHeight : int = 30;
		
		// deze twee sprites zijn nodig om onze grid visueel weer te geven (alleen voor het voorbeeld nodig)
		private var _visualGrid : Sprite	=	new Sprite();
		private var _visualPath : Sprite	=	new Sprite();
		
		public function Main():void 
		{
			if (stage) init();
			else addEventListener(Event.ADDED_TO_STAGE, init);
		}
		
		private function init(e:Event = null):void 
		{
			removeEventListener(Event.ADDED_TO_STAGE, init);

			addChild(_visualGrid);
			addChild(_visualPath);
			
			// als eerste maken we het grid aan. Voor nu is hij 30 bij 20 cellen (is 600 cellen)
			_grid	=	new Grid(30, 20);
			
			// als voorbeeld tekenen we het grid ook op het scherm			
			createVisualGrid();
			
			// ter voorbeeld voegen we een aantal walls toe. Dit is ter voorbeeld.
			addWall(29, 12);
			addWall(28, 12);
			addWall(27, 12);
			addWall(26, 12);
			addWall(25, 12);
			
			// we voegen een extra wall toe van x:0, y:9 t/m x:28,y:9 (rode streep van links naar rechts)
			for (var i : int = 0; i < 28; i++)
			{
				addWall(i, 9);
			}
			
			// mouse listener om het pad te tekenen als er geklikt wordt
			addEventListener(MouseEvent.CLICK, showPath);
			
		}
		
		private function showPath( e : MouseEvent ) : void
		{
			// er is geklikt door de gebruiker. We rekenen de x en y positie van de muis om
			// naar de positie in het grid.
			var x : int = mouseX / _cellWidth;
			var y : int = mouseY / _cellHeight;
			
			// start punt is nu standaard coordinaat 0,0 (linksbovenin)
			var startPoint	:	Point	=	new Point(0, 0);
			// het eindpunt is waar we hebben geklikt
			var endPoint	:	Point	=	new Point(x, y);
			
			// we laten de Class AStar het pad berekenen
			var path : Array = AStar.search(_grid, startPoint, endPoint);
			
			// en we tekenen het pad (ter voorbeeld) op het scherm
			// het pad bevat alle cellen waar we langs moeten
			drawPath(path);
		}
		
		/*
		 *  ONDERSTAANDE FUNCTIES ZIJN ALLEEN VOOR DIT VOORBEELD OM DE WERKING VAN A STAR TE LATEN ZIEN
		 * 	VOOR JULLIE EIGEN GAMES IS DIT NIET NODIG
		 * */
		
		// extra functie om als voorbeeld een muur visueel weer te geven
		private function addWall(x : int, y : int) : void
		{
			_visualGrid.graphics.beginFill(0xff0000);
			_grid.getCell(x, y).isWall	=	true;
			drawRectangle(_visualGrid.graphics, x, y);
		}
		
		// extra functie om als voorbeeld het grid weer te geven
		private function createVisualGrid():void 
		{
			var w : int = _grid.width;
			var h : int = _grid.height;
			_visualGrid.graphics.beginFill(0xffffff);
			_visualGrid.graphics.lineStyle(1, 0x000000);
			for (var x : int = 0 ; x < w ; x++ )
			{
				for (var y : int = 0; y < h ; y++)
				{
					drawRectangle(_visualGrid.graphics, x, y);
				}
			}
		}
		
		// extra functie om weer te geven wat het pad is dat is berekent
		// dit is alleen ter voorbeeld
		private function drawPath(path:Array) : void
		{
			_visualPath.graphics.clear();
			_visualPath.graphics.beginFill(0x000000);
			var l : int = path.length;
			for (var i : int = 0 ; i < l ; i++)
			{
				drawRectangle(_visualPath.graphics, path[i].position.x, path[i].position.y);
			}
		}
		
		// extra functie om een rectangle te kunnen tekenen
		private function drawRectangle(graphics : Graphics, x : int, y : int) : void
		{
			graphics.drawRect(x * _cellWidth, y * _cellHeight, _cellWidth, _cellHeight);
		}
		
	}
	
}