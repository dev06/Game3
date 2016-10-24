using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SettingContainer : MonoBehaviour

{
	public FullScreenButton fullScreenButton;


	public List <ButtonEventHandler> settingButtons;


	private Animation _animation;


	private bool _animationState;
	void OnEnable()
	{
		EventManager.OnSettingActive += OnSettingActive;
		EventManager.OnSettingUnactive += OnSettingUnactive;
	}

	void OnDisaable()
	{
		EventManager.OnSettingActive -= OnSettingActive;
		EventManager.OnSettingUnactive -= OnSettingUnactive;
	}
	void Start()
	{
		settingButtons = new List<ButtonEventHandler>();
		fullScreenButton = GameObject.FindWithTag("Settings/FullScreen").transform.FindChild("CheckBackGround").GetComponent<FullScreenButton>();
		_animation = GetComponent<Animation>();

	}

	void Update()
	{
		if (GameController.Instance.HasGameStarted)
		{
			if (_animation != null)
			{
				// if (_animation[_animation.clip.name].speed == -1)
				// {
				// 	if (_animation.isPlaying == false)
				// 	{
				// 		GameController.Instance.menuActive = MenuActive.PAUSE;
				// 		GameController.Instance.EnableMenu(GameController.Instance.menuActive);
				// 		_animation[_animation.clip.name].speed = 0;
				// 	}
				// }
			}
		}

		if (_animation.isPlaying == false)
		{
			_animation[_animation.clip.name].speed = 0;
		}


		// if (_animation[_animation.clip.name].time ==  _animation[_animation.clip.name].length)
		// {
		// 	if (GameController.Instance.HasGameStarted == false)
		// 	{
		// 		GameController.Instance.menuActive = MenuActive.MENU;
		// 	} else {
		// 		GameController.Instance.menuActive = MenuActive.PAUSE;

		// 	}
		// 	GameController.Instance.EnableMenu(GameController.Instance.menuActive);
		// }

	}



	void OnSettingActive()
	{
		GameObject.Find("SettingsCanvas").GetComponent<Canvas>().enabled = !GameObject.Find("SettingsCanvas").GetComponent<Canvas>().enabled;
		GameController.Instance.menuActive = MenuActive.SETTING;
		PlayAnimation(1);
	}

	void OnSettingUnactive()
	{
		PlayAnimation(-1);
	}

	public void PlayAnimation(int direction)
	{
		if (direction > 0)
		{
			_animation[_animation.clip.name].time = 0;
		} else {
			_animation[_animation.clip.name].time = _animation[_animation.clip.name].length;
		}
		_animation[_animation.clip.name].speed = direction;
		_animation.Play(_animation.clip.name, PlayMode.StopAll);
	}

}
