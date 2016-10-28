using UnityEngine;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;
public class XmlLoader : MonoBehaviour
{

	public static void LoadDefaultXmlData(string path)
	{
		XmlDocument _xmlDoc = new XmlDocument();
		_xmlDoc.LoadXml(path);
		LoadDefaultInventory(_xmlDoc);
		LoadDefaultSetting(_xmlDoc);

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
					case "itemID":
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
						QualitySettings.antiAliasing = int.Parse(_settingOption.InnerText);
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
				}
			}
		}
	}
}
