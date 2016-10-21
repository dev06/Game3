﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProjectilePenetration : Buff {


	void Start () {
		Init();

	}

	public ProjectilePenetration()
	{
		_duration = 15.0f;
	}



	public override void Tick()
	{
		if (_active)
		{
			_currentBuffTime += Time.deltaTime;
			_buffIndicator.targetValue = _duration - _currentBuffTime;
			_buffIndicator.targetMaxValue = _duration;
		}
		if (_currentBuffTime > _duration)
		{
			_active = false;
			_currentBuffTime = 0;
			_buffIndicator.alive = _active;
		}

		if (_active)
		{
			Constants.Character_BlueProjectileDamage = Constants.Character_BlueProjectileDamage_Default + (Constants.Character_BlueProjectileDamage_Default * Constants.ProjectilePenetration_Percent / 100.0f);
			Constants.Character_YellowProjectileDamage = Constants.Character_YellowProjectileDamage_Default + (Constants.Character_YellowProjectileDamage_Default * Constants.ProjectilePenetration_Percent / 100.0f);;
			Constants.Character_PurpleProjectileDamage = Constants.Character_PurpleProjectileDamage_Default + (Constants.Character_PurpleProjectileDamage_Default * Constants.ProjectilePenetration_Percent / 100.0f);;
		} else
		{
			Constants.Character_BlueProjectileDamage = Constants.Character_BlueProjectileDamage_Default;
			Constants.Character_YellowProjectileDamage = Constants.Character_YellowProjectileDamage_Default;
			Constants.Character_PurpleProjectileDamage = Constants.Character_PurpleProjectileDamage_Default;
		}
	}

	public override void UseBuff(GameController _gameController)
	{
		_active = true;
		_buffIcon = Instantiate((GameObject)Resources.Load("Prefabs/UIPrefabs/BuffContainer/BuffIcon"));
		_buffIcon.transform.GetComponent<Image>().sprite =  Resources.Load<Sprite>("Item/projectile_penetration_buff");
		_buffIndicator = _buffIcon.GetComponent<BuffIndicator>();
		GameObject _container = GameObject.FindWithTag("Container/BuffContainer");
		_buffIcon.transform.SetParent(_container.transform);
		_container.GetComponent<BuffContainer>().currentBuffs.Add(_buffIcon);

	}

}
