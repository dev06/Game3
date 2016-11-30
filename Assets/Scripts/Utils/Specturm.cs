using UnityEngine;
using System.Collections;

public class Specturm : MonoBehaviour {

	private float[] spectrum = new float[128];
	private GameObject _obstacles;
	private float _vel;
	void Start ()
	{
		_obstacles = GameObject.Find("Obstacles");
	}

	// Update is called once per frame
	void Update () {
		AudioListener.GetSpectrumData( spectrum, 0, FFTWindow.Rectangular );
		for (int i = 0; i < _obstacles.transform.childCount; i++)
		{
			Transform _transform = _obstacles.transform.GetChild(i);
			float scaleY = _transform.localScale.y;
			scaleY = Mathf.SmoothDamp(_transform.localScale.y, (spectrum[i] * 300.0f) + 10, ref _vel, .3f);
			_transform.localScale = new Vector3(_transform.localScale.x, scaleY, _transform.localScale.z);
		}
	}
}
