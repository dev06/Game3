using UnityEngine;
using System.Collections;

public class Constants  {

	//Control Members
	public const string FORWARD = "Vertical";
	public const string STRAFE = "Horizontal";
	public const string X_LOOK = "Mouse X";
	public const string Y_LOOK = "Mouse Y";

	//Game mech
	public const int StartBotSpawningDelay = 0; //bots will spawn after x seconds (starting)
	public const int BotSpawnDelay = 2; //spawn bots every x secs
	public const int MaxBotAtTime = 1;


	//Enemy Members
	public const float BotMaxHealth = 200.0f;
	public const float BotMovementSpeed = 4.5f;
	public const float BotInitalDamage = 5.0f;

	//Patrol Enemy

	public const float PatrolEnemyMaxHealth = 400.0f;
	public const float PatrolEnemyDamage = 10.0f;
	public const float PatrolEnemySpeed = 10.0f;


	//Guard Enemy
	public const float GuardEnemyMaxHealth = 500.0f;
	public const float GuardEnemyShootDelay = 0.75f;
	public const float GuardEnemySpeed = 7;


	#region---FRIENDLY---
	//Droid
	public const float DroidDistanceToAttack = 25.0f;
	public const float DroidMovementSpeed = 10.0f;
	public const float DroidMaxHealth = 50.0f;



	#endregion---/FRIENDLY---

	//Player/Camera members
	public const float PlayerMaxHealth = 100.0f;
	public const float SmallProjectileDamage = 10.0f;
	public const float CameraVerticalFOV = 60.0f;
	public const float CameraDistanceFromPlayer = 8.0f;
	public const float CameraRecoilAmount = 0.5f; // amount is being added to the camera distance from the player.

	public const float PlayerForwardAcc = .3f;
	public const float PlayerStrafeAcc = .35f;
	public const float PlayerRotationVerticalDelay = 8f; // uses lerp
	public const float PlayerRotationHorizontalDelay = .25f; // uses damp therefore big difference in values.





	//Projectile Members
	public const float DefaultPlayerMovementSpeed = 10.0f;
	public static float PlayerMovementSpeed = 10.0f;


	public const float Character_BlueProjectileDamage_Default = 2.0f;
	public const float Character_YellowProjectileDamage_Default = 5.0f;
	public const float Character_PurpleProjectileDamage_Default = 15.0f;

	public static float Character_BlueProjectileDamage = 2.0f;
	public static float Character_YellowProjectileDamage = 5.0f;
	public static float Character_PurpleProjectileDamage = 15.0f;
	public const float GuardEnemy_ProjectileDamage = 2.0f;
	public const float Droid_ProjectileDamage = 4.0f;


	//HEALTH MECH
	public const float HealthRepletionTimer = 10.0f;  //units in seconds.
	public const float HealthRepletionPoints = 2.0f;  // Repletes x points every second.

	//UI
	public const float HideControlUITimer = 5.0f;


	//Entity
	public const float EntityRotationSpeed = 25f;
	public const float EntityHoverAmp = .05f;
	public const float EntityHoverFreq = .1f;

	public const float BasicHealthRepletion = 5f;
	public const float InterMedHealthRepletion = 10f;
	public const float AdvancedHealthRepletion = 15f;
	public const float SuperHealthRepletion = 75f;

	public const float SpeedBuffAmount = 25.0f;

	public const float BlastDamage = 150f;
	public const float BlastRadius = 40f;

	public const float ProjectilePenetration_Percent = 100f; // does x percent more damage then the default value.


	public static bool ToggleShadow = true;
	public static int ShadowQuality = 0;
	public static bool FullScreen = true;


	public static Material Character_Blue_Mat = (Material)Resources.Load("Materials/Entity/Character/character_blue_mat/character_blue_mat");
	public static Material Character_Purple_Mat = (Material)Resources.Load("Materials/Entity/Character/character_purple_mat/character_purple_mat");
	public static Material Character_Yellow_Mat = (Material)Resources.Load("Materials/Entity/Character/character_yellow_mat/character_yellow_mat");


	public static Material Character_Blue_Hover_Mat = (Material)Resources.Load("Materials/Particles/Hover/blue_hover");
	public static Material Character_Yellow_Hover_Mat = (Material)Resources.Load("Materials/Particles/Hover/yellow_hover");
	public static Material Character_Purple_Hover_Mat = (Material)Resources.Load("Materials/Particles/Hover/purple_hover");

	public static Material Character_Blue_Shoot_Mat = (Material)Resources.Load("Materials/Entity/EntityParticles/shoot_particles/blue_effect_shoot");
	public static Material Character_Yellow_Shoot_Mat = (Material)Resources.Load("Materials/Entity/EntityParticles/shoot_particles/yellow_effect_shoot");
	public static Material Character_Purple_Shoot_Mat = (Material)Resources.Load("Materials/Entity/EntityParticles/shoot_particles/purple_effect_shoot");

	public static GameObject Blue_Bullet = (GameObject)Resources.Load("Prefabs/Projectile/Player/BlueBullet");
	public static GameObject Yellow_Bullet = (GameObject)Resources.Load("Prefabs/Projectile/Player/YellowBullet");
	public static GameObject Purple_Bullet = (GameObject)Resources.Load("Prefabs/Projectile/Player/PurpleBullet");


	public static GameObject Droid_Bullet = (GameObject)Resources.Load("Prefabs/Projectile/Friendly/Droid/Droid_Bullet");


	public static GameObject Enemy_Two_Bullet = (GameObject)Resources.Load("Prefabs/Projectile/Enemy/Enemy_Two/Enemy_Two_Bullet");

	public static GameObject Teleporation_Projectile = (GameObject)Resources.Load("Prefabs/Entity/Buff/TeleportBuff/TeleportProjectile");
	public static GameObject Blast_Buff_Particle = (GameObject)Resources.Load("Prefabs/Particles/BlastBuff");

	public static GameObject PickUpItemNotification = (GameObject)Resources.Load("Prefabs/UIPrefabs/PickUp/PickUpItem_Notificaiton");

	public static KeyCode[] QuickItemKeys = new KeyCode[4] {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4};


	public static GameObject Resolution_Option = (GameObject)Resources.Load("Prefabs/UIPrefabs/Menu/Setting/Resolution/_resolution");
	public static GameObject AA_Option = (GameObject)Resources.Load("Prefabs/UIPrefabs/Menu/Setting/AA/_aa");
	public static GameObject TextureQuality_Option = (GameObject)Resources.Load("Prefabs/UIPrefabs/Menu/Setting/TextureQuality/_textureQuality");
	public static GameObject ShadowQuality_Option = (GameObject)Resources.Load("Prefabs/UIPrefabs/Menu/Setting/Shadow/_shadowQuality");


}

public class ItemList
{
	public static Item BlueBall =  new Item("Blue Ball",
	                                        "A projectile that does " + Constants.Character_BlueProjectileDamage + " points of damage." ,
	                                        Resources.Load<Sprite>("Item/blueBall"), 150, ItemID.BlueBall, ItemType.Projectile);

	public static Item YellowBall = new Item("Yellow Ball",
	        "A projectile that does " + Constants.Character_YellowProjectileDamage + " points of damage.",
	        Resources.Load<Sprite>("Item/yellowBall"), 150, ItemID.YellowBall, ItemType.Projectile);

	public static Item PurpleBall = new Item("Purple Ball",
	        "A projectile that does  " + Constants.Character_PurpleProjectileDamage + " points of damage.",
	        Resources.Load<Sprite>("Item/purpleBall"), 100, ItemID.PurpleBall, ItemType.Projectile);


	public static Item BasicHealth =  new Item("Basic Health",
	        "A Simple Medkit that restores " +  Constants.BasicHealthRepletion + " health points" ,
	        Resources.Load<Sprite>("Item/greenHealth"), 4, ItemID.BasicHealth, ItemType.Collectible);

	public static Item IntermediateHealth = new Item("Intermediate Health",
	        "A little advanced Medkit that restores " + Constants.InterMedHealthRepletion + " health points" ,
	        Resources.Load<Sprite>("Item/redHealth"), 3, ItemID.InterMedHealth, ItemType.Collectible);

	public static Item AdvancedHealth = new Item("Advanced Health",
	        "A advanced Medkit that restores " + Constants.AdvancedHealthRepletion + " health points" ,
	        Resources.Load<Sprite>("Item/orangeHealth"), 3, ItemID.AdvancedHealth, ItemType.Collectible);

	public static Item SuperHealth = new Item("Super Health",
	        "A Super Medkit that restores " + Constants.SuperHealthRepletion + " health points" ,
	        Resources.Load<Sprite>("Item/blueHealth"), 1, ItemID.SuperHealth, ItemType.Collectible);

	public static Item SpeedBuff = new Item("Speed Buff",
	                                        "Increases player speed for certain amount of time" ,
	                                        Resources.Load<Sprite>("Item/buff"), 1, ItemID.SpeedBuff, ItemType.Buff);

	public static Item SlowMotionBuff = new Item("Slow motion Buff",
	        "Slows down time for certain amount of period." ,
	        Resources.Load<Sprite>("Item/slowMotion_buff"), 1, ItemID.SlowMotionBuff, ItemType.Buff);

	public static Item Teleporter = new Item("Teleporter",
	        "Teleports you to certain location" ,
	        Resources.Load<Sprite>("Item/teleport_buff"), 1, ItemID.TeleportationBuff, ItemType.Buff);

	public static Item Immortality = new Item("Immortality",
	        "Makes you immortal for certain period of time." ,
	        Resources.Load<Sprite>("Item/immortal_buff"), 1, ItemID.ImmortalityBuff, ItemType.Buff);

	public static Item Blast = new Item("Blast",
	                                    "Creates a blast shock wave near the player and damages near by enemies by " + Constants.BlastDamage + " health points." ,
	                                    Resources.Load<Sprite>("Item/blast_buff"), 1, ItemID.BlastBuff, ItemType.Buff);

	public static Item Penetration = new Item("Penetration",
	        "Projectiles does " + Constants.ProjectilePenetration_Percent + " more damage allowing a massive to the enemies." ,
	        Resources.Load<Sprite>("Item/projectile_penetration_buff"), 1, ItemID.ProjectilePenetrationBuff, ItemType.Buff);




}
