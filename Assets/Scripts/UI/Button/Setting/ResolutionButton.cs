using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ResolutionButton : SettingButton {

	public Vector2 resolution;

	void Start ()
	{
		InitInstance();
	}

	void InitInstance()
	{
		InitSettingButton();
		_moreOptions = GameObject.FindWithTag("Settings/Resolutions").transform.FindChild("MoreResolution");

		if (buttonID == ButtonID.RESOLUTION_BUTTON)
		{
			settingButtons.Add(this);
			_selectorButton = gameObject;
			_selectorButton_Text =	_selectorButton.transform.GetChild(0).GetComponent<Text>();
			_selectorButton_Text.text = Screen.currentResolution.width + " x " +   Screen.currentResolution.height;
		} else {
			_selectorButton = GameObject.FindWithTag("Container/SettingsContainer/Resolution/CurrentResolution");
			_selectorButton_Text =	_selectorButton.transform.GetChild(0).GetComponent<Text>();
		}
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (buttonID == ButtonID.RESOLUTION_BUTTON)
		{
			_selectorButton_Text.text = Screen.width  + " x " +   Screen.height;
		}
	}

	/// <summary>
	/// Overrides the on pointer enter from base class.
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerEnter(PointerEventData data)
	{
		base.OnPointerEnter(data);
	}
	/// <summary>
	/// Overrides the on pointer exit from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerExit(PointerEventData data)
	{
		base.OnPointerExit(data);
	}

	/// <summary>
	/// Overrides the on pointer click from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerClick(PointerEventData data)
	{

		base.OnPointerClick(data);

		if (buttonID == ButtonID.RESOLUTION_BUTTON)
		{
		}

		if (buttonID == ButtonID.RESOLUTION_BUTTON_OPTION)
		{
			_selectorButton_Text.text = resolution.x + " x " + resolution.y;
			GameController.Instance.WindowResolution = resolution;
			Screen.SetResolution((int)resolution.x, (int)resolution.y, Screen.fullScreen);

		}
		//	SetActive(_moreOptions.gameObject, !_moreOptions.gameObject.activeSelf);
	}



}
