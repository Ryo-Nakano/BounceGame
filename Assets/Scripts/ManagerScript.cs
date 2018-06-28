using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{

	public bool isPlaying;//ゲームプレイ可能かどうかのフラグ
	bool isResult;//Result画面に行くかどうかのフラグ
	bool gameStart;

	[SerializeField] Text infoText;
	public Text remainText;
	[SerializeField] Text timeText;
	[SerializeField] Text clearText;
	[SerializeField] Text countdownText;
	float countdownTimer = 3.0f;

	[SerializeField] Button startButton;
	[SerializeField] Button changeSkinButton;
	[SerializeField] Button rankingDataButton;
	[SerializeField] GameObject changeUserNameText;

	[SerializeField] GameObject gems;
	[SerializeField] GameObject gem;//Instantiateする為にUnityからアタッチ

	[SerializeField] GameObject view4;//Result画面をUnityからアタッチ
	Animator view4Animator;//取得したview4のAnimatorを格納しておく為の変数

	DataManager dataManager;
	[SerializeField] Text bestTimeText;
	[SerializeField] Text lastTimeText;

	ViewTransitionManagerScript viewTransitionManagerScript;

	[SerializeField] Button backToMenuButton;//初回起動時だけBackButton無効化する為の変数

	//gemをランダム生成する時に使う変数
	int rangeX = 825;
	int rangeY = 325;

	public int remain;//残りアイテム数

	public float timer;
	float resultTimer;//Result画面に移動するタイミングを測るタイマー
	[SerializeField] float goResultInterval;//何秒後にResultに移行するか決定する変数

	// Use this for initialization
	void Start()
	{
		view4Animator = view4.GetComponent<Animator>();
		dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();

		viewTransitionManagerScript = GameObject.Find("ViewTransitionManager").GetComponent<ViewTransitionManagerScript>();

		GenerateGems();//Gemをランダムに12個生成
		init();//各種初期化

		//NCMB関連の処理
		dataManager.PlayCount();//Play回数計算(playCount)
		dataManager.CulculateClerTime();//Clear時間系計算(sum, ave)
		dataManager.FindBestTime();//BestTime拾ってくる(bestTime)
		dataManager.SaveNCMB();//NCMBにSave

		PlayerPrefs.DeleteKey("isFirst");//Key消して毎回初回起動にしてる【test】
		CheckIsFirst();//初回起動かどうかをチェックする関数
	}

	// Update is called once per frame
	void Update()
	{
		GameManager();
	}

	void GameManager()
	{
		if (gameStart == true)
		{
			countdownTimer -= Time.deltaTime;//カウントダウン開始
			if(countdownTimer > 2.0f)
			{
				countdownText.text = "3";
			}
			else if(countdownTimer <= 2.0f && countdownTimer > 1.0)
			{
				countdownText.text = "2";
			}
			else if (countdownTimer <= 1.0f && countdownTimer > 0f)
            {
                countdownText.text = "1";
            }
			else//countdownTimer < 0の時
			{
				isPlaying = true;
				if(isPlaying == true)
				{
					gems.SetActive(true);//生成後、無効化にしていたgemsを有効化
                    countdownText.text = "";
                    timer += Time.deltaTime;//タイマー開始
                    timeText.text = "Time : " + timer.ToString("f2");
                    remainText.text = "Remain : " + remain;

                    if (remain <= 0)//item無くなったら
                    {
                        isPlaying = false;
						gameStart = false;
                        clearText.text = "C L E A R";
                        isResult = true;
                    }
				}
			}
		}

		if(isResult == true)
		{
			resultTimer += Time.deltaTime;//resultTimerスタート

			if(resultTimer > goResultInterval)//ゲームクリアから一定時間後
			{
				//この中のコードは1回だけ呼ばれる！
				remainText.text = "";
				timeText.text = "";
				clearText.text = "";
                
                //PlayLogへのデータ蓄積
				dataManager.AddRow(timer);//timerの値を引数にとって、AddRowを呼ぶ！
				dataManager.Save();//PlayLogにプレイデータの保存！

				//Result画面への表示
				lastTimeText.text = "Last Time : " + timer.ToString("f2");//LastTime表示
				dataManager.FindBestTime();//PlayLogからBestTimeを探してくる→変数bestTimeに格納
				bestTimeText.text = "Best Time : " + dataManager.bestTime;//BestTime表示

				view4Animator.SetBool("running", true);//Result画面をアニメーション表示
                
				isResult = false;
			}
		}
	}

	//色々初期化
	void init()
	{
		gameStart = false;
		isResult = false;
		isPlaying = false;//最初はfalse
		remainText.text = "";
		timeText.text = "";
		clearText.text = "";

		remain = gems.transform.childCount;//itemの数を変数remainに格納！
	}

	//Startボタン押された時に呼ばれる
	public void StartButton()
	{
		gameStart = true;
		infoText.text = "";
		timeText.text = "Time : " + timer.ToString("f2");
		remainText.text = "Remain : " + remain;

		startButton.gameObject.SetActive(false);//button押されたら無効化
		changeSkinButton.gameObject.SetActive(false);//ChangeSkinButton無効化
		rankingDataButton.gameObject.SetActive(false);//RankingDataButton無効化
		changeUserNameText.SetActive(false);//changeUserNameTextを無効化
	}

    //Restartボタン押された時に呼ばれる関数
	public void RestartButton()
	{
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;//現在のシーン番号取得
        SceneManager.LoadScene(sceneIndex);//現在のシーン再ロード"
	}

	//Gemを12個生成する関数(場所ランダム)
	void GenerateGems()
	{
		for (int i = 0; i < 12; i++)//12回回す
		{
			GameObject obj = Instantiate(gem) as GameObject;//gemを生成→GameObject型にキャスト→変数oblに格納
			obj.transform.SetParent(gems.transform);//生成したgemの親としてgemsを指定
			obj.transform.localPosition = new Vector2(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY));
		}
		gems.SetActive(false);//gem12個生成後、gemsを一旦無効化
	}


    //Result画面の制御する関数
	void Result()
	{ 
		
	}


	//初回起動かどうかを判定する関数
	int isFirst = 0;//初回起動かどうかを判断するフラグ(0→初回起動, 1→2回目以降)

	void CheckIsFirst()
    {
        if (PlayerPrefs.HasKey("isFirst") == false)//初回起動の時
        {
            Debug.Log("初回！");
			viewTransitionManagerScript.GoToView5();
            backToMenuButton.gameObject.SetActive(false);//戻るボタンを非アクティブに(UserName決めるまでゲーム始められない)
            //firstTimeText.text = "先ずはメロスに名付けろ！";
            isFirst = 1;
            PlayerPrefs.SetInt("isFirst", isFirst);
        }
    }
}
