using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class LoginMenuButton : ButtonEventHandler {

	// Use this for initialization
	void Start () {
		Init();
	}

	// Update is called once per frame
	void Update () {

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

		//WORKING ON INTERACTIBLE FOR LOAD BUTTON

	}

	/// <summary>
	/// Overrides the on pointer click from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerClick(PointerEventData data)
	{
		base.OnPointerClick(data);

		if (buttonID == ButtonID.LOGIN)
		{
			if (EventManager.OnLoginButtonPress != null)
			{
				EventManager.OnLoginButtonPress();
			}
		}

		if (buttonID == ButtonID.REGISTER)
		{
			if (EventManager.OnRegisterButtonPress != null)
			{
				EventManager.OnRegisterButtonPress();
			}
		}


		if (buttonID == ButtonID.CREATE_MY_PROFILE)
		{
			if (EventManager.OnCreateProfileButtonPress != null)
			{
				EventManager.OnCreateProfileButtonPress();
			}
		}

	}
}
