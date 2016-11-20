using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RegisterPanel : MonoBehaviour {

	public string username;
	public string password;


	private InputField _passwordContainer;
	private InputField _usernameContainer;


	void OnEnable()
	{
		EventManager.OnCreateProfileButtonPress += OnCreateProfileButtonPress;
	}

	void OnDisable()
	{
		EventManager.OnCreateProfileButtonPress -= OnCreateProfileButtonPress;
	}


	// Use this for initialization
	void Start ()
	{
		_passwordContainer = transform.FindChild("Password").FindChild("InputField").GetComponent<InputField>();
		_usernameContainer = transform.FindChild("Username").FindChild("InputField").GetComponent<InputField>();
	}

	// Update is called once per frame
	void Update () {

	}


	private void OnCreateProfileButtonPress()
	{
		if (_usernameContainer.text.Length > 0 && _passwordContainer.text.Length > 0)
		{
			username = _usernameContainer.text;
			password = _passwordContainer.text;
			GameController.Instance.users.Add(new User(username, password));

			gameObject.SetActive(false);
		}
	}
}
