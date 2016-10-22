using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class AntiAliasingButton : ButtonEventHandler {

	public int antiAliasing;

	private GameObject _currentAAButton;
	private Text _currentAAButtonText;

	private Transform _moreAA;
	void Start ()
	{
		Init();
		_moreAA = GameObject.FindWithTag("Settings/AA").transform.FindChild("MoreAntiAliasing");
		if (buttonID == ButtonID.AA_BUTTON)
		{

			_currentAAButton = gameObject;
			_currentAAButtonText =	_currentAAButton.transform.GetChild(0).GetComponent<Text>();
			_currentAAButtonText.text = SwitchText(antiAliasing);
		} else {
			_currentAAButton = GameObject.FindWithTag("Container/SettingsContainer/AntiAliasing/CurrentAntiAliasing");
			_currentAAButtonText =	_currentAAButton.transform.GetChild(0).GetComponent<Text>();

		}
	}

	// Update is called once per frame
	void Update ()
	{

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

			SetActive(!_moreAA.gameObject.activeSelf);
		}

		if (buttonID == ButtonID.AA_BUTTON_OPTION)
		{
			QualitySettings.antiAliasing = antiAliasing;
			_currentAAButtonText.text = SwitchText((int)Mathf.Log(antiAliasing, 2));
		}

	}


	public void SetActive(bool b)
	{
		_moreAA.gameObject.SetActive(b);
	}

}
