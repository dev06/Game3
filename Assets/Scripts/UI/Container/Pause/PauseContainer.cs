using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class PauseContainer : Container {


	void OnEnable()
	{
		EventManager.OnPause += OnPause;
		EventManager.OnUnpause += OnUnpause;
		EventManager.OnSettingUnactive += OnSettingUnactive;
		EventManager.OnSettingActive += OnSettingActive;
	}

	void OnDisable()
	{
		EventManager.OnPause -= OnPause;
		EventManager.OnUnpause -= OnUnpause;
		EventManager.OnSettingActive -= OnSettingActive;
		EventManager.OnSettingUnactive -= OnSettingUnactive;
	}

	void Update()
	{
		PauseGame();
	}

	void PauseGame()
	{
		if (GameController.Instance.menuActive == MenuActive.GAME)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				GameController.Instance.menuActive = (GameController.Instance.menuActive != MenuActive.PAUSE) ? MenuActive.PAUSE : MenuActive.GAME;
				if (GameController.Instance.menuActive == MenuActive.PAUSE)
				{
					if (EventManager.OnPause != null)
					{
						EventManager.OnPause();
					}
					GameController.Instance.EnableMenu(GameController.Instance.menuActive);
				}

				if (GameController.Instance.menuActive == MenuActive.GAME)
				{
					if (EventManager.OnPause != null)
					{
						EventManager.OnUnpause();
					}
				}
			}
		}
	}

	void OnPause()
	{
		PlayAnimation(_animation, 1);
	}

	void OnUnpause()
	{
		PlayAnimation(_animation, -1);
		StartCoroutine("DiablePauseMenu");
	}

	void OnSettingUnactive()
	{
		if (GameController.Instance.HasGameStarted)
		{
			PlayAnimation(1);
		}
	}

	void OnSettingActive()
	{
		if (GameController.Instance.HasGameStarted)
		{
			PlayAnimation(-1);
		}
	}

	void Start () {
		Init();
	}


	public override void OnPointerEnter(PointerEventData data)
	{
		_gameController.onContainer = true;
	}

	public override void OnPointerExit(PointerEventData data)
	{
		_gameController.onContainer = false;
	}

	private IEnumerator DiablePauseMenu()
	{
		yield return new WaitForSeconds(.2f);
		GameController.Instance.menuActive = MenuActive.GAME;
		GameController.Instance.EnableMenu(	GameController.Instance.menuActive);
	}

}
