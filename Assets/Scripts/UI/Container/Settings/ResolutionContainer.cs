using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ResolutionContainer : MonoBehaviour {

	public GameObject _parent;
	private float _spacing;


	void Start ()
	{
		//_parent = GameObject.FindWithTag("Container/SettingsContainer").transform.FindChild("Resolution").transform.gameObject;
		_spacing = 8.488f;
		Resolution[] resolutions = Screen.resolutions;
		int _count = resolutions.Length;
		_parent.GetComponent<RectTransform>().sizeDelta = new Vector3(_parent.GetComponent<RectTransform>().sizeDelta.x, _count * _spacing, 1);
		for (int i = 0; i < _count; i++)
		{
			GameObject _res = Instantiate(Constants.Resolution_Option, Vector3.zero, Quaternion.identity) as GameObject;
			_res.transform.SetParent(_parent.transform);
			_res.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -i * _spacing, 0);
			_res.GetComponent<RectTransform>().localScale = new Vector3(.18f, .18f, 1);
			_res.GetComponent<ResolutionButton>().resolution = new Vector2(resolutions[i].width, resolutions[i].height);
			_res.transform.GetChild(0).transform.GetComponent<Text>().text = resolutions[i].width + " x " + resolutions[i].height ;
		}


	}

}
