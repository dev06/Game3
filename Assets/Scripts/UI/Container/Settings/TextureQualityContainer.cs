using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TextureQualityContainer : Container {

	public GameObject _parent;
	void Start () {
		Init();
		_parent.GetComponent<RectTransform>().sizeDelta = new Vector3(_parent.GetComponent<RectTransform>().sizeDelta.x, 4 * 10, 1);
		for (int i = 0; i < 4; i++)
		{
			GameObject _al = Instantiate(Constants.TextureQuality_Option, Vector3.zero, Quaternion.identity) as GameObject;
			_al.transform.SetParent(_parent.transform);
			_al.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -i * 10, 0);
			_al.GetComponent<RectTransform>().localScale = new Vector3(.18f, .18f, 1);
			_al.GetComponent<TextureQualityButton>().textureQuality = i;
			_al.transform.GetChild(0).transform.GetComponent<Text>().text = SwitchText(i);
		}
	}

	string SwitchText(int i)
	{
		switch (i)
		{
		case 0:
			{
				return "Full Res";
			}
		case 1:
			{
				return "Half Res";
			}
		case 2:
			{
				return "Quarter Res";
			}
		case 3:
			{
				return "Eighth Res";
			}
		}

		return "";
	}
	// Update is called once per frame
	void Update () {

	}
}
