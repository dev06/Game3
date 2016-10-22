using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BorderlessWindowButton : ButtonEventHandler {

	public bool isBorderLess;
	private GameObject _checkMark;
	void Start () {
		Init();
		_checkMark = transform.FindChild("checkmark").gameObject;
		isBorderLess = false;
		_checkMark.SetActive(isBorderLess);
	}

	// Update is called once per frame
	void Update () {

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
		isBorderLess = !isBorderLess;
		_checkMark.SetActive(isBorderLess);
#if !UNITY_EDITOR
		if (isBorderLess)
		{
			GameController.Instance.gameObject.GetComponent<WindowHandler>().SetBorderlessWindow();
		} else {
			// int width = (int)1920;
			// int height = (int)1080;
			// GameController.Instance.WindowResolution.x = width;
			// GameController.Instance.WindowResolution.y = height;

			Screen.SetResolution((int)1920, (int)1080, false);
		}

#endif



	}
}
