using UnityEngine;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;
public class XmlLoader : MonoBehaviour
{


	public static void LoadData()
	{
		LoadXMLData();
	}

	public static void LoadXMLData()
	{

		try {
			LoadSavedXmlData(System.IO.File.ReadAllText(Application.persistentDataPath + "/Save.xml"));

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
	}

	/// <summary>
	/// Loadsn saved data when the xml file is found
	/// </summary>
	/// <param name="path"></param>
	public static void LoadSavedXmlData(string path)
	{
		XmlDocument _xmlDoc = new XmlDocument();
		_xmlDoc.LoadXml(path);
		LoadSavedInventory(_xmlDoc);
		LoadSavedSetting(_xmlDoc);
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


	private static void LoadSavedInventory(XmlDocument _xmlDoc)
	{
		XmlNodeList inventoryList = _xmlDoc.GetElementsByTagName("inventory");

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

	private static void LoadSavedSetting(XmlDocument _xmlDoc)
	{
		XmlNodeList settingList = _xmlDoc.GetElementsByTagName("setting");
		foreach (XmlNode list in settingList)
		{
			foreach (XmlNode settingNode in list)
			{
				Debug.Log(settingNode.Name);
				switch (settingNode.Name)
				{
				case "ToggleShadow":
					{
						int _rawValue = int.Parse(settingNode.InnerText);
						Constants.ToggleShadow = (_rawValue == 1) ? true : false;
						break;
					}
				case "FullScreen":
					{
						int _rawValue = int.Parse(settingNode.InnerText);
						Constants.FullScreen = (_rawValue == 1) ? true : false;
						break;
					}
				case "VSync":
					{
						int _rawValue = int.Parse(settingNode.InnerText);
						Constants.VSync = (_rawValue == 1) ? true : false;
						break;
					}
				case "ShadowQuality":
					{
						Constants.ShadowQuality = int.Parse(settingNode.InnerText);
						break;
					}
				case "AntiAliasingQuality":
					{
						Constants.AntiAliasingQuality = int.Parse(settingNode.InnerText);
						break;
					}
				}
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
				}
			}
		}
	}
}
