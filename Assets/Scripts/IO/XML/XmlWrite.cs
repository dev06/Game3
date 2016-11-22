using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Linq;
public class XmlWrite: MonoBehaviour
{
	public static XmlWriter writer;



	void Awake()
	{
		if (File.Exists(XmlLoader.SAVE_DATA_PATH) == false)
		{
			CreateANewSaveFile();
		} else
		{

		}
	}


	static void CreateANewSaveFile()
	{

		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.NewLineOnAttributes = true;
		using (XmlWriter xmlWriter = XmlWriter.Create(XmlLoader.SAVE_DATA_PATH, xmlWriterSettings))
		{
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("wrapper");

			xmlWriter.WriteEndElement();

			xmlWriter.WriteEndDocument();
			xmlWriter.Flush();
			xmlWriter.Close();
		}
	}

	public static void SaveData(string path)
	{
		XDocument xDocument = XDocument.Load(XmlLoader.SAVE_DATA_PATH);
		User loggedUser = GameController.Instance.loggedUser;
		XElement wrapper = xDocument.Element("wrapper");


		try
		{

			XElement user = wrapper.Element(loggedUser.username);

			//	user.Add(new XAttribute("password", loggedUser.password));
			user.RemoveNodes();
			user.Remove();

			WriteInventory(user);
			WriteSettings(user);
			WriteEntities(user);
			wrapper.Add(user);



		} catch (System.Exception e)
		{
			XElement user = new XElement(loggedUser.username);
			user.Add(new XAttribute("password", loggedUser.password));
			user.Add(new XAttribute("name", loggedUser.name));
			user.RemoveNodes();
			WriteInventory(user);
			WriteSettings(user);
			WriteEntities(user);

			wrapper.Add(user);


		}

		xDocument.Save(XmlLoader.SAVE_DATA_PATH);
		Debug.Log("Data Saved");
	}

	public static void SaveUserData(XmlWriter writer, string path, User loggedUser)
	{


	}

	private static void WriteEntities(XElement wrapper)
	{
		XElement entityNode = new XElement("entities");
		List<EntitySaveData> entityTransform = GameController.Instance.saveManager.entityTransform;
		foreach (EntitySaveData transform in entityTransform)
		{
			XElement name_node =  new XElement(transform.name);

			//===============================ADDS TYPE================================================================

			XElement type_node = new XElement("type");
			type_node.Add(new XAttribute("type", transform.type.ToString()));

			//===============================================================================================
			//==============================ADDS POSITION=================================================================

			XElement position_node = new XElement("position");
			position_node.Add(new XAttribute("position",  transform.position.x.ToString() + "," + transform.position.y.ToString() + "," + transform.position.z.ToString()));

			//===============================================================================================
			//==============================ADDS ROTATION=================================================================

			XElement rotation_node = new XElement("rotation");
			rotation_node.Add(new XAttribute("rotation",  transform.rotation.x.ToString() + "," + transform.rotation.y.ToString() + "," + transform.rotation.z.ToString()));

			//===============================================================================================
			//==============================ADDS PARENT=================================================================

			XElement parent_node = new XElement("parent");
			parent_node.Add(new XAttribute("parent", transform.parent.ToString()));

			//===============================================================================================
			//==============================ADDS ACTIVE=================================================================
			XElement active_node = new XElement("active");
			active_node.Add(new XAttribute("active", transform.active.ToString()));

			switch (transform.type)
			{
				case EntityType.MOB:
				{
					XElement health_node = new XElement("health");
					health_node.Add(new XAttribute("health", transform.g_Object.GetComponent<Mob>().GetHealth.ToString()));
					name_node.Add(health_node);
					break;
				}

				case EntityType.PROJECTILE:
				{
					XElement forward_node = new XElement("forward");
					Vector3 forward = transform.g_Object.GetComponent<Projectile>().forward;
					forward_node.Add(new XAttribute("forward", forward.x + "," + forward.y + "," + forward.z));
					name_node.Add(forward_node);
					break;
				}
			}

			name_node.Add(type_node);
			name_node.Add(position_node);
			name_node.Add(rotation_node);
			name_node.Add(parent_node);
			name_node.Add(active_node);

			entityNode.Add(name_node);
		}

		wrapper.Add(entityNode);
	}


	// private static void WriteEntities(XmlWriter writer)
	// {
	// 	writer.WriteStartElement("entities");
	// 	List<EntitySaveData> entityTransform = GameController.Instance.saveManager.entityTransform;
	// 	foreach (EntitySaveData transform in entityTransform)
	// 	{
	// 		// Transform elementTransform = transform.Value;
	// 		writer.WriteStartElement(transform.name);

	// 		writer.WriteStartElement("type");
	// 		writer.WriteAttributeString("type", transform.type.ToString());
	// 		writer.WriteEndElement();


	// 		writer.WriteStartElement("position");
	// 		writer.WriteAttributeString("position", transform.position.x.ToString() + "," + transform.position.y.ToString() + "," + transform.position.z.ToString());
	// 		writer.WriteEndElement();

	// 		writer.WriteStartElement("rotation");
	// 		writer.WriteAttributeString("rotation", transform.rotation.x.ToString() + "," + transform.rotation.y.ToString() + "," + transform.rotation.z.ToString());

	// 		writer.WriteEndElement();

	// 		writer.WriteStartElement("parent");
	// 		writer.WriteAttributeString("parent", transform.parent.ToString());
	// 		writer.WriteEndElement();

	// 		writer.WriteStartElement("active");
	// 		writer.WriteAttributeString("active", transform.active.ToString());
	// 		writer.WriteEndElement();

	// 		if (transform.type == EntityType.MOB)
	// 		{
	// 			writer.WriteStartElement("health");
	// 			writer.WriteAttributeString("health", transform.g_Object.GetComponent<Mob>().GetHealth.ToString());
	// 			writer.WriteEndElement();
	// 		}

	// 		if (transform.type == EntityType.PROJECTILE)
	// 		{
	// 			writer.WriteStartElement("forward");
	// 			Vector3 forward = transform.g_Object.GetComponent<Projectile>().forward;
	// 			writer.WriteAttributeString("forward", forward.x + "," + forward.y + "," + forward.z);
	// 			writer.WriteEndElement();
	// 		}



	// 		writer.WriteEndElement();
	// 	}
	// 	writer.WriteEndElement();
	// }

	private static void WriteInventory(XElement wrapper)
	{
		XElement inventoryNode = new XElement("inventory");

		List<InventorySlot> inventory = GameController.Instance.inventoryManager.inventorySlots;
		int index = 0;

		foreach (InventorySlot slot in inventory)
		{
			if (slot.item != null)
			{
				XElement slotNode = new XElement("slot" + index);
				slotNode.Add(new XAttribute("item", slot.item.itemID + ""));
				slotNode.Add(new XAttribute("itemQuantity", slot.item.itemQuantity + ""));
				inventoryNode.Add(slotNode);

				index++;

			} else {

				XElement slotNode = new XElement("slot" + index);
				slotNode.Add(new XAttribute("item", ""));
				slotNode.Add(new XAttribute("itemQuantity", "0"));
				index++;

				inventoryNode.Add(slotNode);
			}
		}

		XElement quickInventoryNode = new XElement("quickItemSelect");
		if (GameController.Instance.inventoryManager.quickItemSelectedSlot != null)
		{
			int quickItemIndex = GameController.Instance.inventoryManager.GetSlotIndex(
			                         GameController.Instance.inventoryManager.quickItemSlots,
			                         GameController.Instance.inventoryManager.quickItemSelectedSlot);


			quickInventoryNode.Add(new XAttribute("quickItemSelect", "" + quickItemIndex));

		}

		inventoryNode.Add(quickInventoryNode);
		wrapper.Add(inventoryNode);
	}



	// private static void WriteInventory(XmlWriter writer)
	// {
	// 	writer.WriteStartElement("inventory");
	// 	List<InventorySlot> inventory = GameController.Instance.inventoryManager.inventorySlots;
	// 	int index = 0;
	// 	foreach (InventorySlot slot in inventory)
	// 	{
	// 		if (slot.item != null)
	// 		{
	// 			writer.WriteStartElement("slot" + index);
	// 			//writes item name to xml node
	// 			writer.WriteAttributeString("item", slot.item.itemID + "");
	// 			writer.WriteAttributeString("itemQuantity", slot.item.itemQuantity + "");

	// 			writer.WriteEndElement();

	// 			index++;

	// 		} else {
	// 			writer.WriteStartElement("slot" + index);
	// 			writer.WriteAttributeString("item", "");
	// 			writer.WriteAttributeString("itemQuantity", "0");
	// 			writer.WriteEndElement();

	// 			index++;
	// 		}
	// 	}

	// 	writer.WriteStartElement("quickItemSelect");
	// 	if (GameController.Instance.inventoryManager.quickItemSelectedSlot != null)
	// 	{
	// 		int quickItemIndex = GameController.Instance.inventoryManager.GetSlotIndex(
	// 		                         GameController.Instance.inventoryManager.quickItemSlots,
	// 		                         GameController.Instance.inventoryManager.quickItemSelectedSlot);

	// 		writer.WriteAttributeString("quickItemSelect", "" + quickItemIndex);

	// 	}
	// 	writer.WriteEndElement();
	// 	writer.WriteEndElement(); // ends inventory element

	// }

	private static void WriteSettings(XElement wrapper)
	{
		XElement settingNode = new XElement("setting");

		List<KeyValuePair<string, float>> settingKvp = GameController.Instance.saveManager.settingKVP;

		foreach (KeyValuePair<string, float> kvp in settingKvp)
		{
			settingNode.Add(new XAttribute(kvp.Key, kvp.Value + ""));

		}

		wrapper.Add(settingNode);



	}


	// private static void WriteSettings(XmlWriter writer)
	// {
	// 	writer.WriteStartElement("setting");

	// 	List<KeyValuePair<string, float>> settingKvp = GameController.Instance.saveManager.settingKVP;

	// 	foreach (KeyValuePair<string, float> kvp in settingKvp)
	// 	{
	// 		writer.WriteAttributeString(kvp.Key, kvp.Value + "");

	// 	}

	// 	writer.WriteEndElement();// end setting element

	// }


	public static void DeleteFile()
	{
		if (File.Exists(Application.persistentDataPath + "/Save.xml"))
		{
			File.Delete(Application.persistentDataPath + "/Save.xml");
		}
	}

	public static bool DoesFileExists(string path)
	{
		XDocument xDocument = XDocument.Load(XmlLoader.SAVE_DATA_PATH);

		XElement wrapper = xDocument.Element("wrapper");

		User loggedUser = GameController.Instance.loggedUser;

		XElement user = wrapper.Element(loggedUser.username);


		return (user != null);

	}

}

