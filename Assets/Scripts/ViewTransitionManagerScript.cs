using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTransitionManagerScript : MonoBehaviour {

	[SerializeField] GameObject view2;//View2をUnityからアタッチ
	[SerializeField] GameObject view3;//View3をUnityからアタッチ
	Animator animatorView2;//取得したAnimatorを格納しておく為の変数
	Animator animatorView3;//取得したAnimatorを格納しておく為の変数
    
	[SerializeField] GameObject changeSkinText;
	[SerializeField] GameObject tapToStartText;
	[SerializeField] GameObject rankingDataText;
	[SerializeField] GameObject playerStatus;

	// Use this for initialization
	void Start () {
		animatorView2 = view2.gameObject.GetComponent<Animator>();//View2についてるAnimatorを取得→変数animatorに格納
		animatorView3 = view3.gameObject.GetComponent<Animator>();
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
		animatorView2.SetBool("running", true);
		Debug.Log("GoToView2");
	}

    //View1に戻る為の関数
	public void BackToView1()
    {
		animatorView2.SetBool("running", false);
		changeSkinText.SetActive(true);
        tapToStartText.SetActive(true);
		rankingDataText.SetActive(true);
		playerStatus.SetActive(true);
		Debug.Log("BackToView1");
    }

	public void GoToView3()
    {
        changeSkinText.SetActive(false);
        tapToStartText.SetActive(false);
        rankingDataText.SetActive(false);
        playerStatus.SetActive(false);
        animatorView3.SetBool("running", true);
        Debug.Log("GoToView3");
    }

	public void BackToView1_2()
    {
        animatorView3.SetBool("running", false);
        changeSkinText.SetActive(true);
        tapToStartText.SetActive(true);
        rankingDataText.SetActive(true);
        playerStatus.SetActive(true);
        Debug.Log("BackToView1");
    }
}
