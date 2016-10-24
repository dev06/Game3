using UnityEngine;
using System.Collections;

public class Menu_ButtonContainer : Container {

	private Animation _animaiton;

	public delegate void AnimationFinished();
	public static AnimationFinished OnMenuContainerAnimFinished;

	void OnEnable()
	{
		EventManager.OnNewGame += OnButtonClick;
		EventManager.OnLoadGame += OnButtonClick;
		EventManager.OnSetting += OnButtonClick;
		EventManager.OnCredit += OnButtonClick;
	}

	void OnDisable()
	{
		EventManager.OnNewGame -= OnButtonClick;
		EventManager.OnLoadGame -= OnButtonClick;
		EventManager.OnSetting -= OnButtonClick;
		EventManager.OnCredit -= OnButtonClick;
	}

	void Start ()
	{
		Init();
		_animaiton = GetComponent<Animation>();
	}


	void OnButtonClick()
	{
		PlayAnimation(-1);
	}

	void Update()
	{
		if (GameController.Instance.menuActive == MenuActive.MENU)
		{
			if (GetAnimationState() == 0)
			{
				if (OnMenuContainerAnimFinished != null)
				{
					OnMenuContainerAnimFinished();
				}
				GameController.Instance.menuActive = MenuActive.GAME;
				GameController.Instance.EnableMenu(GameController.Instance.menuActive);
				// Debug.Log("Caleed");
			}
		}

	}

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
