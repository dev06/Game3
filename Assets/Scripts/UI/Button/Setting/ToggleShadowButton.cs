using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ToggleShadowButton : SettingButton {

	public bool isShadowOn;

	private GameObject _shadowQuality;
	void Start () {
		Init();
		isShadowOn = Constants.ToggleShadow;
		_selectorCheckMark = transform.FindChild("checkmark").gameObject;
		_selectorCheckMark.SetActive(isShadowOn);
		_shadowQuality = GameObject.FindWithTag("Settings/ShadowQuality").gameObject;
	}

	void Update ()
	{
		isShadowOn = Constants.ToggleShadow;
		_selectorCheckMark.SetActive(isShadowOn);
		_shadowQuality.SetActive(isShadowOn);
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
		Constants.ToggleShadow = !Constants.ToggleShadow;
		isShadowOn = Constants.ToggleShadow;
		_selectorCheckMark.SetActive(isShadowOn);
		_shadowQuality.SetActive(isShadowOn);
		if (isShadowOn == false)
		{
			if (EventManager.OnShadowToggleUnactive != null)
			{
				EventManager.OnShadowToggleUnactive();
			}
		} else
		{
			if (EventManager.OnShadowToggleActive != null)
			{
				EventManager.OnShadowToggleActive();
			}
		}
	}
}
