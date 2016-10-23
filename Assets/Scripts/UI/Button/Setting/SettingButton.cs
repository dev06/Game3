using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SettingButton : ButtonEventHandler {

	public bool isActive;
	public static List<SettingButton>settingButtons = new List<SettingButton>();
	protected Transform _moreOptions; // the drop down options
	protected GameObject _selectorButton;
	protected Text _selectorButton_Text;
	protected GameObject _selectorCheckMark;

	public Transform MoreOptions { get {return _moreOptions; }}
	void Start ()
	{
		InitSettingButton();
	}

	protected void InitSettingButton()
	{
		Init();
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
		if (_moreOptions != null)
		{
			for (int i = 0; i < settingButtons.Count; i++)
			{
				if (settingButtons[i].MoreOptions != null)
				{
					if (settingButtons[i].gameObject == _selectorButton)
					{
						SetActive(_moreOptions.gameObject, !_moreOptions.gameObject.activeSelf);
					} else {
						SetActive(settingButtons[i].MoreOptions.gameObject, false);
					}
				}
			}
		}
	}

	public void SetOtherOptionUnActive(GameObject _instance)
	{

	}

}
