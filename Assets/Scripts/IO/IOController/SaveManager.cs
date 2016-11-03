using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SaveManager : MonoBehaviour {


	public List<KeyValuePair<string, float>> settingKVP = new List<KeyValuePair<string, float>>();
	public List<EntitySaveData> entityTransform = new List<EntitySaveData>();

	void Start()
	{
		GameController.Instance.saveManager = this;

	}



	public void UpdateData()
	{
		UpdateSettingValues();
		UpdateEntityTransform();
	}

	/// <summary>
	/// Update the settings values to key value pair
	/// </summary>
	private void UpdateSettingValues()
	{
		settingKVP.Clear();
		settingKVP.Add(new KeyValuePair<string, float>("ToggleShadow", (Constants.ToggleShadow) ? 1 : 0));
		settingKVP.Add(new KeyValuePair<string, float>("ShadowQuality", Constants.ShadowQuality));
		settingKVP.Add(new KeyValuePair<string, float>("AntiAliasingQuality", Constants.AntiAliasingQuality));
		settingKVP.Add(new KeyValuePair<string, float>("FullScreen", (Constants.FullScreen) ? 1 : 0));
		settingKVP.Add(new KeyValuePair<string, float>("VSync", (Constants.VSync) ? 1 : 0));
	}

	private void UpdateEntityTransform()
	{
		entityTransform.Clear();
		entityTransform.Add(new EntitySaveData("player", GameController.Instance.Player.transform.position, GameController.Instance.Player.transform.rotation, GameController.Instance.Player.activeSelf, ""));
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		foreach (GameObject _object in allObjects)
		{
			if (_object.tag.Contains("Entity"))
			{
				entityTransform.Add(new EntitySaveData(_object.name, _object.transform.position, _object.transform.rotation, _object.activeSelf, _object.transform.parent.tag));

			}
		}

	}
}

/// <summary>
/// Class use for identifying save data for any entity
/// </summary>
public class EntitySaveData
{
	public string name;
	public Vector3 position;
	public Quaternion rotation;
	public bool active;
	public string parent;

	public EntitySaveData(string name, Vector3 position, Quaternion rotation, bool active, string parent)
	{
		this.name = name;
		this.position = position;
		this.rotation = rotation;
		this.active = active;
		this.parent = parent;
	}
}
