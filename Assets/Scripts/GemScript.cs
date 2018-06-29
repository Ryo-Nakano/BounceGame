using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour {
    
	[SerializeField] GameObject particle;//Gem取得エフェクト

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider col)
	{
		Debug.Log("Hello!!");
		if(col.gameObject.tag == "Player")
		{
			Debug.Log("Hit Player !!");
			Instantiate(particle, this.transform.position, Quaternion.identity);
		}
	}
}
