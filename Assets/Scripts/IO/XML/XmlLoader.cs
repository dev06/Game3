using UnityEngine;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Generic;
public class XmlLoader : MonoBehaviour
{

	public static string SAVE_DATA_PATH = Application.persistentDataPath + "/Save_data.xml";


	void Start()
	{
		try
		{
			PopulateUserDatabase(SAVE_DATA_PATH);
		} catch (System.Exception e)
		{
		}
	}

	public static void LoadData()
	{
		LoadXMLData();

	}

	public static void LoadXMLData()
	{

		try {
			LoadSavedXmlData(System.IO.File.ReadAllText(SAVE_DATA_PATH));

		} catch (System.Exception e)
		{
			TextAsset asset = (TextAsset)(Resources.Load("GameData/Default"));
			LoadDefaultXmlData(asset.text);
			Debug.LogError(e + "File does not exits");
		}
	}




	/// <summary>
	/// Loads the default xml data when saved file is not found
	/// </summary>
	/// <param name="path"></param>
	public static void LoadDefaultXmlData(string path)
	{
		XmlDocument _xmlDoc = new XmlDocument();
		_xmlDoc.LoadXml(path);
		LoadDefaultInventory(_xmlDoc);
		LoadDefaultSetting(_xmlDoc);
		LoadDefaultEntity(_xmlDoc);
	}

	/// <summary>
	/// Loadsn saved data when the xml file is found
	/// </summary>
	/// <param name="path"></param>
	public static void LoadSavedXmlData(string path)
	{
		XmlDocument _xmlDoc = new XmlDocument();
		_xmlDoc.LoadXml(path);
		XmlNodeList currentUserNode = _xmlDoc.GetElementsByTagName(GameController.Instance.loggedUser.username);
		foreach (XmlNode n in currentUserNode)
		{
			foreach (XmlNode n1 in n)
			{
				switch (n1.Name)
				{
					case "inventory":
					{
						LoadSavedInventory(n1);


						break;
					}
					case "setting":
					{
						LoadSavedSetting(n1);
						break;
					}
					case "entities":
					{
						LoadSavedEntities(n1);
						break;
					}
				}

			}
		}



	}

	public static void PopulateUserDatabase(string path)
	{
		XmlDocument _xmlDoc = new XmlDocument();
		_xmlDoc.Load(path);
		XmlNodeList users = _xmlDoc.GetElementsByTagName("wrapper");
		foreach (XmlNode node in users )
		{
			//creates the users instance

			foreach (XmlNode currentUser in node)
			{
				User loadUser = new User();
				// sets the user name
				loadUser.SetUserName(currentUser.Name);
				XmlAttributeCollection attrColl = currentUser.Attributes;
				//goes through all its attributes
				foreach (XmlAttribute attribute in attrColl)
				{
					switch (attribute.LocalName)
					{
						case "password":
						{
							loadUser.SetPassword(attribute.Value);
							break;
						}

						case "name":
						{
							loadUser.SetName(attribute.Value);
							break;
						}
					}
				}

				GameController.Instance.users.Add(loadUser);
			}

		}
	}



	private static void LoadDefaultInventory(XmlDocument _xmlDoc)
	{
		XmlNodeList inventoryList = _xmlDoc.GetElementsByTagName("defaultInventory");

		foreach (XmlNode inventoryNode in inventoryList)
		{
			foreach (XmlNode slotNode in inventoryNode)
			{

				string _itemId = "";
				int _itemCount = 0;

				foreach (XmlNode elementNode in slotNode)
				{

					switch (elementNode.Name)
					{
						case "item":
						{
							_itemId = elementNode.InnerText;
							break;
						}
						case "count":
						{
							_itemCount = int.Parse(elementNode.InnerText);
							break;
						}

					}
				}
				GameController.Instance.inventoryManager.AddItem(_itemId, _itemCount);
			}
		}
	}
	/// <summary>
	/// Loads the Default game setting from a doc
	/// </summary>
	/// <param name="_xmlDoc"></param>
	private static void LoadDefaultSetting(XmlDocument _xmlDoc)
	{
		XmlNodeList _settingList = _xmlDoc.GetElementsByTagName("defaultSetting");
		foreach (XmlNode _settingNode in _settingList)
		{
			foreach (XmlNode _settingOption in _settingNode)
			{
				switch (_settingOption.Name)
				{
					case "textureQuality":
					{
						QualitySettings.masterTextureLimit = int.Parse(_settingOption.InnerText);
						break;
					}
					case "antiAliasing":
					{
						Constants.AntiAliasingQuality = int.Parse(_settingOption.InnerText);
						break;
					}
					case "toggleShadow":
					{
						int _parsedValue = int.Parse(_settingOption.InnerText);
						Constants.ToggleShadow = (_parsedValue == 0) ? false : true;
						break;
					}
					case "shadowQuality":
					{
						Constants.ShadowQuality = int.Parse(_settingOption.InnerText);
						break;
					}
					case "fullScreen":
					{
						int _parsedValue = int.Parse(_settingOption.InnerText);
						Constants.FullScreen = (_parsedValue == 0) ? false : true;
						break;
					}
					case "vSync":
					{
						int _parsedValue = int.Parse(_settingOption.InnerText);
						Constants.VSync = (_parsedValue == 0) ? false : true;
						break;
					}
					case "musicVolume":
					{
						Constants.musicVolume = float.Parse(_settingOption.InnerText);
						break;
					}
					case "sfxVolume":
					{
						Constants.sfxVolume = float.Parse(_settingOption.InnerText);
						break;
					}

				}
			}
		}
	}

	private static void LoadDefaultEntity(XmlDocument _xmlDoc)
	{
		XmlNodeList _entityList = _xmlDoc.GetElementsByTagName("defaultEntity");
		foreach (XmlNode root in _entityList)
		{
			foreach (XmlNode element in root)
			{
				GameController.Instance.spawnManager.LoadGameEntites(element);
			}
		}

	}




	#region===================================================Saved ==================================================


	private static void LoadSavedInventory(XmlNode _xmlDoc)
	{


		//XmlNodeList inventoryList = _xmlDoc.GetElementsByTagName("inventory");
		foreach (XmlNode inventoryNode in _xmlDoc)
		{

			if (inventoryNode.Name == "quickItemSelect")
			{
				try {
					GameController.Instance.inventoryManager.quickItemSelectedSlot =
					    GameController.Instance.inventoryManager.quickItemSlots[int.Parse(inventoryNode.Attributes["quickItemSelect"].Value)];
				} catch (System.Exception e)
				{

				}
			} else {

				string _itemId = "";
				int _itemCount = 0;
				_itemId = inventoryNode.Attributes["item"].Value;
				_itemCount = int.Parse(inventoryNode.Attributes["itemQuantity"].Value);
				GameController.Instance.inventoryManager.AddItem(_itemId, _itemCount);

			}

		}
	}

	private static void LoadSavedSetting(XmlNode _xmlDoc)
	{
		//XmlNodeList settingList = _xmlDoc.GetElementsByTagName("setting");

		XmlAttributeCollection attrColl = _xmlDoc.Attributes;
		foreach (XmlAttribute settingAttr in attrColl)
		{
			switch (settingAttr.LocalName)
			{
				case "ToggleShadow":
				{
					int _rawValue = int.Parse(settingAttr.Value);
					Constants.ToggleShadow = (_rawValue == 1) ? true : false;
					break;
				}
				case "FullScreen":
				{
					int _rawValue = int.Parse(settingAttr.Value);
					Constants.FullScreen = (_rawValue == 1) ? true : false;
					break;
				}
				case "VSync":
				{
					int _rawValue = int.Parse(settingAttr.Value);
					Constants.VSync = (_rawValue == 1) ? true : false;
					break;
				}
				case "ShadowQuality":
				{
					Constants.ShadowQuality = int.Parse(settingAttr.Value);
					break;
				}

				case "AntiAliasingQuality":
				{
					Constants.AntiAliasingQuality = int.Parse(settingAttr.Value);
					QualitySettings.antiAliasing = Constants.AntiAliasingQuality;
					break;
				}

				case "TextureQuality":
				{
					Constants.TextureQuality = int.Parse(settingAttr.Value);
					QualitySettings.masterTextureLimit = Constants.TextureQuality;
					break;
				}
				case "MusicVolume":
				{
					Constants.musicVolume = float.Parse(settingAttr.Value);
					AudioManager.Instance.musicSlider.value = Constants.musicVolume;
					break;
				}
				case "SFXVolume":
				{
					Constants.sfxVolume = float.Parse(settingAttr.Value);
					AudioManager.Instance.sfxSlider.value = Constants.sfxVolume;
					break;
				}


			}
		}

	}

	private static void LoadSavedEntities(XmlNode _xmlDoc)
	{
		//XmlNodeList entityList = _xmlDoc.GetElementsByTagName("entities");

		foreach (XmlNode entity in _xmlDoc)
		{


			GameController.Instance.spawnManager.LoadGameEntites(entity);

		}
	}

	#endregion===================================================/Saved ==================================================



}
