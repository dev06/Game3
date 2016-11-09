using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Notification : MonoBehaviour {

	public float life;
	private Color _textColor;
	private Animation _animation;
	private float _alpha;

	void OnEnable()
	{
		EventManager.OnSave += OnSave;
	}
	void OnDisable()
	{
		EventManager.OnSave -= OnSave;
	}


	void OnSave()
	{
		_alpha = 1.0f;
		if (_animation != null)
		{
			_animation.Play(_animation.clip.name);
		}
	}


	void Start ()
	{
		_textColor = GetComponent<Text>().color;
		if (GetComponent<Animation>() != null)
		{
			_animation = GetComponent<Animation>();
		}
		_alpha = 0.0f;
	}

	// Update is called once per frame
	void Update ()
	{
		if (_alpha >= 0)
		{
			_alpha -= Time.deltaTime / life;
			_textColor = new Color(_textColor.r, _textColor.g, _textColor.b, _alpha);
			GetComponent<Text>().color = _textColor;
		}

	}
}
