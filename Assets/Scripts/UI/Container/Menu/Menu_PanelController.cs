﻿using UnityEngine;
using System.Collections;

public class Menu_PanelController : MonoBehaviour {

	private GameObject _settingPanel;
	private GameObject _creditPanel;


	void OnEnable()
	{
		Menu_ButtonContainer.OnMenuContainerAnimFinished += OnButtonClick;
		EventManager.OnCreditUnactive += OnCreditUnactive;

	}

	void OnDisable()
	{
		Menu_ButtonContainer.OnMenuContainerAnimFinished -= OnButtonClick;
		EventManager.OnCreditUnactive -= OnCreditUnactive;
	}

	// this is also a test line for commit
	void Start ()
	{
	}

	void Update ()
	{

	}

	/// <summary>
	/// This method is called after transtion when menu button is pressed
	/// </summary>
	/// <param name="id"></param>
	private void OnButtonClick(ButtonID id)
	{

		switch (id)
		{

			// case ButtonID.NEWGAME:
			// {
			// 	GameController.Instance.HasGameStarted = true;
			// 	GameController.Instance.menuActive = MenuActive.GAME;
			// 	GameController.Instance.EnableMenu(GameController.Instance.menuActive);
			// 	Debug.Log("NEW GAME is called");
			// 	break;
			// }

			case ButtonID.CREDIT:
				{
					GameController.Instance.menuActive = MenuActive.CREDIT;
					GameController.Instance.EnableMenu(GameController.Instance.menuActive);
					break;
				}

			case ButtonID.NEWGAME:
				{
					//XmlWrite.DeleteFile();
					TextAsset asset = (TextAsset)(Resources.Load("GameData/Default"));
					XmlLoader.LoadDefaultXmlData(asset.text);
					GameController.Instance.HasGameStarted = true;
					GameController.Instance.menuActive = MenuActive.GAME;
					GameController.Instance.EnableMenu(GameController.Instance.menuActive);
					break;
				}
			case ButtonID.LOADGAME:
				{
					XmlLoader.LoadData();
					GameController.Instance.HasGameStarted = true;
					GameController.Instance.menuActive = MenuActive.GAME;
					GameController.Instance.EnableMenu(GameController.Instance.menuActive);
					break;
				}

				// case ButtonID.CREDIT:
				// 	{
				// 		GameController.Instance.menuActive = MenuActive.CREDIT;
				// 		GameController.Instance.EnableMenu(GameController.Instance.menuActive);
				// 		break;
				// 	}

		}


	}

	void OnCreditUnactive()
	{

		//_creditPanel.SetActive(!_creditPanel.activeSelf);
		//GameController.Instance.menuActive = MenuActive.MENU;
		//GameController.Instance.EnableMenu(GameController.Instance.menuActive);

		// _creditPanel.SetActive(!_creditPanel.activeSelf);
		// GameController.Instance.menuActive = MenuActive.MENU;
		// GameController.Instance.EnableMenu(GameController.Instance.menuActive);
	}
}
