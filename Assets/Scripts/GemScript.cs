using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemScript : MonoBehaviour {

	[SerializeField] GameObject particle;//Unityからエフェクトアタッチ

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Debug.Log("Hit Player !!");
			Destroy(this.gameObject);
            
			float positionX = this.transform.transform.position.x;
			float positionY = this.transform.transform.position.y;
			float adjustZ = -Camera.main.transform.position.z;
            
			Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(positionX, positionY, adjustZ));
			p.z = 10f;//ちょっとz前に出す
			Debug.Log("p : " + p);

			GameObject obj = Instantiate(particle) as GameObject;
			obj.transform.position = p;
		}
	}
}
