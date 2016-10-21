﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ResolutionButton : ButtonEventHandler {

	public Vector2 resolution;

	private Transform _moreResolution;

	// members only for current resolution button
	private GameObject _dropDownIcon;
	private GameObject _currentResoultionButton;
	private Text _currentResoultionButtonText;
	private Vector3 _dropDownIcon_Rotation;


	void Start () {
		Init();
		_moreResolution = transform.parent.transform.FindChild("MoreResolution");
		if (buttonID == ButtonID.RESOLUTION_BUTTON)
		{
			_dropDownIcon = transform.FindChild("dropDownIcon").gameObject;
			_dropDownIcon_Rotation = Vector3.zero;
			_currentResoultionButton = _dropDownIcon.transform.parent.gameObject;
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
		if (buttonID == ButtonID.RESOLUTION_BUTTON)
		{
			_dropDownIcon.transform.rotation = Quaternion.Lerp(_dropDownIcon.transform.rotation, Quaternion.Euler(_dropDownIcon_Rotation), Time.deltaTime * 10.0f);
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

			_moreResolution.gameObject.SetActive(!_moreResolution.gameObject.activeSelf);
			if (_moreResolution.gameObject.activeSelf)
			{
				_dropDownIcon_Rotation = new Vector3(0, 0, -180);
			} else {
				_dropDownIcon_Rotation = new Vector3(0, 0, 0);
			}
		}

		if (buttonID == ButtonID.RESOLUTION_BUTTON_OPTION)
		{
			_currentResoultionButtonText.text = resolution.x + " x " + resolution.y;
			Screen.SetResolution((int)resolution.x, (int)resolution.y, Screen.fullScreen);
		}
	}


	public void SetActive(bool b)
	{
		gameObject.SetActive(b);
	}



}
