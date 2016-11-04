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
		}
	}

	public void SpawnEntities(GameObject _prefab, XmlNode element)
	{
		GameObject _entity = null;
		Vector3 _position = Vector3.right * 10;
		Quaternion _rotation = Quaternion.identity;

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
							_rotation =  Quaternion.Euler(new Vector3(float.Parse(components[0]), float.Parse(components[1]), float.Parse(components[2])));
							break;
						}
					case "active":
						{
							//_entity.SetActive(bool.Parse(attribute.Value));
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
		_entity = (GameObject)Instantiate(_prefab, _position, _rotation);
		_entity.gameObject.name = _prefab.name;
		_entity.transform.parent = GameObject.FindWithTag(_entityParent).transform;
		_entity.transform.position = _position;
	}
}
