using UnityEngine;
using System.Collections;

public class Menu_PanelController : MonoBehaviour {

	private GameObject _settingPanel;
	private GameObject _creditPanel;


	void OnEnable()
	{
		EventManager.OnNewGame += OnNewGame;
		EventManager.OnLoadGame += OnLoadGame;
		EventManager.OnSetting += OnSetting;
		EventManager.OnCredit += OnCredit;
	}

	void OnDisable()
	{
		EventManager.OnNewGame -= OnNewGame;
		EventManager.OnLoadGame -= OnLoadGame;
		EventManager.OnSetting -= OnSetting;
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

	void OnNewGame()
	{
		GameController.Instance.HasGameStarted = true;
	}
	void OnLoadGame()
	{

	}

	void OnSetting()
	{
		_settingPanel.SetActive(!_settingPanel.activeSelf);
	}

	void OnCredit()
	{
		_creditPanel.SetActive(!_creditPanel.activeSelf);
	}


}
