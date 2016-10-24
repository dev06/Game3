//Devan Patel
//Applications and Scripting
//Sep.12.2016
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MenuButton : ButtonEventHandler {

	private float _speed = 50.0f;

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

	}
	/// <summary>
	/// Overrides the on pointer exit from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerExit(PointerEventData data)
	{


	}

	/// <summary>
	/// Overrides the on pointer click from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerClick(PointerEventData data)
	{
		base.OnPointerClick(data);

		if (buttonID == ButtonID.NEWGAME)
		{
			if (EventManager.OnNewGame != null)
			{
				EventManager.OnNewGame();
			}

		} else if (buttonID == ButtonID.LOADGAME)
		{
			if (EventManager.OnLoadGame != null)
			{
				EventManager.OnLoadGame();
			}

		} else if (buttonID == ButtonID.SETTINGS)
		{
			// if (EventManager.OnSetting != null)
			// {
			// 	EventManager.OnSetting();
			// }

			if (EventManager.OnSettingActive != null)
			{
				EventManager.OnSettingActive();
			}

		} else if (buttonID == ButtonID.CREDIT)
		{
			if (EventManager.OnCredit != null)
			{
				EventManager.OnCredit();
			}

		} else if (buttonID == ButtonID.QUIT)
		{
			Application.Quit();
		}
	}
}
