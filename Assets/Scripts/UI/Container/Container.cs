using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Container : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


	protected GameController _gameController;
	protected Animation _animation;

	void OnEnable()
	{

	}

	void Start ()
	{
		Init();
	}

	protected void Init()
	{
		_gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		_animation = GetComponent<Animation>();
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
		_animation.Play(_animation.clip.name);
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



	public virtual void OnPointerEnter(PointerEventData data)
	{
		_gameController.onContainer = true;
	}

	public virtual void OnPointerExit(PointerEventData data)
	{
		_gameController.onContainer = false;
	}


	void OnDisable()
	{

	}
}
