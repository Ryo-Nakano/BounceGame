using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemScript : MonoBehaviour {

	ParticleSystem particle;
	Image image;
	BoxCollider2D boxCollider2;
    

	// Use this for initialization
	void Start () {
		particle = this.transform.Find("Destruction01").GetComponent<ParticleSystem>();
		image = GetComponent<Image>();
		boxCollider2 = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Debug.Log("Hit Player !!");
			Destroy(image);
			Destroy(boxCollider2);
			particle.Play();

		}
	}
}
