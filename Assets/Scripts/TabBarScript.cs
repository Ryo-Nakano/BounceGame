using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabBarScript : MonoBehaviour {

	Toggle toggle;
	private GameObject _label;
	private Text tLabel;

	Color white = new Color(255f / 255f, 255f / 255f, 250f / 255f);
	Color gray = new Color(140f / 255f, 140f / 250f, 140f / 255f);

	// Use this for initialization
	void Start () {
		toggle = this.gameObject.GetComponent<Toggle>();
		_label = transform.Find("Label").gameObject;//子要素のLabel取得
		tLabel = _label.GetComponent<Text>();//子要素のTextコンポーネント取得

		ChangeTabColor();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeTabColor()
	{
		if (toggle.isOn == true)
        {
			tLabel.color = white;
        }
        else//isOn == falseの時
        {
			tLabel.color = gray;
        }
	}
}
