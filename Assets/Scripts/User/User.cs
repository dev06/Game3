using UnityEngine;
using System.Collections;

public class User
{

	public string username;
	public string password;

	public User()
	{
		username = "";
		password = "";
	}

	public User(string _userName, string _password)
	{
		this.username = _userName;
		this.password = _password;
	}

	public void SetUserName(string username)
	{
		this.username = username;
	}

	public void SetPassword(string password)
	{
		this.password = password;
	}

	public override string ToString()
	{
		return "Username " + username + " Password " + password;
	}
}
