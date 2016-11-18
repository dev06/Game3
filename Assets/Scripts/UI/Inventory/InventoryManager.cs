﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Responsible for updating the state of the inventory item (occupied or empty)
//Responsible for return next un-occupied slot
//Responsible for adding items to the inventory upon player collision
public class InventoryManager {

	public List<InventorySlot> inventorySlots = new List<InventorySlot>();
	public List<InventorySlot> quickItemSlots = new List<InventorySlot>();
	public Item hoverItem; // item that is currently being hovered on.
	public InventorySlot quickItemSelectedSlot;
	public bool isInventoryFull;
	public int inventoryCount;


	public InventoryManager()
	{

	}

	public void AddItem(Item item)
	{
		int itemIndexInInventory;
		int itemIndexInQuickInventory;
		if (DoesItemExits(inventorySlots, item, out itemIndexInInventory))
		{

			inventorySlots[itemIndexInInventory].UpdateItem(item);

			if (DoesItemExits(quickItemSlots, item, out itemIndexInQuickInventory))
			{
				quickItemSlots[itemIndexInQuickInventory].SetItem(inventorySlots[itemIndexInInventory].item);
			}
		} else
		{
			int nextSlot = GetNextAvailableSlot(inventorySlots);
			if (nextSlot != -1)
			{
				inventorySlots[nextSlot].SetItem(item);
			} else {
				isInventoryFull = true;
				Debug.Log("inventory is now full");
			}
		}
		inventoryCount = InventorySlotOccupied();

		if (EventManager.OnItemAddedOrRemoved != null)
		{
			EventManager.OnItemAddedOrRemoved();
		}

		if (GetNextAvailableSlot(quickItemSlots) != -1)
		{

			InventorySlot _currentQuickItemSlot = quickItemSlots[GetNextAvailableSlot(quickItemSlots)];
			if (IsCollectionEmpty(quickItemSlots))
			{
				quickItemSelectedSlot = _currentQuickItemSlot;

			}

			AddToQuickItem(item, _currentQuickItemSlot);
			if (EventManager.OnQuickItemChange != null)
			{
				EventManager.OnQuickItemChange();
			}

		}
	}


	public void AddItem(string _itemID, int _count)
	{
		switch (_itemID)
		{
			case "BlueBall":
				{
					Item item = ItemList.BlueBall;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}
			case "YellowBall":
				{
					Item item = ItemList.YellowBall;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}
			case "PurpleBall":
				{
					Item item = ItemList.PurpleBall;
					item.itemQuantity = _count;
					AddItem(item);

					break;
				}
			case "BasicHealth":
				{
					Item item = ItemList.BasicHealth;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}
			case "AdvancedHealth":
				{
					Item item = ItemList.AdvancedHealth;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}

			case "SuperHealth":
				{
					Item item = ItemList.SuperHealth;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}
			case "SpeedBuff":
				{
					Item item = ItemList.SpeedBuff;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}
			case "SlowMotionBuff":
				{
					Item item = ItemList.SlowMotionBuff;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}
			case "Teleporter":
				{
					Item item = ItemList.Teleporter;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}
			case "InterMedHealth":
				{
					Item item = ItemList.IntermediateHealth;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}

			case "Immortality":
				{
					Item item = ItemList.Immortality;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}
			case "Blast":
				{
					Item item = ItemList.Blast;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}
			case "Penetration":
				{
					Item item = ItemList.Penetration;
					item.itemQuantity = _count;
					AddItem(item);
					break;
				}
		}
	}

	public void AddToQuickItem(Item item, InventorySlot slot)
	{
		if (slot.inventoryType == InventoryType.QuickItem)
		{
			if (slot.item == null)
			{
				for (int i = 0; i < quickItemSlots.Count; i++)
				{
					if (quickItemSlots[i].item != null)
					{
						if (quickItemSlots[i].item.itemID == item.itemID)
						{
							quickItemSlots[i].RemoveSlotItem();
							quickItemSlots[i].SetItem(null);
						}
					}
				}
				slot.SetItem(item, GetSlotIndex(quickItemSlots, slot));

			} else
			{
				if (slot.item.itemID != item.itemID)
				{
					Item existingItem = slot.item;
					for (int i = 0; i < quickItemSlots.Count; i++)
					{
						if (quickItemSlots[i].item != null)
						{
							if (quickItemSlots[i].item.itemID == item.itemID)
							{
								quickItemSlots[i].RemoveSlotItem();
								quickItemSlots[i].SetItem(null);
							}
						}

					}
					slot.SetItem(item, GetSlotIndex(quickItemSlots, slot));
					for (int i = 0; i < quickItemSlots.Count; i++)
					{
						if (quickItemSlots[i].item == null)
						{
							quickItemSlots[i].SetItem(existingItem, i);
							break;
						}
					}
				}
			}
		}
	}

	public void ShiftItem(List<InventorySlot> collection)
	{

		for (int i = 0; i < collection.Count; i++)
		{
			InventorySlot currentSlot = collection[i];
			if (currentSlot.item != null)
			{
				if (i > 0 && i < collection.Count)
				{
					InventorySlot previousSlot = collection[i - 1];
					if (previousSlot.item == null)
					{
						previousSlot.SetItem(currentSlot.item);
						currentSlot.RemoveSlotItem();
						currentSlot.SetItem(null);
					}
				}
			}
		}


		if (EventManager.OnItemAddedOrRemoved != null)
		{
			EventManager.OnItemAddedOrRemoved();
		}
		inventoryCount = InventorySlotOccupied();

	}

	public int InventorySlotOccupied()
	{
		int slotsOccupied = 0;
		for (int i = 0; i < inventorySlots.Count; i++)
		{
			if (inventorySlots[i].item != null)
			{
				slotsOccupied++;
			}
		}
		return slotsOccupied;
	}


	public void SelectQuickItemSlot()
	{
		if (Input.anyKeyDown)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				quickItemSelectedSlot = quickItemSlots[0];
				if (EventManager.OnQuickItemChange != null)
				{
					EventManager.OnQuickItemChange();
				}
			} else 	if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				quickItemSelectedSlot = quickItemSlots[1];
				if (EventManager.OnQuickItemChange != null)
				{
					EventManager.OnQuickItemChange();
				}
			} else 	if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				quickItemSelectedSlot = quickItemSlots[2];
				if (EventManager.OnQuickItemChange != null)
				{
					EventManager.OnQuickItemChange();
				}
			} else 	if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				quickItemSelectedSlot = quickItemSlots[3];
				if (EventManager.OnQuickItemChange != null)
				{
					EventManager.OnQuickItemChange();
				}
			}
		}
	}

	public int GetSlotIndex(List<InventorySlot> collection, InventorySlot slot)
	{
		for (int i = 0; i < collection.Count; i++)
		{
			if (collection[i].GetHashCode() == slot.GetHashCode())
			{
				return i;
			}
		}

		return -1;
	}

	/// <summary>
	/// Returns whether an item exits in a collection
	/// </summary>

	public bool DoesItemExits(List<InventorySlot> collection, Item item, out int itemIndexInInventory)
	{
		itemIndexInInventory = 0;
		for (int i = 0; i < collection.Count; i++)
		{
			InventorySlot currentSlot = collection[i];
			if (currentSlot.item != null)
			{
				if (currentSlot.item.itemID == item.itemID)
				{
					itemIndexInInventory = i;
					return true;
				}
			}
		}

		itemIndexInInventory = -1;
		return false;
	}

	public bool isOccupied(InventorySlot slot)
	{
		return slot.item != null;
	}

	public bool isOfType(Item item, Item targetItem)
	{
		return item.itemID == targetItem.itemID;
	}

	public bool IsCollectionEmpty(List<InventorySlot> _collection)
	{
		for (int i = 0; i < _collection.Count; i++)
		{
			InventorySlot _slot = _collection[i];
			if (_slot.item == null)
			{
				continue;
			} else
			{
				return false;
			}
		}

		return true;
	}

	public bool isCollectionFull(List<InventorySlot> _collection)
	{
		for (int i = 0; i < _collection.Count; i++)
		{
			InventorySlot _slot = _collection[i];
			if (_slot.item != null)
			{
				continue;
			} else {
				return false;
			}
		}

		return true;
	}

	public int GetNextAvailableSlot(List<InventorySlot> collection)
	{
		for (int i = 0; i < collection.Count; i++)
		{
			Item currentSlotItem = collection[i].item;
			if (currentSlotItem == null)
			{
				return i;
			}
		}

		return -1;
	}
}
