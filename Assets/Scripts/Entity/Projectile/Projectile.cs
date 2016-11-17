//Devan Patel
//Applications and Scripting
//Sep.12.2016using UnityEngine;
using UnityEngine;
using System.Collections;

public class Projectile : MasterEntity {

	[HideInInspector]
	public Body owner;
	[HideInInspector]
	public Vector3 forward;
	public Transform target;
	#region----PRIVATE MEMBERS-----
	protected GameController _gameController;
	protected float _maxLife;
	protected float _size;
	protected Color _color;
	protected float _velocity;
	protected ParticleSystem _trail;
	protected GameObject _effect;
	protected float _damage;
	protected float _lifeTimer;
	#endregion----PRIVATE MEMBERS-----



	void Start ()
	{
		Init();
	}

	/// <summary>
	/// Init all the components
	/// </summary>
	public void Init()
	{
		_effect = (GameObject)Resources.Load("Prefabs/Particles/Effect");
		_gameController = FindObjectOfType(typeof(GameController)) as GameController;
		_maxLife = 3;
		entityType = EntityType.PROJECTILE;
		if (transform.childCount > 0)
		{
			transform.GetChild(0).transform.forward = forward;
		}
	}


	public virtual void TransverseBullet()
	{
		if (GameController.Instance.menuActive != MenuActive.PAUSE)
		{
			float speed = Random.Range(40.0f, 50.0f);
			transform.Rotate(new Vector3(Time.deltaTime * Time.time * speed,  Time.deltaTime * Time.time * speed, Time.deltaTime * Time.time * speed));
		}

		DisposeBullet();
	}

	public void DisposeBullet()
	{
		if (GameController.Instance.menuActive != MenuActive.PAUSE)
		{
			_lifeTimer += Time.deltaTime;
			if (_lifeTimer > _maxLife)
			{
				Destroy(gameObject);
				_lifeTimer = 0;
			}
		}
	}


}
