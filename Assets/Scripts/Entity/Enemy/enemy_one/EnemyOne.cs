﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyOne : Mob {

	private GameObject _hover;
	public GameObject Target;

	void Start ()
	{
		Init();
		MaxHealth = Constants.PatrolEnemyMaxHealth;
		Health = MaxHealth;
		_hover = transform.FindChild("HoverEffect").gameObject;
		_speed = Constants.PatrolEnemySpeed;
		_agent.speed = _speed;
		_fillImage = transform.FindChild("HealthBar").gameObject.transform.FindChild("FillImage").GetComponent<Image>();
		_stillImage = transform.FindChild("HealthBar").gameObject.transform.FindChild("StillImage").GetComponent<Image>();
		_HealthText = transform.FindChild("HealthBar").gameObject.transform.FindChild("Text").GetComponent<Text>();
	}


	void Update ()
	{
		if (_gameController.menuActive == MenuActive.GAME)
		{
			CheckIfIsDead();
			ManageHoverEffect();
			Move();
			UpdateHealthQuad();
		}

	}

	private void Move()
	{

		if (Health > 0)
		{
			if (Vector3.Distance(transform.position, _gameController.Player.transform.position) < 10)
			{
				if (Vector3.Distance(transform.position, _gameController.Player.transform.position) < 6)
				{
					_gameController.Player.gameObject.SendMessage("DoDamage", Time.deltaTime * Constants.PatrolEnemyDamage);
					behaviour = EntityBehaviour.Attack;
				} else
				{
					_agent.SetDestination(_gameController.Player.transform.position);
					RotateTowards(_gameController.Player.transform);
					behaviour = EntityBehaviour.Chase;
				}
			} else {
				if (_gameController.navMeshController.navMesh_wayPoints.Count > 0)
				{
					if (_agent.remainingDistance < 10)
					{
						_agent.SetDestination(_gameController.navMeshController.navMesh_wayPoints[_gameController.navMeshController.GetNextWayPoint()].transform.position);
						behaviour = EntityBehaviour.Patrol;
					}
				}
			}
		}
	}

	private void ManageHoverEffect()
	{
		_hover.transform.Rotate(new Vector3(0, 0,  Time.deltaTime * 150.0f));
	}
}
