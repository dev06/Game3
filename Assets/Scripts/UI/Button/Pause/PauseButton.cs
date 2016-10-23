using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class PauseButton : ButtonEventHandler {

	private Animation _animation;
	private GameObject _container;
	void Start ()
	{
		Init();
		_animation = GetComponent<Animation>();
		_container = transform.parent.gameObject;
	}

	void Update () {

	}

	/// <summary>
	/// Overrides the on pointer enter from base class.
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerEnter(PointerEventData data)
	{

		base.OnPointerEnter(data);
		PlayAnimation(1);



	}
	/// <summary>
	/// Overrides the on pointer exit from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerExit(PointerEventData data)
	{
		base.OnPointerExit(data);

		PlayAnimation(-1);

	}

	/// <summary>
	/// Overrides the on pointer click from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerClick(PointerEventData data)
	{

		base.OnPointerClick(data);
		if (buttonID == ButtonID.RESUME)
		{
			if (EventManager.OnUnpause != null)
			{
				EventManager.OnUnpause();
			}
		}

		if (buttonID == ButtonID.SETTINGS)
		{
			if (EventManager.OnSettingActive != null)
			{
				EventManager.OnSettingActive();
			}
		}

		if (buttonID == ButtonID.QUIT)
		{
			Application.Quit();
		}


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
	public void PlayAnimation(Animation _anim, int direction)
	{
		if (direction > 0)
		{
			_anim[_anim.clip.name].time = 0;
		} else {
			_anim[_anim.clip.name].time = _anim[_anim.clip.name].length;
		}
		_anim[_anim.clip.name].speed = direction;
		_anim.Play(_anim.clip.name, PlayMode.StopAll);
	}


}
