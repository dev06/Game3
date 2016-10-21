using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ResolutionButton : ButtonEventHandler {

	private Transform _moreResolution;
	private GameObject _dropDownIcon;
	private Vector3 _dropDownIcon_Rotation;
	void Start () {
		Init();
		_moreResolution = transform.parent.transform.FindChild("MoreResolution");
		if (buttonID == ButtonID.RESOLUTION_BUTTON)
		{
			_dropDownIcon = transform.FindChild("dropDownIcon").gameObject;
			_dropDownIcon_Rotation = Vector3.zero;

		}

	}

	// Update is called once per frame
	void Update ()
	{
		if (buttonID == ButtonID.RESOLUTION_BUTTON)
		{
			_dropDownIcon.transform.rotation = Quaternion.Lerp(_dropDownIcon.transform.rotation, Quaternion.Euler(_dropDownIcon_Rotation), Time.deltaTime * 10.0f);
		}
	}

	/// <summary>
	/// Overrides the on pointer enter from base class.
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerEnter(PointerEventData data)
	{

		base.OnPointerEnter(data);



	}
	/// <summary>
	/// Overrides the on pointer exit from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerExit(PointerEventData data)
	{
		base.OnPointerExit(data);






	}

	/// <summary>
	/// Overrides the on pointer click from base class
	/// </summary>
	/// <param name="data"></param>
	public override void OnPointerClick(PointerEventData data)
	{

		base.OnPointerClick(data);

		if (buttonID == ButtonID.RESOLUTION_BUTTON)
		{
			_moreResolution.gameObject.SetActive(!_moreResolution.gameObject.activeSelf);
			if (_moreResolution.gameObject.activeSelf)
			{
				_dropDownIcon_Rotation = new Vector3(0, 0, -180);
			} else {
				_dropDownIcon_Rotation = new Vector3(0, 0, 0);
			}
		}
	}


	public void SetActive(bool b)
	{
		gameObject.SetActive(b);
	}



}
