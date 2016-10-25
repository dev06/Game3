using UnityEngine;
using System.Collections;

public class Menu_CreditPanel : MonoBehaviour {

	private Animation _animation;

	void OnEnable()
	{
		EventManager.OnCreditUnactive += OnCreditUnactive;
		EventManager.OnCreditActive += OnCreditActive;
	}

	void OnDisable()
	{
		EventManager.OnCreditUnactive -= OnCreditUnactive;
		EventManager.OnCreditActive -= OnCreditActive;
	}


	void OnCreditActive()
	{
		PlayAnimation(1);
		Debug.Log("ACTIVE");
	}

	void OnCreditUnactive()
	{
		PlayAnimation(-1);
		Debug.Log("UNACTIVE");
	}

	void Start () {
		_animation = GetComponent<Animation>();
	}

	// Update is called once per frame
	void Update ()
	{

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
