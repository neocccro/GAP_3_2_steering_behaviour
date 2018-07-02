using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class Enemy : MonoBehaviour {

	PathFinder pathFinder = new PathFinder();

	// Use this for initialization
	void OnMouseDown () {
		Search();
	}
	
	void Search(){
		Debug.Log("Searching a new path");

		Thread t = new Thread (pathFinder.FindPath);
		t.Start();
		t.Join(); // Join kost geen CPU performance. Maar blokt wel.

		Debug.Log ("PathFinding ended. We have a path now.");


	}
}
