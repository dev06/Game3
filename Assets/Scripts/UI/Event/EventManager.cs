using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void InventoryActive(int direction);
	public static  InventoryActive OnInventoryActive;
	public static  InventoryActive OnInventoryUnActive;


	public delegate void ItemAddedOrRemoved();
	public static ItemAddedOrRemoved OnItemAddedOrRemoved;


	public delegate void Shoot();
	public static Shoot OnShoot;


	public delegate void QuickItemSelected();
	public static QuickItemSelected OnQuickItemChange;


	public delegate void ResetGame();
	public static ResetGame OnReset;

	public delegate void PauseGame();
	public static PauseGame OnPause;
	public static PauseGame OnUnpause;


	public delegate void Setting();
	public static Setting OnSettingActive;
	public static Setting OnSettingUnactive;

	public delegate void Credit();
	public static Credit OnCreditActive;
	public static Credit OnCreditUnactive;


	public delegate void Login();
	public static Login OnLoginButtonPress;
	public static Login OnRegisterButtonPress;
	public static Login OnCreateProfileButtonPress;
	public static Login OnLoginSuccess;


	public delegate void IO();
	public static IO OnSave;


	//local events
	public delegate void ShadowToggle();
	public static ShadowToggle OnShadowToggleUnactive;
	public static ShadowToggle OnShadowToggleActive;



	public delegate void MenuButtonEvent(ButtonID id);
	public static MenuButtonEvent OnNewGame;
	public static MenuButtonEvent OnLoadGame;
	public static MenuButtonEvent OnSetting;
	public static MenuButtonEvent OnCredit;


}
