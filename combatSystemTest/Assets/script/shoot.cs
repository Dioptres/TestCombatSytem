using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	public AudioClip shootSound;
	public AudioClip superShootSound;

	AudioSource source;

	Vector3 mousePos;
	Vector3 line;
	Vector3 graphLine;
	Vector3 lineForDraw;
	private LineRenderer _lineRenderer;

	float timerShoot;

	Vector3 move;

	public float modifDist = 2;

	// Use this for initialization
	void Start ()
	{
		source = GetComponent<AudioSource> ();

		timerShoot = 0;

		_lineRenderer = gameObject.AddComponent<LineRenderer> ();
		_lineRenderer.startWidth = 0.05f;
		move = Vector3.zero;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		this.transform.position += move;
		if (move.magnitude > 1)
		{
			move /= 2;
		}
		else if (move.magnitude > 0.2f)
		{
			move /= 1.2f;
		}
		else
		{
			move = Vector3.zero;
		}


		mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
		mousePos = new Vector3 (mousePos.x, mousePos.y, 0);
		line = mousePos - this.transform.position;
		line = line.normalized;

		

		if(Input.GetAxis("reverseShoot") == 1) 
		{
			graphLine = this.transform.position - line*modifDist;
			line = -line;
		}
		else
		{
			graphLine = this.transform.position + line*modifDist;
		}

		_lineRenderer.SetPosition (0, this.transform.position);
		_lineRenderer.SetPosition (1, graphLine);

		if(Input.GetMouseButton (0))
		{
			Debug.Log (timerShoot);
			timerShoot += Time.deltaTime;
			if(timerShoot > 2) { timerShoot = 2; }
			//move -= line/2;
			//source.PlayOneShot (shootSound);

		}
		else if (Input.GetMouseButtonUp (0))
		{
			Debug.Log (timerShoot);
			if(timerShoot < 1)
			{
				source.PlayOneShot (shootSound);
			}
			else
			{
				source.PlayOneShot (superShootSound);
			}
			movementManager.directionDash = -line*(timerShoot*timerShoot + 1);
			timerShoot = 0;
		}


		if (Input.GetMouseButtonDown (1))
		{
			//move -= line/2;
			//source.PlayOneShot (superShootSound);
			movementManager.directionDash = line;
		}


	}
}
