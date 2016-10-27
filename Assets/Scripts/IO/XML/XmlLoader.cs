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

	private static void LoadDefaultSetting()
	{

	}



}
