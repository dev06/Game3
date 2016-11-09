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
		bool _active = true;
		string _entityParent = "";
		foreach (XmlNode subElement in element)
		{
			XmlAttributeCollection attrColl = subElement.Attributes;
			foreach (XmlAttribute attribute in attrColl)
			{
				switch (attribute.LocalName)
				{
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

	}


}
