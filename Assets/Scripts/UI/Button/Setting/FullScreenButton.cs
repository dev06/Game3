using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class FullScreenButton : SettingButton {

	public bool isFullScreen;

	void Start () {
		Init();
		_selectorCheckMark = transform.FindChild("checkmark").gameObject;
		isFullScreen = Screen.fullScreen;
		_selectorCheckMark.SetActive(isFullScreen);
	}

	void Update ()
	{
		isFullScreen = Constants.FullScreen;
		_selectorCheckMark.SetActive(isFullScreen);
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
		Constants.FullScreen = !Constants.FullScreen;
		isFullScreen = Constants.FullScreen;
		_selectorCheckMark.SetActive(isFullScreen);
		Screen.fullScreen = isFullScreen;
		Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, isFullScreen);
	}

}
