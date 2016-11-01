using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SettingController : MonoBehaviour
{

	public List<KeyValuePair<string, float>> settingKVP = new List<KeyValuePair<string, float>>();

	void Start()
	{
		GameController.Instance.settingController = this;

	}


	void Update()
	{

	}

	/// <summary>
	/// Update the settings values to key value pair
	/// </summary>
	public void UpdateSettingValues()
	{
		settingKVP.Clear();
		settingKVP.Add(new KeyValuePair<string, float>("ToggleShadow", (Constants.ToggleShadow) ? 1 : 0));
		settingKVP.Add(new KeyValuePair<string, float>("ShadowQuality", Constants.ShadowQuality));
		settingKVP.Add(new KeyValuePair<string, float>("AntiAliasingQuality", Constants.AntiAliasingQuality));
		settingKVP.Add(new KeyValuePair<string, float>("FullScreen", (Constants.FullScreen) ? 1 : 0));
		settingKVP.Add(new KeyValuePair<string, float>("VSync", (Constants.VSync) ? 1 : 0));
	}
}