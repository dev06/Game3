using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
public class SaveManager : MonoBehaviour {




	public List<KeyValuePair<string, float>> settingKVP = new List<KeyValuePair<string, float>>();
	public List<EntitySaveData> entityTransform = new List<EntitySaveData>();

	void OnEnable()
	{
		EventManager.OnSave += OnSave;
	}

	void OnDisable()
	{
		EventManager.OnSave -= OnSave;
	}

	void Awake()
	{

	}

	void Start()
	{
		GameController.Instance.saveManager = this;
	}



	void OnSave()
	{
		UpdateData();
		XmlWrite.SaveData(Application.persistentDataPath + "/Save_data.xml");

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
		settingKVP.Add(new KeyValuePair<string, float>("TextureQuality", Constants.TextureQuality));
		settingKVP.Add(new KeyValuePair<string, float>("MusicVolume", Constants.musicVolume));
		settingKVP.Add(new KeyValuePair<string, float>("SFXVolume", Constants.sfxVolume));
		Debug.Log("Saved for" + Constants.musicVolume);


	}

	private void UpdateEntityTransform()
	{
		entityTransform.Clear();
		entityTransform.Add(new EntitySaveData(GameController.Instance.Player, "player", GameController.Instance.Player.transform.position, GameController.Instance.Player.transform.eulerAngles, GameController.Instance.Player.activeSelf, "", GameController.Instance.Player.GetComponent<MasterEntity>().entityType));
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		foreach (GameObject _object in allObjects)
		{
			if (_object.tag.Contains("Entity"))
			{
				entityTransform.Add(new EntitySaveData(_object, _object.name, _object.transform.position, _object.transform.eulerAngles, _object.activeSelf, _object.transform.parent.tag, _object.GetComponent<MasterEntity>().entityType));
			}
		}
	}
}

/// <summary>
/// Class use for identifying save data for any entity
/// </summary>
public class EntitySaveData
{
	public GameObject g_Object;
	public string name;
	public EntityType type;
	public Vector3 position;
	public Vector3 rotation;

	public bool active;
	public string parent;


	public EntitySaveData(GameObject g_Object, string name, Vector3 position, Vector3 rotation, bool active, string parent, EntityType type)
	{
		this.g_Object = g_Object;
		this.name = name;
		this.position = position;
		this.rotation = rotation;
		this.active = active;
		this.parent = parent;
		this.type = type;
	}
}

public enum EntityType
{
	NONE,
	COLLECTIBLE,
	MOB,
	PROJECTILE,
}
