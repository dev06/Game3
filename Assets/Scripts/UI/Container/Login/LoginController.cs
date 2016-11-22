using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class LoginController : MonoBehaviour {

	private GameObject _registerContainer;

	private GameObject _credentialsContainer;
	private InputField _usernameField;
	private InputField _passwordField;

	private Animation _wrong_credentials;
	void OnEnable()
	{
		EventManager.OnLoginButtonPress += OnLoginButtonPress;
		EventManager.OnRegisterButtonPress += OnRegisterButtonPress;
		EventManager.OnCreateProfileButtonPress += OnCreateProfileButtonPress;
	}
	void OnDisable()
	{
		EventManager.OnLoginButtonPress -= OnLoginButtonPress;
		EventManager.OnRegisterButtonPress -= OnRegisterButtonPress;
		EventManager.OnCreateProfileButtonPress -= OnCreateProfileButtonPress;
	}

	void Start ()
	{
		_registerContainer = GameObject.FindWithTag("Container/RegisterContainer");
		_usernameField = GameObject.FindWithTag("Login/Username").transform.FindChild("InputField").GetComponent<InputField>();
		_passwordField = GameObject.FindWithTag("Login/Password").transform.FindChild("InputField").GetComponent<InputField>();
		_credentialsContainer = GameObject.FindWithTag("Container/LoginContainer").transform.FindChild("Credentials").gameObject;
		_wrong_credentials = _credentialsContainer.GetComponent<Animation>();
	}

	private void OnLoginButtonPress()
	{
		//login into profile
		if (UserExists(_usernameField.text, _passwordField.text))
		{
			SuccessfulLogin();
		} else {
			_wrong_credentials.Play("login_wrong_credentials");
			Debug.Log("Wrong credentials");
		}

	}

	private void OnRegisterButtonPress()
	{
		_registerContainer.transform.GetChild(0).gameObject.SetActive(true);
	}

	private void OnCreateProfileButtonPress()
	{
		//_registerContainer.transform.GetChild(0).gameObject.SetActive(false);
	}

	private bool UserExists(string username, string password)
	{
		int databaseCount = GameController.Instance.users.Count;
		for (int i = 0; i < databaseCount; i++)
		{
			User user = GameController.Instance.users[i];
			if (user.username == username &&  user.password == password)
			{
				GameController.Instance.loggedUser = user;
				return true;
			}
		}

		return false;
	}

	private void SuccessfulLogin()
	{
		GameController.Instance.menuActive = MenuActive.MENU;
		GameController.Instance.EnableMenu(GameController.Instance.menuActive);
		if (EventManager.OnLoginSuccess != null)
		{
			EventManager.OnLoginSuccess();
		}
		Debug.Log("Welcome");
	}


}
