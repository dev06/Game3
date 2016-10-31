using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
public class XmlWrite: MonoBehaviour
{

	public static void Write()
	{
		List<string> list = new List<string>();
		list.Add("Hellow");
		list.Add("Apple");
		using(XmlWriter writer = XmlWriter.Create("testXml.xml"))
		{
			writer.WriteStartDocument();
			writer.WriteStartElement("Test");
			foreach (string l in list) {
				writer.WriteStartElement("string");

				writer.WriteElementString("value", "10");
				writer.WriteEndElement();
			}

			writer.WriteEndElement();
			writer.WriteEndDocument();
		}
	}


	public static void SaveData(string path)
	{

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
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndDocument();
		}

		Debug.Log("Data Saved");
	}

}

