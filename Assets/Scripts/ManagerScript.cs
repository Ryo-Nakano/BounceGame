using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour {

	public bool isPlaying;//ゲームプレイ可能かどうかのフラグ
	[SerializeField] Text infoText;
	public Text remainText;
	[SerializeField] Text timeText;
	[SerializeField] Text clearText;

	[SerializeField] GameObject items;

	public int remain;//残りアイテム数

	float timer;

	// Use this for initialization
	void Start () {
		init();
	}
	
	// Update is called once per frame
	void Update () {
		GameManager();

	}

	void GameManager()
	{
		if(isPlaying == true)
		{
			timer += Time.deltaTime;//タイマー開始
            timeText.text = "Time : " + timer.ToString("f2");

			if (remain <= 0)//item無くなったら
            {
                isPlaying = false;
				clearText.text = "C L E A R";
            }
		}
		else//isPlaying == false
		{
			if (Input.GetKeyDown("space") == true)
            {
                isPlaying = true;//spaceが押されたらisPlayingをtrueに
                Debug.Log("isPlaying == true");
                infoText.text = "";
                remainText.text = "Remain : " + remain;
                items.gameObject.SetActive(true);
            }
		}
	}

    //色々初期化
	void init()
	{
		isPlaying = false;//最初はfalse
        remainText.text = "";
        timeText.text = "";
        clearText.text = "";
        items.gameObject.SetActive(false);

        remain = items.transform.childCount;//itemの数を変数remainに格納！
	}
}
