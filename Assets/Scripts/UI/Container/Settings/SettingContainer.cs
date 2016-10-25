using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SettingContainer : MonoBehaviour

{
	public FullScreenButton fullScreenButton;
	public List <ButtonEventHandler> settingButtons;

	private Animation _animation;
	private bool _animationState;

	private MenuActive _previousMenuActive;

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
		_animation[_animation.clip.name].speed = 0;

	}

	void Update()
	{
		// if (!GameController.Instance.HasGameStarted)
		// {
		// 	if (GetAnimationState() == 0)
		// 	{
		// 		GameController.Instance.menuActive = MenuActive.MENU;
		// 		GameController.Instance.EnableMenu(GameController.Instance.menuActive);
		// 	}
		// } else
		// {



		if (_previousMenuActive != MenuActive.NONE)
		{
			if (GetAnimationState() == 0)
			{
				GameController.Instance.menuActive = _previousMenuActive;
				GameController.Instance.EnableMenu(GameController.Instance.menuActive);
				_previousMenuActive = MenuActive.NONE;
			}
		}
	}



	void OnSettingActive()
	{
		GameObject.Find("SettingsCanvas").GetComponent<Canvas>().enabled = true;
		_previousMenuActive = GameController.Instance.menuActive;

		GameController.Instance.menuActive = MenuActive.SETTING;
		PlayAnimation(1);
	}

	void OnSettingUnactive()
	{
		PlayAnimation(-1);
	}

	/// <summary>
	/// Return an int between 0 and 1 representing the state of the animation.
	///[0] when anim is at start [1] when anim is at end and [-1] if speed is any other #
	/// </summary>

	private int GetAnimationState()
	{
		if (_animation[_animation.clip.name].speed == -1)
		{
			if (_animation.isPlaying == false)
			{
				return 0;

			}
		} else if (_animation[_animation.clip.name].speed == 1)
		{
			if (_animation.isPlaying == false)
			{
				return 1;
			}
		}

		return -1;

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
