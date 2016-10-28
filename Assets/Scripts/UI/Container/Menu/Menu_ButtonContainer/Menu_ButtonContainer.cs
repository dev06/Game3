using UnityEngine;
using System.Collections;

public class Menu_ButtonContainer : Container {

	private Animation _animaiton;
	private ButtonID _buttonClickedId;

	public delegate void AnimationFinished(ButtonID id);
	public static AnimationFinished OnMenuContainerAnimFinished;



	void OnEnable()
	{
		EventManager.OnNewGame += OnButtonClick;
		EventManager.OnLoadGame += OnButtonClick;
		EventManager.OnCredit += OnButtonClick;
		EventManager.OnSettingUnactive += OnSettingUnactive;
		EventManager.OnSettingActive += OnSettingActive;
		EventManager.OnCreditUnactive += OnCreditUnacitve;
		EventManager.OnCreditActive += OnCreditActive;

	}

	void OnDisable()
	{
		EventManager.OnNewGame -= OnButtonClick;
		EventManager.OnLoadGame -= OnButtonClick;
		EventManager.OnCredit -= OnButtonClick;
		EventManager.OnSettingUnactive -= OnSettingUnactive;
		EventManager.OnSettingActive -= OnSettingActive;
		EventManager.OnCreditUnactive -= OnCreditUnacitve;
		EventManager.OnCreditActive -= OnCreditActive;



	}

	void Start ()
	{
		Init();
		_animaiton = GetComponent<Animation>();
	}

	/// <summary>
	/// Called instantaneously when button is pressed
	/// </summary>
	private void OnButtonClick(ButtonID id)
	{
		PlayAnimation(-1);
		_buttonClickedId = id;
	}

	/// <summary>
	/// Called when Setting becomes unactive
	/// </summary>
	private void OnSettingUnactive()
	{
		if (GameController.Instance.menuActive != MenuActive.GAME)
		{
			PlayAnimation(1);
		}
	}

	/// <summary>
	/// Called when setting becomes active
	/// </summary>
	private void OnSettingActive()
	{
		if (GameController.Instance.menuActive != MenuActive.GAME)
		{
			PlayAnimation(-1);
		}
	}

	/// <summary>
	/// Called when Credit becomes unactive
	/// </summary>
	private void OnCreditUnacitve()
	{
		PlayAnimation(1);
	}

	private void OnCreditActive()
	{
		PlayAnimation(-1);
	}

	void Update()
	{
		OnFinishMenuAnim();
	}

	/// <summary>
	/// Methods check whether the menu animation has finished coming from different containers
	/// for ex. menu scene: coming back from settings to menu.
	/// </summary>

	private void OnFinishMenuAnim()
	{
		if (GameController.Instance.menuActive == MenuActive.MENU)
		{
			if (GetAnimationState() == 0)
			{
				if (OnMenuContainerAnimFinished != null)
				{
					OnMenuContainerAnimFinished(_buttonClickedId);
				}

				_buttonClickedId = ButtonID.NONE;
			}
		}
	}

	/// <summary>
	/// Return a number between -1, 1 to see the state of the animation.
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
}
