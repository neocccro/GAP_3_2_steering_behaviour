using UnityEngine;
using System.Collections;
// 0: imports nodig
using System;
using System.Threading;

public class NewTread : MonoBehaviour {

	private int count = 0;

	// Use this for initialization
	void Start () {
		
		// 2: we maken een 'worker' thread aan. Wat zien we in de console?
		// Thread verwacht een delegate (declaratie volgen 'goTo declaration')
		/*Thread t = new Thread (WriteY);
		t.Start();


		// 2-2 isAlive property*/

		// 1 we beginnen met een normale 'enkele' thread
		// wat zien we in onze console?
		//WriteY();
		//WriteX();

		/*
		// 3 we maken een wapen aan. Wat zien we in de console? Meerdere keren uitvoeren
		Weapon currentWeapon = new Weapon();

		// we maken de thread aan
		new Thread(currentWeapon.Shoot).Start();

		// we roepen de functie ook direct aan. 2 threads delen nu data
		currentWeapon.Shoot();

		// 3-2: dit geldt ook voor static variabelen
		*/


		/*
		// 4 we gaan een counter updaten en daarna parameters doorgeven
		*/

		Thread t = new Thread( () => {
			UpdateCount(6);
		});

		t.Start();

		UpdateCount( 6 );

	}

	void UpdateCount(int maxCount){
		for(int i = 0 ; i < maxCount ; i++ ){
			count += 1;
			Debug.Log(count);
		}
	}

	void WriteX(){
		// we starten een loop op de main thread
		for (int i = 0; i < 1000; i++) Debug.Log ("x");
	}

	void WriteY()
	{
		// deze loop draait op een andere tread
		for (int i = 0; i < 1000; i++) Debug.Log ("y");
	}

}
