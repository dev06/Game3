//Devan Patel
//Applications and Scripting
//Sep.12.2016
using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
namespace Game3
{


	public class CameraController : MonoBehaviour {

		#region---PUBLIC MEMBERS----
		public float CameraMoveSpeed;
		public float CameraLookSpeed;
		public float CameraLookAngle;
		public float bobAmplitude = 0.2f;
		public float bobFrequency = 0.8f;
		public float hoverAmplitude;
		public float hoverFrequency;
		public float cameraDistance;
		public float cameraHorizontalOffset;
		public Vector3 hoverHeight;
		#endregion---/ PUBLIC MEMBERS---

		#region---PRIVATE MEMBERS----
		private float recoilAmount;
		private float _lookInput = 0;
		private float _headBoxX;
		private float _headBobY;
		private float _lookHorizontalInput;
		private float _lookVerticalInput;
		private float _strafeInput;
		private float _forwardInput;
		private float _recoil;
		private float _recoilVel;
		private float _strafeVel;
		private float _forwardVel;
		private float _strafeAcc;
		private float _fowardAcc;
		private float _lookHorizontalVel;
		private float _lookHorizontalAcc;
		private bool _isMoving;
		private bool _moveCam;
		private Vector3 _headBobPos = Vector3.zero;
		private Vector3 _targetHeadBob = Vector3.zero;
		private Vector3 _targetHover = Vector3.zero;
		private Vector3 _hoverPos = Vector3.zero;
		private CharacterController _cc;
		private Rigidbody _rb;
		private Vector3 _velocity;
		private GameObject _child;
		private GameObject _bulletLeft;
		private GameObject _bulletRight;
		private GameObject _dummyLeft;
		private GameObject _dummyRight;
		private GameObject[] _weaponBarrels;
		private GameController _gameSceneManager;
		private GameObject _playerHead;

		#endregion---/PRIVATE MEMBERS---

		void OnEnable()
		{
			EventManager.OnPause += OnPause;
			EventManager.OnUnpause += OnUnpause;

		}

		void Disable()
		{
			EventManager.OnPause -= OnPause;
			EventManager.OnUnpause -= OnUnpause;

		}

		void OnPause()
		{

			Camera.main.GetComponent<BlurOptimized>().enabled = true;

		}

		void OnUnpause()
		{
			Camera.main.GetComponent<BlurOptimized>().enabled = false;

		}

		void Start ()
		{
			Init();
			recoilAmount = Constants.CameraRecoilAmount + Constants.CameraDistanceFromPlayer;

		}
		/// <summary>
		///	Init all the components.
		/// </summary>
		private void Init()
		{
			_rb = GetComponent<Rigidbody>();
			//_child = transform.FindChild("Main Camera").transform.gameObject;
			_child = Camera.main.transform.gameObject;
			_playerHead = GameObject.FindWithTag("Player/Head");
			_cc = GetComponent<CharacterController>();
			_gameSceneManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
			EventManager.OnShoot += MoveCamera;
		}

		// Update is called once per frame
		void Update ()
		{
			CameraMoveSpeed = Constants.PlayerMovementSpeed;

			if (_gameSceneManager.menuActive == MenuActive.GAME)
			{
				RegisterInput(_gameSceneManager.controllerProfile);
				if (_gameSceneManager.TogglePlayerMovement)
				{
					Move();
					Look();
					HoverPlayer();
					HeadBob();

				}

				if (_moveCam)
				{
					cameraDistance = Mathf.SmoothDamp(cameraDistance, recoilAmount, ref _recoilVel, .1f);
					if (recoilAmount - cameraDistance < .1f)
					{
						_moveCam = false;
					}
				} else {
					cameraDistance = Mathf.SmoothDamp(cameraDistance, Constants.CameraDistanceFromPlayer, ref _recoilVel, .1f);
				}
			}

		}
		/// <summary>
		/// Moves the Players
		/// </summary>

		private void Move()
		{
			float strafe = _strafeInput * CameraMoveSpeed ;
			float forward = _forwardInput * CameraMoveSpeed ;
			_strafeAcc = Mathf.SmoothDamp(_strafeAcc, _strafeInput * CameraMoveSpeed, ref _strafeVel, Constants.PlayerStrafeAcc);
			_fowardAcc = Mathf.SmoothDamp(_fowardAcc, _forwardInput * CameraMoveSpeed, ref _forwardVel, Constants.PlayerForwardAcc);

			Vector3 _movement = new Vector3(_strafeAcc, -5.0f, _fowardAcc);
			_movement = transform.rotation * _movement;

			if (Mathf.Abs(forward) > 0)
			{
				_velocity.z = forward;
			} else {
				_velocity.z = 0;
			}
			if (Mathf.Abs(strafe) > 0)
			{
				_velocity.x = strafe;

			} else {
				_velocity.x = 0;
			}

			_isMoving = strafe != 0 || forward != 0;

			_cc.Move(_movement * Time.deltaTime);


		}
		/// <summary>
		/// Registers the custom input based on the controller profile
		/// </summary>
		/// <param name="_cf"></param>
		private void RegisterInput(ControllerProfile _cf)
		{

			if (_cf == ControllerProfile.WASD)
			{
				_forwardInput = (Input.GetKey(KeyCode.W)) ? _forwardInput = 1 : (Input.GetKey(KeyCode.S)) ? _forwardInput = -1 : _forwardInput = 0;
				_strafeInput = (Input.GetKey(KeyCode.D)) ? _strafeInput = 1 : (Input.GetKey(KeyCode.A)) ? _strafeInput = -1 : _strafeInput = 0;
				_lookHorizontalInput = Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1);
				_lookVerticalInput = Input.GetAxis("Mouse Y");
			} else if (_cf == ControllerProfile.TGFH)
			{
				_forwardInput = (Input.GetKey(KeyCode.T)) ? _forwardInput = 1 : (Input.GetKey(KeyCode.G)) ? _forwardInput = -1 : _forwardInput = 0;
				_strafeInput = (Input.GetKey(KeyCode.H)) ? _strafeInput = 1 : (Input.GetKey(KeyCode.F)) ? _strafeInput = -1 : _strafeInput = 0;
				_lookHorizontalInput = (Input.GetKey(KeyCode.RightArrow)) ? _lookHorizontalInput = 1 : (Input.GetKey(KeyCode.LeftArrow)) ? _lookHorizontalInput = -1 : _lookHorizontalInput = 0;
				_lookVerticalInput = (Input.GetKey(KeyCode.UpArrow)) ? _lookVerticalInput = 1 : (Input.GetKey(KeyCode.DownArrow)) ? _lookVerticalInput = -1 : _lookVerticalInput = 0;
			} else if (_cf == ControllerProfile.CUSTOM)
			{
				KeyCode[] customInput = _gameSceneManager.customKey;
				_forwardInput = (Input.GetKey(customInput[1])) ? _forwardInput = 1 : (Input.GetKey(customInput[3])) ? _forwardInput = -1 : _forwardInput = 0;
				_strafeInput = (Input.GetKey(customInput[2])) ? _strafeInput = 1 : (Input.GetKey(customInput[0])) ? _strafeInput = -1 : _strafeInput = 0;
				if (_gameSceneManager.ToggleMouseControl == false)
				{
					_lookHorizontalInput = (Input.GetKey(customInput[6])) ? _lookHorizontalInput = 1 : (Input.GetKey(customInput[4])) ? _lookHorizontalInput = -1 : _lookHorizontalInput = 0;
					_lookVerticalInput = (Input.GetKey(customInput[5])) ? _lookVerticalInput = 1 : (Input.GetKey(customInput[7])) ? _lookVerticalInput = -1 : _lookVerticalInput = 0;
				} else
				{
					_lookHorizontalInput = Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1);
					_lookVerticalInput = Input.GetAxis("Mouse Y");
				}
			}
		}

		/// <summary>
		///	Manages the rotation for the player
		/// </summary>

		private void Look()
		{
			if (_gameSceneManager.onContainer == false)
			{
				_lookHorizontalAcc = Mathf.SmoothDamp(_lookHorizontalAcc, _lookHorizontalInput, ref _lookHorizontalVel, Constants.PlayerRotationHorizontalDelay);
				transform.Rotate(0, _lookHorizontalAcc * CameraLookSpeed, 0);
				_lookInput -= _lookVerticalInput * CameraLookSpeed;
				_lookInput = Mathf.Clamp(_lookInput , -CameraLookAngle, CameraLookAngle);
				_playerHead.transform.localRotation = Quaternion.Lerp(_playerHead.transform.localRotation, Quaternion.Euler(_lookInput, 0, 0), Time.deltaTime * Constants.PlayerRotationVerticalDelay);

			}
		}



		/// <summary>
		///	Bobs the camera
		/// </summary>
		private void HeadBob()
		{
			if (_isMoving)
			{
				_targetHeadBob.x = Mathf.PingPong (bobFrequency * Time.time, bobAmplitude);
				_targetHeadBob.y = Mathf.PingPong (bobFrequency * Time.time, bobAmplitude / 2f);
				_targetHeadBob.x -= bobAmplitude / 2f;
				_targetHeadBob.y -= bobAmplitude / 4f;
				_headBobPos.x = Mathf.Lerp (_headBobPos.x, _targetHeadBob.x, 2.5f * Time.deltaTime);
				_headBobPos.y = Mathf.Lerp (_headBobPos.y, _targetHeadBob.y, 2.5f * Time.deltaTime);
				_headBobPos.z = 0;
				//	Camera.main.transform.position = (_playerHead.transform.position + Vector3.up) + transform.TransformDirection(_headBobPos);
			} else
			{
				_targetHeadBob = Vector3.zero;
			}
			//AdjustBarrels(_headBobPos);
		}


		private void HoverPlayer()
		{
			_targetHover.y = Mathf.PingPong(hoverFrequency * Time.time, hoverAmplitude);
			_targetHover.y -= hoverAmplitude / 2.0f;
			_hoverPos.y = Mathf.Lerp(_hoverPos.y, _targetHover.y, 2.5f * Time.deltaTime);
			Vector3 _offsetPos = (transform.TransformDirection(_hoverPos) + _playerHead.transform.position) - (_playerHead.transform.forward * cameraDistance) - (_playerHead.transform.right * cameraHorizontalOffset) + hoverHeight;
			if (Vector3.Distance(Camera.main.transform.position, _offsetPos) > 0.05f)
			{
				Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _offsetPos, Time.deltaTime * 2.0f);
			} else {
				Camera.main.transform.position =  _offsetPos;
			}
		}

		/// <summary>
		/// Sets recoil to certain amount
		/// </summary>
		public void Recoil()
		{
			_recoil = -1;
		}


		public void MoveCamera()
		{
			if (_gameSceneManager.inventoryManager.quickItemSelectedSlot != null)
			{
				if (_gameSceneManager.inventoryManager.quickItemSelectedSlot.item != null)
				{
					if (_gameSceneManager.inventoryManager.quickItemSelectedSlot.item.itemType == ItemType.Projectile)
					{
						_moveCam = true;
					}
				}
			}
		}
	}
}
