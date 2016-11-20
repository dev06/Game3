using UnityEngine;
using System.Collections;
using System.Xml;
public class SpawnManager : MonoBehaviour
{

	public void LoadGameEntites(XmlNode node)
	{

		switch (node.Name)
		{
			case "BlueBall_Pk":
				{
					SpawnEntities(Constants.BlueBall_Pk, node);
					break;
				}
			case "YellowBall_Pk":
				{
					SpawnEntities(Constants.YellowBall_Pk, node);
					break;
				}
			case "PurpleBall_Pk":
				{
					SpawnEntities(Constants.PurpleBall_Pk, node);
					break;
				}
			case "BasicHealth_Pk":
				{
					SpawnEntities(Constants.BasicHealth_Pk, node);
					break;
				}
			case "SuperHealth_Pk":
				{
					SpawnEntities(Constants.SuperHealth_Pk, node);
					break;
				}
			case "IntermediateHealth_Pk":
				{
					SpawnEntities(Constants.IntermediateHealth_Pk, node);
					break;
				}
			case "AdvancedHealth_Pk":
				{
					SpawnEntities(Constants.AdvancedHealth_Pk, node);
					break;
				}
			case "Droid":
				{
					SpawnEntities(Constants.Droid, node);
					break;
				}
			case "Enemy_One":
				{
					SpawnEntities(Constants.Enemy_One, node);
					break;
				}
			case "Enemy_Two":
				{
					SpawnEntities(Constants.Enemy_Two, node);
					break;
				}
			case "YellowBullet":
				{
					SpawnEntities(Constants.Yellow_Bullet, node);
					break;
				}
			case "PurpleBullet":
				{
					SpawnEntities(Constants.Purple_Bullet, node);
					break;
				}
			case "BlueBullet":
				{
					SpawnEntities(Constants.Blue_Bullet, node);
					break;
				}
			case "player":
				{
					SpawnEntities(Constants.Player, node);

					break;
				}
		}
	}

	public void SpawnEntities(GameObject _prefab, XmlNode element)
	{
		GameObject _entity = null;
		Vector3 _position = -Vector3.up * 100;
		Vector3 _rotation = Vector3.zero;
		Vector3 _forward = Vector3.zero;
		EntityType _type = EntityType.NONE;
		bool _active = true;
		string _entityParent = "";
		float _mobHealth = 0;


		foreach (XmlNode subElement in element)
		{
			XmlAttributeCollection attrColl = subElement.Attributes;
			foreach (XmlAttribute attribute in attrColl)
			{
				switch (attribute.LocalName)
				{
					case "type":
						{
							_type =  (EntityType)System.Enum.Parse(typeof(EntityType), attribute.Value);
							break;
						}
					case "position":
						{
							string[] components = attribute.Value.Split(',');

							_position = new Vector3(float.Parse(components[0]), float.Parse(components[1]), float.Parse(components[2]));
							break;
						}
					case "rotation":
						{
							string[] components = attribute.Value.Split(',');
							_rotation =  new Vector3(float.Parse(components[0]), float.Parse(components[1]), float.Parse(components[2]));
							break;
						}
					case "active":
						{
							_active = bool.Parse(attribute.Value);
							break;
						}
					case "parent":
						{
							_entityParent = attribute.Value;
							break;
						}
					case "health":
						{
							_mobHealth = float.Parse(attribute.Value);
							break;
						}
					case "forward":
						{
							string[] components = attribute.Value.Split(',');
							_forward = new Vector3(float.Parse(components[0]), float.Parse(components[1]), float.Parse(components[2]));
							break;
						}
				}
			}
		}

		if (element.Name != "player")
		{
			_entity = (GameObject)Instantiate(_prefab, _position, Quaternion.Euler(_rotation));

		} else {
			_entity = GameController.Instance.Player;
		}

		_entity.gameObject.name = _prefab.name;
		if (_entityParent != "")
		{
			_entity.transform.parent = GameObject.FindWithTag(_entityParent).transform;
		}

		_entity.transform.position = _position;
		_entity.transform.rotation = Quaternion.Euler(_rotation);
		_entity.SetActive(_active);




		if (_type == EntityType.MOB)
		{
			_entity.GetComponent<Mob>().GetHealth = _mobHealth;
		}


		if (_type == EntityType.PROJECTILE)
		{
			_entity.GetComponent<Projectile>().forward = _forward;
			_entity.GetComponent<Rigidbody>().velocity = _forward * 50;
		}






	}


}
