using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBehavior : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
			collision.gameObject.transform.parent = this.gameObject.transform;
	}

	private void OnCollisionExit2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Player")
             collision.gameObject.transform.parent = null;
     }
}
