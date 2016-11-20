using UnityEngine;
using System.Collections;
/// <summary>
///  Attached to the Credit Container
/// Handles all aspect for the credit container
/// </summary>
public class CreditContainer : MonoBehaviour {

	private Animation _animation;

	void OnEnable()
	{
		EventManager.OnCreditActive += OnCreditActive;
		EventManager.OnCreditUnactive += OnCreditUnactive;
	}

	void Start ()
	{
		_animation = GetComponent<Animation>();
		transform.FindChild("BackButton").GetComponent<BackButton>().SetOwner(MenuActive.CREDIT);
	}


	void Update ()
	{
		if (GameController.Instance.menuActive == MenuActive.CREDIT)
		{
			if (GetAnimationState() == 0)
			{
				GameController.Instance.menuActive = MenuActive.MENU;
				GameController.Instance.EnableMenu(GameController.Instance.menuActive);
			}
		}
	}


	/// <summary>
	/// Called when credit becomes active;
	/// </summary>
	private void OnCreditActive()
	{
		GameController.Instance.menuActive = MenuActive.CREDIT;
		GameObject.FindWithTag("UI/CreditCanvas").GetComponent<Canvas>().enabled = true;
		PlayAnimation(1);
	}

	/// <summary>
	/// Called when back button in credit canvas was pressed then plays exit animation
	/// </summary>
	private void OnCreditUnactive()
	{
		PlayAnimation(-1);
	}

	/// <summary>
	/// Plays animation in given direction
	/// </summary>
	/// <param name="direction"></param>
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

	void OnDisable()
	{
		EventManager.OnCreditActive -= OnCreditActive;
		EventManager.OnCreditUnactive -= OnCreditUnactive;
	}



}
