using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float bounciness;

	Rigidbody2D rb2d;
	ManagerScript ms;
	RectTransform rt;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();//変数rb2dの中にRigidbody2dを格納しておく！
		rt = GetComponent<RectTransform>();

		ms = GameObject.Find("Manager").GetComponent<ManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}


	//Playerの移動(ReceTransform使って移動)
	void Move()
	{
		if(ms.isPlaying == true)
		{
			//x軸方向の入力(左右)を拾う(-1 < x < 1)
            float x = Input.GetAxisRaw("Horizontal");
            rt.localPosition += new Vector3(x * speed * Time.deltaTime, 0, 0);
		}
        
	}


	//Playerのバウンドをコントロール
	private void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.tag == "Ground")
        {
            rb2d.velocity = new Vector2(0, bounciness);//上方向の速度ベクトルを直接ぶち込む
        }
	}

    //Itemに当たった時の処理
	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Item")
		{
			//Destroy(col.gameObject);
			ms.remain--;
		}
	}
}
