using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

	Transform player;
	public float distCamFromPlayer = 3;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Mathf.Abs(player.position.x-transform.position.x)> distCamFromPlayer)
		{
			if (player.position.x - transform.position.x > 0)
			{
				this.transform.position = new Vector3 (this.transform.position.x + ((player.position.x - transform.position.x) - distCamFromPlayer), this.transform.position.y, this.transform.position.z);
			}
			else
			{
				this.transform.position = new Vector3 (this.transform.position.x + ((player.position.x - transform.position.x) + distCamFromPlayer), this.transform.position.y, this.transform.position.z);
			}	
		}
		if (Mathf.Abs (player.position.y - transform.position.y) > distCamFromPlayer)
		{
			if (player.position.y - transform.position.y > 0)
			{
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + ((player.position.y - transform.position.y) - distCamFromPlayer), this.transform.position.z);
			}
			else
			{
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + ((player.position.y - transform.position.y) + distCamFromPlayer), this.transform.position.z);
			}
		}
	}
}
