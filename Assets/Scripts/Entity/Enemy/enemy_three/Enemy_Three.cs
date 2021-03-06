﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Enemy_Three : Mob {

	public GameObject Target;

	private Animator _animator;
	void Start () {
		Init();
		MaxHealth = Constants.PatrolEnemyMaxHealth;
		_speed = Constants.PatrolEnemySpeed;
		_agent.speed = _speed;
		_fillImage = transform.FindChild("HealthBar").gameObject.transform.FindChild("FillImage").GetComponent<Image>();
		_stillImage = transform.FindChild("HealthBar").gameObject.transform.FindChild("StillImage").GetComponent<Image>();
		_HealthText = transform.FindChild("HealthBar").gameObject.transform.FindChild("Text").GetComponent<Text>();

		if (Target == null)
		{
			Target = GameObject.Find("Droid");
		}

		_animator = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update () {
		if (_gameController.menuActive == MenuActive.GAME)
		{

			CheckIfIsDead();
			if (Target != null)
			{
				Move();

			}

			UpdateHealthQuad();
			if (Target == null)
			{
				if (GameController.Instance.Player != null)
				{
					Target = GameController.Instance.Player;
				}
			}

		}
	}

	private void Move()
	{

		if (Vector3.Distance(transform.position, Target.transform.position) < 20)
		{
			if (Vector3.Distance(transform.position, Target.transform.position) < 10)
			{
				Target.gameObject.SendMessage("DoDamage", Time.deltaTime * Constants.PatrolEnemyDamage);
				behaviour = EntityBehaviour.Attack;
				_animator.SetBool("attack", true);
				_animator.SetInteger("Walk", -1);
			} else
			{
				_agent.SetDestination(Target.transform.position);
				_animator.SetInteger("Walk", 1);
				_animator.SetBool("attack", false);
				RotateTowards(Target.transform);
				behaviour = EntityBehaviour.Chase;
			}
		} else {
			_animator.SetBool("attack", false);
			_animator.SetInteger("Walk", 1);
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
