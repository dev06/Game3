using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
public class XmlWrite: MonoBehaviour
{


	public static void SaveData(string path)
	{
		Debug.Log(path);
		using(XmlWriter writer = XmlWriter.Create(path))
		{
			writer.WriteStartDocument();
			writer.WriteStartElement("wrapper");
			writer.WriteStartElement("inventory");
			List<InventorySlot> inventory = GameController.Instance.inventoryManager.inventorySlots;
			int index = 0;
			foreach (InventorySlot slot in inventory)
			{
				if (slot.item != null)
				{
					writer.WriteStartElement("slot" + index);
					//writes item name to xml node
					writer.WriteElementString("item", slot.item.itemID + "");
					//writes item count to xml node
					writer.WriteElementString("count", slot.item.itemQuantity + "");
					writer.WriteEndElement();

					index++;

				} else {
					writer.WriteStartElement("slot" + index);
					writer.WriteElementString("item", " ");
					writer.WriteElementString("count", "0");
					writer.WriteEndElement();

					index++;
				}
			}
			writer.WriteEndElement(); // ends inventory element


			writer.WriteStartElement("setting");

			List<KeyValuePair<string, float>> settingKvp = GameController.Instance.settingController.settingKVP;

			foreach (KeyValuePair<string, float> kvp in settingKvp)
			{

				writer.WriteElementString(kvp.Key, kvp.Value + "");

			}

			writer.WriteEndElement();// end setting element


			writer.WriteEndElement(); // ends wrapper element
			writer.WriteEndDocument();
		}

		Debug.Log("Data Saved");
	}


	public static void DeleteFile()
	{
		if (File.Exists(Application.persistentDataPath + "/Save.xml"))
		{
			File.Delete(Application.persistentDataPath + "/Save.xml");
		}
	}

}

