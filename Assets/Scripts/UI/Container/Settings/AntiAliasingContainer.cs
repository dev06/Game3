using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class AntiAliasingContainer : Container {


	public GameObject _parent;
	void Start ()
	{
		Init();
		_parent.GetComponent<RectTransform>().sizeDelta = new Vector3(_parent.GetComponent<RectTransform>().sizeDelta.x, 4 * 10, 1);
		for (int i = 0; i < 4; i++)
		{
			GameObject _al = Instantiate(Constants.AA_Option, Vector3.zero, Quaternion.identity) as GameObject;
			_al.transform.SetParent(_parent.transform);
			_al.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -i * 10, 0);
			_al.GetComponent<RectTransform>().localScale = new Vector3(.18f, .18f, 1);
			_al.GetComponent<AntiAliasingButton>().antiAliasing = (int)Mathf.Pow(2, i);
			_al.transform.GetChild(0).transform.GetComponent<Text>().text = SwitchText(i);
		}
	}

	string SwitchText(int i)
	{
		switch (i)
		{
			case 0:
			{
				return "Disabled";
			}
			case 1:
			{
				return "2x multi sampling";
			}
			case 2:
			{
				return "4x multi sampling";
			}
			case 3:
			{
				return "8x multi sampling";
			}
		}

		return "";
	}

	// Update is called once per frame
	void Update () {

	}
}
