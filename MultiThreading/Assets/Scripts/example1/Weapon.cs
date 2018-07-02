using UnityEngine;
using System.Collections;

public class Weapon {

	private bool IsFired = false;


	// 5: we brengen thread safety aan. Blocken een thread hiermee. Kost geen CPU
	// lock aanmaken. Zorgt ervoor dat we aan kunnen geven in welk kritieke block alleen maar 1 thread tegelijk mag (de andere wacht)
	// dit zorgt voor thread safety
	readonly object locker = new object();


	public void Shoot(){
		lock(locker){
			// geen thread safety
			if (!IsFired) { 
				// 4: als we deze 2 omdraaien dan is er een veel grotere kans op 2 debug logs
				Debug.Log ("Not fired yet. Let's do this."); 
				IsFired = true;
			} else {
				// ook deze komt eerder ... goed over nadenken. Dit geeft ook de moeilijkheid aan van multi threaden
				Debug.Log("Too late bro. Shots fired.");
			}
		}
	}

}
