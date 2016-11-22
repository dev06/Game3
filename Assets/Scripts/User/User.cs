using UnityEngine;
using System.Collections;

public class User
{
	public string name;
	public string username;
	public string password;

	public User()
	{
		name = "";
		username = "";
		password = "";
	}

	public User(string _name, string _userName, string _password)
	{
		this.name = _name;
		this.username = _userName;
		this.password = _password;
	}

	public void SetName(string name)
	{
		this.name = name;
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
		return "Name " + name + " Username " + username + " Password " + password;
	}
}
