using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class VSyncButton : SettingButton {

	public bool isVSyncOn;

	void Start () {
		Init();
		_selectorCheckMark = transform.FindChild("checkmark").gameObject;
		isVSyncOn = Constants.VSync;
		_selectorCheckMark.SetActive(isVSyncOn);
	}

	void Update ()
	{
		_selectorCheckMark.SetActive(Constants.VSync);
		QualitySettings.vSyncCount = (Constants.VSync) ? 1 : 0;
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
		Constants.VSync = !Constants.VSync;
		isVSyncOn = Constants.VSync;
		_selectorCheckMark.SetActive(isVSyncOn);
		QualitySettings.vSyncCount = (isVSyncOn) ? 1 : 0;
	}

}
