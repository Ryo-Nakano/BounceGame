using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour {

	[SerializeField] GameObject player;
	[SerializeField] GameObject playerStatus;
	Image playerColor;//取得したImageコンポーネントを格納しておく為の変数
	Image playerStatusImage;

	//変更する色を格納しておく為の変数
	Color color1 = new Color(255f / 255f, 0f / 255f, 0f / 255f, 1f);
	Color color2 = new Color(233f/255f, 147f/255f, 0f, 1f);
	Color color3 = new Color(243f/255f, 52f/255f, 255f/255f, 1f);
	Color color4 = new Color(125f/255f, 59f/255f, 255f, 1f);
	Color color5 = new Color(0f, 210f/ 255f, 196f/ 255f, 1f);
	Color color6 = new Color(0f, 121f/ 255f, 0f, 1f);
	Color color7 = new Color(209f/ 255f, 233f/ 255f, 0f, 1f);
	Color color8 = new Color(127f/ 255f, 0f, 56f/ 255f, 1f);
	Color color9 = new Color(155f/ 255f, 0f, 139f/ 255f, 1f);
	Color color10 = new Color(0f, 195f / 255f, 16f / 255f, 1f);



    //色記憶用変数
	float savedR;
	float savedG;
	float savedB;

	// Use this for initialization
	void Start () {
		playerColor = player.GetComponent<Image>();
		playerStatusImage = playerStatus.GetComponent<Image>();

		if(PlayerPrefs.HasKey("r"))
		{
			savedR = PlayerPrefs.GetFloat("r");
            savedG = PlayerPrefs.GetFloat("g");
            savedB = PlayerPrefs.GetFloat("b");
            playerColor.color = new Color(savedR, savedG, savedB, 1f);
			playerStatusImage.color = new Color(savedR, savedG, savedB, 1f);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}



    //=====以下、PlayerのColorを変える関数=====

	public void ChangePlayerColor1()
	{
		playerColor.color = color1;
		playerStatusImage.color = color1;
		PlayerPrefs.SetFloat("r", color1.r);
		PlayerPrefs.SetFloat("g", color1.g);
		PlayerPrefs.SetFloat("b", color1.b);
	}

	public void ChangePlayerColor2()
    {
        playerColor.color = color2;
		playerStatusImage.color = color2;
		PlayerPrefs.SetFloat("r", color2.r);
        PlayerPrefs.SetFloat("g", color2.g);
        PlayerPrefs.SetFloat("b", color2.b);
    }

	public void ChangePlayerColor3()
    {
        playerColor.color = color3;
		playerStatusImage.color = color3;
		PlayerPrefs.SetFloat("r", color3.r);
        PlayerPrefs.SetFloat("g", color3.g);
        PlayerPrefs.SetFloat("b", color3.b);
    }

	public void ChangePlayerColor4()
    {
        playerColor.color = color4;
		playerStatusImage.color = color4;
		PlayerPrefs.SetFloat("r", color4.r);
        PlayerPrefs.SetFloat("g", color4.g);
        PlayerPrefs.SetFloat("b", color4.b);
    }

	public void ChangePlayerColor5()
    {
        playerColor.color = color5;
		playerStatusImage.color = color5;
		PlayerPrefs.SetFloat("r", color5.r);
        PlayerPrefs.SetFloat("g", color5.g);
        PlayerPrefs.SetFloat("b", color5.b);
    }

	public void ChangePlayerColor6()
    {
        playerColor.color = color6;
		playerStatusImage.color = color6;
		PlayerPrefs.SetFloat("r", color6.r);
        PlayerPrefs.SetFloat("g", color6.g);
        PlayerPrefs.SetFloat("b", color6.b);
    }

	public void ChangePlayerColor7()
    {
        playerColor.color = color7;
		playerStatusImage.color = color7;
		PlayerPrefs.SetFloat("r", color7.r);
        PlayerPrefs.SetFloat("g", color7.g);
        PlayerPrefs.SetFloat("b", color7.b);
    }

	public void ChangePlayerColor8()
    {
        playerColor.color = color8;
		playerStatusImage.color = color8;
		PlayerPrefs.SetFloat("r", color8.r);
        PlayerPrefs.SetFloat("g", color8.g);
        PlayerPrefs.SetFloat("b", color8.b);
    }

	public void ChangePlayerColor9()
    {
        playerColor.color = color9;
		playerStatusImage.color = color9;
		PlayerPrefs.SetFloat("r", color9.r);
        PlayerPrefs.SetFloat("g", color9.g);
        PlayerPrefs.SetFloat("b", color9.b);
    }

	public void ChangePlayerColor10()
    {
        playerColor.color = color10;
		playerStatusImage.color = color10;
		PlayerPrefs.SetFloat("r", color10.r);
        PlayerPrefs.SetFloat("g", color10.g);
        PlayerPrefs.SetFloat("b", color10.b);
    }
}
