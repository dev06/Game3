using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RegisterPanel : MonoBehaviour {

	private Animation _animation;

	public string name;
	public string username;
	public string password;


	private InputField _passwordContainer;
	private InputField _usernameContainer;
	private InputField _nameContainer;



	void OnEnable()
	{
		EventManager.OnCreateProfileButtonPress += OnCreateProfileButtonPress;
		EventManager.OnRegisterCancelButtonPress += OnRegisterCancelButtonPress;
		EventManager.OnRegisterButtonPress += OnRegisterButtonPress;
	}

	void OnDisable()
	{
		EventManager.OnCreateProfileButtonPress -= OnCreateProfileButtonPress;
		EventManager.OnRegisterCancelButtonPress -= OnRegisterCancelButtonPress;
		EventManager.OnRegisterButtonPress -= OnRegisterButtonPress;
	}


	// Use this for initialization
	void Start ()
	{
		_nameContainer = transform.FindChild("Name").FindChild("InputField").GetComponent<InputField>();
		_passwordContainer = transform.FindChild("Password").FindChild("InputField").GetComponent<InputField>();
		_usernameContainer = transform.FindChild("Username").FindChild("InputField").GetComponent<InputField>();
		_animation = GetComponent<Animation>();
	}

	// Update is called once per frame
	void Update () {

	}

	private void  OnRegisterButtonPress()
	{
		PlayAnimation(1);
	}


	private void OnCreateProfileButtonPress()
	{
		if (_nameContainer.text.Length > 0 && _usernameContainer.text.Length > 0 && _passwordContainer.text.Length > 0)
		{
			name = _nameContainer.text;
			username = _usernameContainer.text;
			password = _passwordContainer.text;
			GameController.Instance.users.Add(new User(name, username, password));

			_nameContainer.text = "";
			_usernameContainer.text = "";
			_passwordContainer.text = "";

			PlayAnimation(-1);
		}
	}

	private void OnRegisterCancelButtonPress()
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
		_animation.Play(_animation.clip.name);
	}
}
