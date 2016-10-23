using UnityEngine;
using System.Collections.Generic;

public class SettingContainer : MonoBehaviour

{
	public FullScreenButton fullScreenButton;

	public List <ButtonEventHandler> settingButtons;


	void OnEnable()
	{
		EventManager.OnSettingActive += OnSettingActive;
	}
	void OnDisaable()
	{
		EventManager.OnSettingActive -= OnSettingActive;
	}
	void Start()
	{
		settingButtons = new List<ButtonEventHandler>();
		fullScreenButton = GameObject.FindWithTag("Settings/FullScreen").transform.FindChild("CheckBackGround").GetComponent<FullScreenButton>();

	}

	void Update()
	{

	}



	void OnSettingActive()
	{
		GameObject.Find("SettingsCanvas").GetComponent<Canvas>().enabled = !GameObject.Find("SettingsCanvas").GetComponent<Canvas>().enabled;
		GameController.Instance.menuActive = MenuActive.SETTING;
	}

}
