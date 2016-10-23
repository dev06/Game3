using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BackButton : SettingButton {



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
		if (EventManager.OnSettingUnactive != null)
		{
			EventManager.OnSettingUnactive();
		}

		GameController.Instance.menuActive = MenuActive.PAUSE;
		GameController.Instance.EnableMenu(GameController.Instance.menuActive);
	}

}
