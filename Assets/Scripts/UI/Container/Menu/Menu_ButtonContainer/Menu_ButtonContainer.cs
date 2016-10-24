using UnityEngine;
using System.Collections;

public class Menu_ButtonContainer : Container {

	private Animation _animaiton;

	void OnEnable()
	{
		EventManager.OnNewGame += OnButtonClick;
		EventManager.OnLoadGame += OnButtonClick;
		EventManager.OnSetting += OnButtonClick;
		EventManager.OnCredit += OnButtonClick;
	}

	void OnDisable()
	{
		EventManager.OnNewGame -= OnButtonClick;
		EventManager.OnLoadGame -= OnButtonClick;
		EventManager.OnSetting -= OnButtonClick;
		EventManager.OnCredit -= OnButtonClick;
	}

	void Start ()
	{
		Init();
		_animaiton = GetComponent<Animation>();
	}


	void OnButtonClick()
	{
		PlayAnimation(-1);
	}
}
