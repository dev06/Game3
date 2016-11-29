using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SFXVolumeContainer : MonoBehaviour {

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

		//	_slider.value = Constants.sfxVolume;
	}



	void Update ()
	{

	}

	public void OnValueChange()
	{
		if (AudioManager.Instance.Sources != null)
		{
			AudioManager.Instance.Sources[1].volume = _slider.value;
		}
	}

	private void OnSave()
	{
		Constants.sfxVolume = _slider.value;
	}
}
