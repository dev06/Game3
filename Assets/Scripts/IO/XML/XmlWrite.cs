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
		using(XmlWriter writer = XmlWriter.Create(path))
		{
			writer.WriteStartDocument();
			writer.WriteStartElement("wrapper");


			WriteInventory(writer);
			WriteSettings(writer);
			WriteEntities(writer);

			writer.WriteEndElement(); // ends wrapper element
			writer.WriteEndDocument();
		}

		Debug.Log("Data Saved");
	}



	private static void WriteEntities(XmlWriter writer)
	{
		writer.WriteStartElement("entities");
		List<EntitySaveData> entityTransform = GameController.Instance.saveManager.entityTransform;
		foreach (EntitySaveData transform in entityTransform)
		{
			// Transform elementTransform = transform.Value;
			writer.WriteStartElement(transform.name);

			writer.WriteStartElement("position");
			writer.WriteAttributeString("position", transform.position.x.ToString() + "," + transform.position.y.ToString() + "," + transform.position.z.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("rotation");
			writer.WriteAttributeString("rotation", transform.rotation.x.ToString() + "," + transform.rotation.y.ToString() + "," + transform.rotation.z.ToString());

			writer.WriteEndElement();

			writer.WriteStartElement("parent");
			writer.WriteAttributeString("parent", transform.parent.ToString());
			writer.WriteEndElement();

			writer.WriteStartElement("active");
			writer.WriteAttributeString("active", transform.active.ToString());

			writer.WriteEndElement();


			writer.WriteEndElement();
		}
		writer.WriteEndElement();
	}

	private static void WriteInventory(XmlWriter writer)
	{
		writer.WriteStartElement("inventory");
		List<InventorySlot> inventory = GameController.Instance.inventoryManager.inventorySlots;
		int index = 0;
		foreach (InventorySlot slot in inventory)
		{
			if (slot.item != null)
			{
				writer.WriteStartElement("slot" + index);
				//writes item name to xml node
				writer.WriteAttributeString("item", slot.item.itemID + "");
				writer.WriteAttributeString("itemQuantity", slot.item.itemQuantity + "");

				writer.WriteEndElement();

				index++;

			} else {
				writer.WriteStartElement("slot" + index);
				writer.WriteAttributeString("item", "");
				writer.WriteAttributeString("itemQuantity", "0");
				writer.WriteEndElement();

				index++;
			}
		}
		writer.WriteEndElement(); // ends inventory element

	}

	private static void WriteSettings(XmlWriter writer)
	{
		writer.WriteStartElement("setting");

		List<KeyValuePair<string, float>> settingKvp = GameController.Instance.saveManager.settingKVP;

		foreach (KeyValuePair<string, float> kvp in settingKvp)
		{
			writer.WriteAttributeString(kvp.Key, kvp.Value + "");

		}

		writer.WriteEndElement();// end setting element

	}


	public static void DeleteFile()
	{
		if (File.Exists(Application.persistentDataPath + "/Save.xml"))
		{
			File.Delete(Application.persistentDataPath + "/Save.xml");
		}
	}

	public static bool DoesFileExists(string path)
	{
		return File.Exists(path);
	}

}

