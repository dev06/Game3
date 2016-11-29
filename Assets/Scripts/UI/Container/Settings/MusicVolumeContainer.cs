using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MusicVolumeContainer : MonoBehaviour {

	private Slider _slider;

	void OnEnable()
	{
		EventManager.OnSave += OnSave;
	}
	void OnDisAble()
	{
		EventManager.OnSave -= OnSave;
	}


	void Start ()
	{
		_slider = transform.FindChild("VolumeSlider").GetComponent<Slider>();

		//_slider.value = Constants.musicVolume;


	}



	void Update ()
	{
		//	_slider.value = Constants.musicVolume;
		Constants.musicVolume = _slider.value;
		Debug.Log(Constants.musicVolume);
	}

	public void OnValueChange()
	{

		if (AudioManager.Instance.Sources != null)
		{
			AudioManager.Instance.Sources[0].volume = _slider.value;
		}

	}

	private void OnSave()
	{
		Constants.musicVolume = _slider.value;
	}
}
