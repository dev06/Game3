using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TextureQualityButton : SettingButton {

	public int textureQuality;
	void Start ()
	{
		InitInstance();
	}

	void InitInstance()
	{
		InitSettingButton();
		_moreOptions = GameObject.FindWithTag("Settings/TextureQuality").transform.FindChild("MoreTextureQuality");
		Constants.TextureQuality = 0;
		if (buttonID == ButtonID.TEXTURE_QUALITY_BUTTON)
		{
			settingButtons.Add(this);
			_selectorButton = gameObject;
			_selectorButton_Text =	_selectorButton.transform.GetChild(0).GetComponent<Text>();
			_selectorButton_Text.text = SwitchText(textureQuality);
		} else {
			_selectorButton = GameObject.FindWithTag("Container/SettingsContainer/TextureQuality/CurrentTextureQuality");
			_selectorButton_Text =	_selectorButton.transform.GetChild(0).GetComponent<Text>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (_selectorButton != null) {
			_selectorButton_Text.text = SwitchText(Constants.TextureQuality);
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

	/// <summary>
	/// Overrides the on pointer click from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerClick(PointerEventData data)
	{

		base.OnPointerClick(data);

		if (buttonID == ButtonID.TEXTURE_QUALITY_BUTTON)
		{
		}

		if (buttonID == ButtonID.TEXTURE_QUALITY_OPTION_BUTTON)
		{
			Constants.TextureQuality = textureQuality;
			QualitySettings.masterTextureLimit = Constants.TextureQuality;
			_selectorButton_Text.text = SwitchText(QualitySettings.masterTextureLimit);
		}

		//SetActive(_moreOptions.gameObject, !_moreOptions.gameObject.activeSelf);
	}




}
