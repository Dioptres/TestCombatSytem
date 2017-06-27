using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementManager : MonoBehaviour {

	static Vector3 _directionDash = Vector3.zero;

	public static Vector3 directionMove;
	
	public static Vector3 directionDash
	{
		get { return _directionDash; }
		set { _directionDash += value; }
	}




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.position = this.transform.position + directionMove + directionDash;

		directionMove = Vector3.zero;
	}
}
