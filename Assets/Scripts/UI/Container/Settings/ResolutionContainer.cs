using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ResolutionContainer : MonoBehaviour {

	public GameObject _parent;
	void Start ()
	{
		//_parent = GameObject.FindWithTag("Container/SettingsContainer").transform.FindChild("Resolution").transform.gameObject;

		Resolution[] resolutions = Screen.resolutions;
		_parent.GetComponent<RectTransform>().sizeDelta = new Vector3(_parent.GetComponent<RectTransform>().sizeDelta.x, resolutions.Length * 10, 1);
		for (int i = 0; i < resolutions.Length; i++)
		{
			GameObject _res = Instantiate(Constants.Resolution_Option, Vector3.zero, Quaternion.identity) as GameObject;
			_res.transform.SetParent(_parent.transform);
			_res.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -i * 10, 0);
			_res.GetComponent<RectTransform>().localScale = new Vector3(.18f, .18f, 1);
			_res.transform.GetChild(0).transform.GetComponent<Text>().text = resolutions[i].width + "x" + resolutions[i].height;
		}
		foreach (Resolution res in resolutions) {
			Debug.LogError(res.width + "x" + res.height);
		}

		Debug.LogError(Screen.resolutions.Length);

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T))
		{
			GameObject.Find("SettingsCanvas").GetComponent<Canvas>().enabled = !GameObject.Find("SettingsCanvas").GetComponent<Canvas>().enabled;
		}
	}
}
