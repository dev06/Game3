using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ShadowQualityContainer : Container {



	public GameObject _parent;
	private float _spacing;
	void Start () {
		Init();
		_spacing = 8.488f;
		_parent.GetComponent<RectTransform>().sizeDelta = new Vector3(_parent.GetComponent<RectTransform>().sizeDelta.x, 4 * _spacing, 1);
		for (int i = 0; i < 4; i++)
		{
			GameObject _shadow = Instantiate(Constants.ShadowQuality_Option, Vector3.zero, Quaternion.identity) as GameObject;
			_shadow.transform.SetParent(_parent.transform);
			_shadow.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -i * _spacing, 0);
			_shadow.GetComponent<RectTransform>().localScale = new Vector3(.18f, .18f, 1);
			_shadow.GetComponent<ShadowQualityButton>().shadowQuality = i;
			_shadow.transform.GetChild(0).transform.GetComponent<Text>().text = SwitchText(i);
		}
	}

	string SwitchText(int i)
	{
		switch (i)
		{
			case 0:
			{
				return "Very Low";
			}
			case 1:
			{
				return "Low";
			}
			case 2:
			{
				return "Medium";
			}
			case 3:
			{
				return "High";
			}
		}

		return "";
	}
	// Update is called once per frame
	void Update () {

	}

	void OnDisable()
	{

		Debug.Log("fasf");
	}
}
