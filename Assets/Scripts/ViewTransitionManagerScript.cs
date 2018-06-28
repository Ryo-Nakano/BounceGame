using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTransitionManagerScript : MonoBehaviour {

	[SerializeField] GameObject view2;//View2をUnityからアタッチ
	[SerializeField] GameObject view3;//View3をUnityからアタッチ
	[SerializeField] GameObject view5;//View5をUnityからアタッチ
	Animator animatorView2;//取得したAnimatorを格納しておく為の変数
	Animator animatorView3;//取得したAnimatorを格納しておく為の変数
	Animator animatorView5;//取得したAnimatorを格納しておく為の変数
    
	[SerializeField] GameObject changeSkinText;
	[SerializeField] GameObject tapToStartText;
	[SerializeField] GameObject rankingDataText;
	[SerializeField] GameObject playerStatus;
	[SerializeField] GameObject changeUserNameText;

	// Use this for initialization
	void Start () {
		animatorView2 = view2.gameObject.GetComponent<Animator>();//View2についてるAnimatorを取得→変数animatorに格納
		animatorView3 = view3.gameObject.GetComponent<Animator>();
		animatorView5 = view5.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //View1→View2
	public void GoToView2()
	{
		changeSkinText.SetActive(false);
		tapToStartText.SetActive(false);
		rankingDataText.SetActive(false);
		playerStatus.SetActive(false);
		changeUserNameText.SetActive(false);
		animatorView2.SetBool("running", true);
		Debug.Log("GoToView2");
	}

    //View2→View1
	public void BackToView1()
    {
		animatorView2.SetBool("running", false);
		changeSkinText.SetActive(true);
        tapToStartText.SetActive(true);
		rankingDataText.SetActive(true);
		playerStatus.SetActive(true);
		changeUserNameText.SetActive(true);
		Debug.Log("BackToView1");
    }

    //View1→View3
	public void GoToView3()
    {
        changeSkinText.SetActive(false);
        tapToStartText.SetActive(false);
        rankingDataText.SetActive(false);
        playerStatus.SetActive(false);
		changeUserNameText.SetActive(false);
        animatorView3.SetBool("running", true);
        Debug.Log("GoToView3");
    }

    //View3→View1
	public void BackToView1_2()
    {
        animatorView3.SetBool("running", false);
        changeSkinText.SetActive(true);
        tapToStartText.SetActive(true);
        rankingDataText.SetActive(true);
        playerStatus.SetActive(true);
		changeUserNameText.SetActive(true);
        Debug.Log("BackToView1");
    }

	//View1→View5
    public void GoToView5()
    {
        changeSkinText.SetActive(false);
        tapToStartText.SetActive(false);
        rankingDataText.SetActive(false);
        playerStatus.SetActive(false);
		changeUserNameText.SetActive(false);
        animatorView5.SetBool("running", true);
        Debug.Log("GoToView5");
    }

	//View5→View1
    public void BackToView1_3()
    {
        animatorView5.SetBool("running", false);
        changeSkinText.SetActive(true);
        tapToStartText.SetActive(true);
        rankingDataText.SetActive(true);
        playerStatus.SetActive(true);
		changeUserNameText.SetActive(true);
        Debug.Log("BackToView1");
    }
}
