using UnityEngine;
using System.Collections;

public class PurpleProjectile : Projectile {


	void Start ()
	{
		Init();
		GetComponent<Rigidbody>().velocity = forward * 50;
		_damage = Constants.Character_PurpleProjectileDamage;
	}

	void Update()
	{

	}

	void FixedUpdate()
	{
		TransverseBullet();
	}

	public override void TransverseBullet()
	{
		base.TransverseBullet();
		if (GameController.Instance.menuActive == MenuActive.PAUSE)
		{
			GetComponent<Rigidbody>().velocity = forward * 0;
		} else {
			GetComponent<Rigidbody>().velocity = forward * 50;
		}
	}


	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.GetComponent<Mob>() != null)
		{

			if (col.gameObject.GetComponent<Mob>().body != owner)
			{
				col.gameObject.SendMessage("DoDamage", _damage);
				Destroy(gameObject);
			}

		} else {
			GameObject effect_clone = Instantiate(_effect, transform.position, Quaternion.identity) as GameObject;
			effect_clone.transform.parent = _gameController.activeEntities.transform;

		}
	}
}
