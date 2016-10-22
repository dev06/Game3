using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ResolutionButton : ButtonEventHandler {

	public Vector2 resolution;

	private Transform _moreResolution;

	// members only for current resolution button
	private GameObject _currentResoultionButton;
	private Text _currentResoultionButtonText;



	void Start () {
		Init();
		_moreResolution = GameObject.FindWithTag("Settings/Resolutions").transform.FindChild("MoreResolution");
		if (buttonID == ButtonID.RESOLUTION_BUTTON)
		{
			_currentResoultionButton = gameObject;
			_currentResoultionButtonText =	_currentResoultionButton.transform.GetChild(0).GetComponent<Text>();
			_currentResoultionButtonText.text = Screen.currentResolution.width + " x " +   Screen.currentResolution.height;
		} else {
			_currentResoultionButton = GameObject.FindWithTag("Container/SettingsContainer/Resolution/CurrentResolution");
			_currentResoultionButtonText =	_currentResoultionButton.transform.GetChild(0).GetComponent<Text>();
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

	/// <summary>
	/// Overrides the on pointer click from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerClick(PointerEventData data)
	{

		base.OnPointerClick(data);

		if (buttonID == ButtonID.RESOLUTION_BUTTON)
		{
			SetActive(!_moreResolution.gameObject.activeSelf);
		}

		if (buttonID == ButtonID.RESOLUTION_BUTTON_OPTION)
		{
			_currentResoultionButtonText.text = resolution.x + " x " + resolution.y;
			GameController.Instance.WindowResolution = resolution;
			Screen.SetResolution((int)resolution.x, (int)resolution.y, Screen.fullScreen);
		}
	}


	public void SetActive(bool b)
	{
		_moreResolution.gameObject.SetActive(b);
	}



}
