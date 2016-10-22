using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TextureQualityButton : ButtonEventHandler {

	public int textureQuality;
	private Transform _moreTextureQuality;
	private GameObject _dropDownIcon;
	private GameObject _currentTextureQualityButton;
	private Text _currentTextureQualityButtonText;
	private Vector3 _dropDownIcon_Rotation;
	void Start ()
	{
		Init();
		_moreTextureQuality = GameObject.FindWithTag("Settings/TextureQuality").transform.FindChild("MoreTextureQuality");
		if (buttonID == ButtonID.TEXTURE_QUALITY_BUTTON)
		{
			_dropDownIcon = transform.FindChild("dropDownIcon").gameObject;
			_dropDownIcon_Rotation = Vector3.zero;
			_currentTextureQualityButton = gameObject;
			_currentTextureQualityButtonText =	_currentTextureQualityButton.transform.GetChild(0).GetComponent<Text>();
			_currentTextureQualityButtonText.text = SwitchText(textureQuality);
		} else {
			_currentTextureQualityButton = GameObject.FindWithTag("Container/SettingsContainer/TextureQuality/CurrentTextureQuality");
			_currentTextureQualityButtonText =	_currentTextureQualityButton.transform.GetChild(0).GetComponent<Text>();
		}
	}

	// Update is called once per frame
	void Update () {
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
			SetActive(!_moreTextureQuality.gameObject.activeSelf);
		}

		if (buttonID == ButtonID.TEXTURE_QUALITY_OPTION_BUTTON)
		{
			QualitySettings.masterTextureLimit = textureQuality;
			_currentTextureQualityButtonText.text = SwitchText(textureQuality);
		}
	}

	public void SetActive(bool b)
	{
		_moreTextureQuality.gameObject.SetActive(b);
	}

}
