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
	[SerializeField] Button startButton;

	[SerializeField] GameObject gems;
	[SerializeField] GameObject gem;//Instantiateする為にUnityからアタッチ

    //gemをランダム生成する時に使う変数
	int rangeX = 825;
	int rangeY = 325;

	public int remain;//残りアイテム数

	float timer;

	// Use this for initialization
	void Start () {
		GenerateGems();//Gemをランダムに12個生成
		init();//各種初期化
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
				Debug.Log("isPlaying == false");
				clearText.text = "C L E A R";
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
        
		remain = gems.transform.childCount;//itemの数を変数remainに格納！
	}

    //Startボタン押された時に呼ばれる
	public void StartButton()
	{
		Debug.Log("StartButtonPushed!!");

		gems.SetActive(true);//生成後、無効化にしていたgemsを有効化
		isPlaying = true;//spaceが押されたらisPlayingをtrueに
        Debug.Log("isPlaying == true");
        infoText.text = "";
        remainText.text = "Remain : " + remain;

		startButton.gameObject.SetActive(false);//button押されたら無効化
	}

	//Gemを12個生成する関数(場所ランダム)
	void GenerateGems()
	{
		for (int i = 0; i < 12; i++)//12回回す
		{
			GameObject obj = Instantiate(gem) as GameObject;//gemを生成→GameObject型にキャスト→変数oblに格納
			obj.transform.SetParent(gems.transform);//生成したgemの親としてgemsを指定
			obj.transform.localPosition = new Vector2(Random.Range(-rangeX, rangeX) ,Random.Range(-rangeY, rangeY));
		}
		gems.SetActive(false);//gem12個生成後、gemsを一旦無効化
	}
}
