using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManagerScript : MonoBehaviour {

	[SerializeField] GameObject view2;//View2をUnityからアタッチ
	Animator animator;//取得したAnimatorを格納しておく為の変数

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
		animator.SetBool("running", true);
		Debug.Log("GoToView2");
	}

    //View1に戻る為の関数
	public void BackToView1()
    {
		animator.SetBool("running", false);
		Debug.Log("BackToView1");
    }
}
