using UnityEngine;
using System.Collections;

public class Menu_PanelController : MonoBehaviour {

	private GameObject _settingPanel;
	private GameObject _creditPanel;


	void OnEnable()
	{

		Menu_ButtonContainer.OnMenuContainerAnimFinished += OnButtonClick;
		EventManager.OnCredit += OnCredit;
	}

	void OnDisable()
	{
		Menu_ButtonContainer.OnMenuContainerAnimFinished -= OnButtonClick;
		EventManager.OnCredit -= OnCredit;
	}

	// this is also a test line for commit
	void Start ()
	{
		_creditPanel = transform.GetChild(0).gameObject;
		_settingPanel = transform.GetChild(1).gameObject;
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
			case ButtonID.NEWGAME:
			{
				GameController.Instance.HasGameStarted = true;
				GameController.Instance.menuActive = MenuActive.GAME;
				GameController.Instance.EnableMenu(GameController.Instance.menuActive);
				break;
			}
		}
	}

	private void OnCredit(ButtonID id)
	{
		_creditPanel.SetActive(!_creditPanel.activeSelf);
	}


}
