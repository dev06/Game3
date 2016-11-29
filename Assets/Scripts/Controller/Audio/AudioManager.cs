using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour {


	public static AudioManager Instance;

	private AudioSource[] sources;

	public Slider musicSlider;
	public Slider sfxSlider;

	public AudioSource music_one;
	public AudioSource shoot;


	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		} else {
			Instance = this;
		}

	}

	void OnEnable()
	{
		EventManager.OnShoot += OnShoot;
	}

	void OnDisable()
	{
		EventManager.OnShoot -= OnShoot;
	}

	void Start ()
	{

		sources = GetComponents<AudioSource>();
		musicSlider = GameObject.FindWithTag("Settings/MusicVolume").transform.FindChild("VolumeSlider").GetComponent<Slider>();
		sfxSlider = GameObject.FindWithTag("Settings/SFXVolume").transform.FindChild("VolumeSlider").GetComponent<Slider>();

		music_one = sources[0];
		shoot = sources[1];



		music_one.volume = musicSlider.value;
		shoot.volume = sfxSlider.value;
	}

	void Update ()
	{

	}


	//Event Triggers

	private void OnShoot()
	{
		if (sources != null)
		{
			sources[1].Play();
		}
	}


	public AudioSource[] Sources { get {return sources; }}
}
