using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class AntiAliasingButton : SettingButton {

	public int antiAliasing;
	void Start ()
	{
		InitInstance();
	}

	void InitInstance()
	{
		InitSettingButton();
		_moreOptions = GameObject.FindWithTag("Settings/AA").transform.FindChild("MoreAntiAliasing");

		if (buttonID == ButtonID.AA_BUTTON)
		{
			settingButtons.Add(this);
			_selectorButton = gameObject;
			_selectorButton_Text =	_selectorButton.transform.GetChild(0).GetComponent<Text>();
			_selectorButton_Text.text = SwitchText(antiAliasing);
		} else {
			_selectorButton = GameObject.FindWithTag("Container/SettingsContainer/AntiAliasing/CurrentAntiAliasing");
			_selectorButton_Text =	_selectorButton.transform.GetChild(0).GetComponent<Text>();

		}
	}

	void Update()
	{
		if (_selectorButton != null)
			_selectorButton_Text.text = SwitchText((int)Mathf.Log(QualitySettings.antiAliasing, 2));
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


	/// <summary>
	/// Overrides the on pointer click from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerClick(PointerEventData data)
	{

		base.OnPointerClick(data);

		if (buttonID == ButtonID.AA_BUTTON)
		{

		}

		if (buttonID == ButtonID.AA_BUTTON_OPTION)
		{
			QualitySettings.antiAliasing = antiAliasing;
			_selectorButton_Text.text = SwitchText((int)Mathf.Log(QualitySettings.antiAliasing, 2));
		}
	}
}
