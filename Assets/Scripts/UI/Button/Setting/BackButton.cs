using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BackButton : SettingButton {


	private MenuActive _owner;

	void Start ()
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
		if (_owner == MenuActive.SETTING)
		{
			if (EventManager.OnSettingUnactive != null)
			{
				EventManager.OnSettingUnactive();
			}
		}

		else
		{
			if (EventManager.OnCreditUnactive != null)
			{
				EventManager.OnCreditUnactive();
			}
			Debug.Log("Credit back button pressed");
		}
	}

	public void SetOwner(MenuActive _menu)
	{
		_owner = _menu;
	}

}
