using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyTwo : Mob {

	public GameObject Target;


	private GameObject _hover;
	private float _shootTimer;
	private bool _shot;
	private GameObject _bulletLeft;
	private GameObject _bulletRight;


	void Start ()
	{
		Init();
		MaxHealth = Constants.GuardEnemyMaxHealth;
		_hover = transform.FindChild("HoverEffect").gameObject;
		_bulletRight = transform.FindChild("BulletRight").gameObject;
		_bulletLeft = transform.FindChild("BulletLeft").gameObject;
		_shot = true;
		_speed = Constants.GuardEnemySpeed;
		_agent.speed = _speed;
		_fillImage = transform.FindChild("HealthBar").gameObject.transform.FindChild("FillImage").GetComponent<Image>();
		_stillImage = transform.FindChild("HealthBar").gameObject.transform.FindChild("StillImage").GetComponent<Image>();
		_HealthText = transform.FindChild("HealthBar").gameObject.transform.FindChild("Text").GetComponent<Text>();
		if (Target == null)
		{
			Target = GameObject.Find("Droid");
		}
	}

	void Update ()
	{
		if (_gameController.menuActive == MenuActive.GAME)
		{
			CheckIfIsDead();
			ManageHoverEffect();
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

		if (Health > 0)
		{
			ManageInitPoints();
			if (Vector3.Distance(transform.position, Target.transform.position) < 35)
			{
				if (Vector3.Distance(transform.position, Target.transform.position) < 15)
				{
					if (CanShoot())
					{
						_gameController.projectileManager.Shoot(Constants.Enemy_Two_Bullet, _bulletRight.transform.position, _bulletRight.transform.forward, body);
						_gameController.projectileManager.Shoot(Constants.Enemy_Two_Bullet, _bulletLeft.transform.position, _bulletLeft.transform.forward, body);
						_shot = true;
					}
					behaviour = EntityBehaviour.Shoot;
					Target.gameObject.SendMessage("DoDamage", Time.deltaTime * Constants.PatrolEnemyDamage);
				} else
				{
					behaviour = EntityBehaviour.Chase;
				}
				_agent.SetDestination(Target.transform.position);
				RotateTowards(Target.transform);

			} else {
				behaviour = EntityBehaviour.Idle;
			}

		}
	}

	private void ManageInitPoints()
	{
		_bulletRight.transform.forward = transform.forward;
		_bulletLeft.transform.forward =  transform.forward;

	}

	private bool CanShoot()
	{
		if (_shot)
		{
			_shootTimer += Time.deltaTime;
		}

		if (_shootTimer > Constants.GuardEnemyShootDelay)
		{
			_shootTimer = 0;
			_shot = false;
			return true;
		}

		return false;
	}



	private void ManageHoverEffect()
	{
		_hover.transform.Rotate(new Vector3(0, 0,  Time.deltaTime * 150.0f));
	}
}
