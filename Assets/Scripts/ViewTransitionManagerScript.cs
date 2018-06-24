using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTransitionManagerScript : MonoBehaviour {

	[SerializeField] GameObject view2;//View2をUnityからアタッチ
	Animator animator;//取得したAnimatorを格納しておく為の変数

	[SerializeField] GameObject changeSkinText;
	[SerializeField] GameObject tapToStartText;
	[SerializeField] GameObject rankingDataText;
	[SerializeField] GameObject playerStatus;

	// Use this for initialization
	void Start () {
		animator = view2.gameObject.GetComponent<Animator>();//View2についてるAnimatorを取得→変数animatorに格納
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //View2に遷移する為の関数
	public void GoToView2()
	{
		changeSkinText.SetActive(false);
		tapToStartText.SetActive(false);
		rankingDataText.SetActive(false);
		playerStatus.SetActive(false);
		animator.SetBool("running", true);
		Debug.Log("GoToView2");
	}

    //View1に戻る為の関数
	public void BackToView1()
    {
		animator.SetBool("running", false);
		changeSkinText.SetActive(true);
        tapToStartText.SetActive(true);
		rankingDataText.SetActive(true);
		playerStatus.SetActive(true);
		Debug.Log("BackToView1");
    }
}
