using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class FullScreenButton : ButtonEventHandler {

	public bool isFullScreen;
	private GameObject _checkMark;
	void Start () {
		Init();
		_checkMark = transform.FindChild("checkmark").gameObject;
		isFullScreen = Screen.fullScreen;
		_checkMark.SetActive(isFullScreen);
	}

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
		isFullScreen = !isFullScreen;
		_checkMark.SetActive(isFullScreen);
		Screen.fullScreen = isFullScreen;
		Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, isFullScreen);
	}

}
