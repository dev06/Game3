//Devan Patel
//Applications and Scripting
//Sep.12.2016
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MenuButton : ButtonEventHandler {

	private float _speed = 50.0f;


	void OnEnable()
	{
		EventManager.OnLoginSuccess += OnLoginSuccess;
	}

	void OnDisable()
	{
		EventManager.OnLoginSuccess -= OnLoginSuccess;
	}

	void Start ()
	{
		Init();

	}

	private void OnLoginSuccess()
	{
		if (buttonID == ButtonID.LOADGAME)
		{
			SetInteractable(XmlWrite.DoesFileExists(XmlLoader.SAVE_DATA_PATH));
		}
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

		if (buttonID != ButtonID.LOADGAME)
		{

			base.OnPointerEnter(data);
		} else
		{
			if (isInteractable)
			{

				base.OnPointerEnter(data);
			}

		}

	}
	/// <summary>
	/// Overrides the on pointer exit from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerExit(PointerEventData data)
	{
		if (buttonID != ButtonID.LOADGAME)
		{

			base.OnPointerExit(data);
		} else
		{
			if (isInteractable)
			{

				base.OnPointerExit(data);
			}
		}

		//WORKING ON INTERACTIBLE FOR LOAD BUTTON

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
				EventManager.OnNewGame(buttonID);
			}

		} else if (buttonID == ButtonID.LOADGAME)
		{
			if (isInteractable)
			{
				if (EventManager.OnLoadGame != null)
				{
					EventManager.OnLoadGame(buttonID);
				}
			}

		} else if (buttonID == ButtonID.SETTINGS)
		{

			if (EventManager.OnSettingActive != null)
			{
				EventManager.OnSettingActive();
			}

		} else if (buttonID == ButtonID.CREDIT)
		{
			if (EventManager.OnCreditActive != null)
			{
				EventManager.OnCreditActive();
			}

		} else if (buttonID == ButtonID.QUIT)
		{
			Application.Quit();
		}
	}
}
