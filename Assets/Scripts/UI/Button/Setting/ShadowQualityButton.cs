using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ShadowQualityButton : SettingButton {


	public int shadowQuality;

	private Light[] _lights;

	void OnEnable()
	{
		EventManager.OnShadowToggleUnactive -= OnShadowToggleUnactive;
		EventManager.OnShadowToggleActive -= OnShadowToggleActive;
		//ChangeShadowSettings(2);
	}

	void OnDisable()
	{
		EventManager.OnShadowToggleUnactive += OnShadowToggleUnactive;
		EventManager.OnShadowToggleActive += OnShadowToggleActive;
		//ChangeShadowSettings(0);
	}

	void Start ()
	{
		InitInstance();
		_lights = GameObject.FindObjectsOfType(typeof(Light)) as Light[];
		ChangeShadowSettings(3);
	}

	void InitInstance()
	{
		InitSettingButton();
		_moreOptions = GameObject.FindWithTag("Settings/ShadowQuality").transform.FindChild("MoreShadowQuality");

		if (buttonID == ButtonID.SHADOW_BUTTON)
		{
			settingButtons.Add(this);
			_selectorButton = gameObject;
			_selectorButton_Text =	_selectorButton.transform.GetChild(0).GetComponent<Text>();
			_selectorButton_Text.text = SwitchText(shadowQuality);
		} else {
			_selectorButton = GameObject.FindWithTag("Container/SettingsContainer/ShadowQuality/CurrentShadowQuality");
			_selectorButton_Text =	_selectorButton.transform.GetChild(0).GetComponent<Text>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (_selectorButton_Text != null)
		{
			_selectorButton_Text.text = SwitchText(Constants.ShadowQuality);
		}

		if (buttonID == ButtonID.SHADOW_BUTTON_OPTION)
		{
			ChangeShadowSettings(Constants.ShadowQuality);
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
	/// <summary>
	/// Overrides the on pointer click from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerClick(PointerEventData data)
	{

		base.OnPointerClick(data);



		if (buttonID == ButtonID.SHADOW_BUTTON_OPTION)
		{
			ChangeShadowSettings(shadowQuality);
		}


	}


	private void ChangeShadowSettings(int level)
	{
		switch (level)
		{
			case 0:
			{
				SetLightShadow(LightShadows.None);
				break;
			}
			case 1:
			{
				SetLightShadow(LightShadows.Hard);
				break;
			}
			case 2:
			{
				SetLightShadow(LightShadows.Soft);
				break;
			}
			case 3:
			{
				SetLightShadow(LightShadows.Soft);
				break;
			}
		}


		Constants.ShadowQuality = level;
	}

	private void SetLightShadow(LightShadows _shadowType)
	{
		if (_lights != null)
		{
			foreach (Light light in _lights)
			{
				if (light != null)
				{
					light.shadows = _shadowType;
				}
			}
		}
	}

	void OnShadowToggleUnactive()
	{
		if (_lights != null)
		{
			SetLightShadow(LightShadows.None);
		}

	}
	void OnShadowToggleActive()
	{
		if (_lights != null)
		{
			ChangeShadowSettings(0);
		}
	}
}
