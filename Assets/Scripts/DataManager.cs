using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//←これはなんだ？
using NCMB;

//PlayLogをCSVファイルに貯めておく為のクラス！
public class DataManager : MonoBehaviour
{

    public static DataManager instance;
    public string[,] playLog;//string型の2次元配列playLogを定義→取得したcsvファイルを2次元配列に直してぶち込んでおく！

	ManagerScript managerScript;

    //Start関数より早く実行！
    void Awake()
    {
        //シングルトンデザインパターンにする！
        if (instance == null)
        {//最初の1回だけ呼ばれる実装！
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);//最初の1回以降は即削除される
        }
        Load();//CSVファイル"PlayLog"を変数playLogに格納！
    }

    void Start()
    {
		managerScript = GameObject.Find("Manager").GetComponent<ManagerScript>();//変数managerScriptにManagerScript格納しておく
    }




    //- * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - * - *




    //CSVファイルを読み込む関数
    public void Load()
    {
        playLog = csvManager.GetCsvData("CSV/PlayLog");//Resourcesフォルダ内のPlayLogを取得→2次元配列に変換して変数playLogの中に格納
    }

    //CSVファイルに書き込みを行う関数
    public void Save()
    {
        csvManager.WriteData("CSV/PlayLog.csv", playLog);
		Debug.Log("PlayLog Saved!!");
    }

    //playLogの要素数追加→要は行数追加！
	public void AddRow(float score)
    {
        int rowCount = playLog.GetLength(0);//行数取得！
        int colCount = playLog.GetLength(1);//列数獲得！

        //既存のものより1行だけ多い2次元配列を作成！
        string[,] array = new string[rowCount + 1, colCount];

        //今までのデータを全部ぶち込む！
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                array[i, j] = playLog[i, j];
            }
        }

        //新しいデータを追加
        array[rowCount, 0] = rowCount.ToString();//id列に追加
		array[rowCount, 1] = score.ToString("f2");//timeを追加(小数点以下第二位まで)
        
        playLog = array;//playLogにarrayを代入→playLog内容の更新！
    }


    //=====================playLogいい感じに拾って来て、いい感じに加工して、いい感じの変数に入れる関数！=====================

    //===【完】BestTimeを探してくる===
	public float bestTime;//ハイスコアを格納しておく為の変数(初期値0)

    public void FindBestTime()
    {
		bestTime = 8888f;//一旦クソでかい初期値入れとく

        for (int i = 0; i < playLog.GetLength(0) - 1; i++)//playLogの行数-1回だけ回す！
        {
			if (float.Parse(playLog[i + 1, 1]) < bestTime)//参照した値が手元に持ってるbestTimeよりも早かった時
            {
				bestTime = float.Parse(playLog[i + 1, 1]);//bestTimeの値を上書き！
            }
        }
    }


    //===【完】playCount拾って来る！===
    public int playCount;//総Play回数

    public void PlayCount()
    {
        playCount = playLog.GetLength(0) - 1;//総行数-1=総プレイ回数！
        Debug.Log("playCount : " + playCount);
    }


    //==========【完】Clear時間系計算する関数==========
	public float sum;//"合計"プレイ時間
	public float ave;//"平均"クリアTime

	public void CulculateClerTime()
    {
        for (int i = 0; i < playLog.GetLength(0) - 1; i++)
        {//playLogの行数-1回だけ回す！
			sum += float.Parse(playLog[i + 1, 1]);//プレイ時間合計
        }
		sum = float.Parse(sum.ToString("f2"));//変数sumにプレイ時間の合計を格納
        ave = float.Parse((sum / (playLog.GetLength(0) - 1)).ToString("f2"));//平均クリアTime

        Debug.Log("sum" + sum);
        Debug.Log("ave" + ave);
    }



    //=====================NCMBと通信、データの保存や取得をする関数=====================

    //-*-*- 使うKey一覧 *-*-*

    //▶︎PlayCount (総プレイ回数)
    //▶︎Ave (平均クリアTime)
    //▶︎Sum (合計プレイ時間)
	//▶︎BestTime

    //-*-*-*-*-*-*-*-*-*-*-*

    //NCMBにplayデータを保存する関数
    public void SaveNCMB()
    {
        //NCMBObjectのインスタンスを作成→変数ncmbObjに格納
        NCMBObject obj = new NCMBObject("OnlineRanking");//OnlineRankingテーブルのインスタンス作成！

        if (PlayerPrefs.HasKey("objectId") == true)//objectId持ってた時(2回目以降のセーブの時)
        {
            //Updateの処理
            NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("OnlineRanking");
            query.WhereEqualTo("objectId", PlayerPrefs.GetString("objectId"));
            query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
                if (e != null)
                {
                    //検索失敗時の処理
                    Debug.Log("ミスっとるで！");
                }
                else
                {
                    //値の更新
                    objList[0]["PlayCount"] = playCount;//プレイ回数
                    objList[0]["Ave"] = ave;//平均Door突破枚数
                    objList[0]["Sum"] = sum;//合計Door突破枚数
					objList[0]["BestTime"] = bestTime;//ベストタイム
                    objList[0].SaveAsync();//変更内容のsave
                }
            });
        }
        else//objectId持ってない時(初セーブの時)
        {
            //新しく行追加
            obj.Add("PlayCount", playCount);
            obj.Add("Ave", ave);
            obj.Add("Sum", sum);
			obj.Add("BestTime", bestTime);

            obj.SaveAsync((NCMBException e) => {//eには"例外(exeption)"が入ってる→来たらエラー来なかったらok！    
                if (e != null)//eが空でない時→エラーの時！
                {
                    //エラー時の処理
                    Debug.Log("NCMB Save Missed!");
                }
                else//eが空の時→成功した時！
                {
                    //成功時の処理
                    Debug.Log("NCMB Save Completed!!!");

                    //NCMBObjectのObjectIdを"objectId"キーでPlayerPrefsに保存(次回以降のセーブで同一行のデータを更新していく形にしたい為)
                    PlayerPrefs.SetString("objectId", obj.ObjectId);
                }
            });
        }
    }
}


