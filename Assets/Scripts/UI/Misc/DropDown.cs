using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DropDown : MonoBehaviour {

	public GameObject parent;
	private float _rotationZ;
	void Start ()
	{

	}

	void Update ()
	{
		if (parent.activeSelf)
		{
			_rotationZ = -180;
		} else {
			_rotationZ = 0;
		}

		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, _rotationZ)), Time.deltaTime * 10f);
	}


	void SetActive()
	{

	}
}
