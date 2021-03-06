﻿//Devan Patel
//Applications and Scripting
//Sep.12.2016
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	#region ------ PUBLIC MEMBERS ----
	public Sprite HoverSprite;
	public Sprite RestSprite;
	public Color HoverColor;
	public Color RestColor;
	public Color DisabledColor;
	public bool  isInteractable;
	public float HoverSize;
	public float RestSize;
	public ButtonID buttonID;
	#endregion ------ /PUBLIC MEMBERS ----

	#region ------ PRIVATE MEMBERS ----
	protected Image _image;
	private RectTransform _rectTransform;
	protected GameController _gameController;
	protected bool hovering;
	#endregion ------ /PRIVATE MEMBERS ----
	void Start ()
	{
		Init();
	}

	/// <summary>
	/// Init all the component
	/// </summary>
	protected void Init()
	{
		_image = (GetComponent<Image>() != null) ? GetComponent<Image>() : null;
		_rectTransform = (GetComponent<RectTransform>() != null) ? GetComponent<RectTransform>() : null;
		_gameController = GameController.Instance;

		if (_image != null)
		{
			_image.color = RestColor;
		}
	}



	void Update () {

	}

	protected void OnEnter()
	{
		hovering = true;
		if (_image != null)
		{
			_image.color = HoverColor;
			_image.sprite = HoverSprite;
		}

		if (_rectTransform != null)
		{
			_rectTransform.localScale = new Vector3(HoverSize, HoverSize, 1);
		}

	}

	protected void OnExit()
	{
		hovering = false;
		if (_image != null)
		{
			_image.color = RestColor;
			_image.sprite = RestSprite;
		}

		if (_rectTransform != null)
		{
			_rectTransform.localScale = new Vector3(RestSize, RestSize, 1);
		}

		GameController.selectedButtonID = ButtonID.NONE;

	}

	/// <summary>
	/// Triggered on OnPointerEnter
	/// </summary>
	/// <param name="data"></param>
	public virtual void OnPointerEnter(PointerEventData data)
	{
		OnEnter();
	}
	/// <summary>
	/// Triggered when OnPointer Exit
	/// </summary>
	/// <param name="data"></param>
	public virtual void OnPointerExit(PointerEventData data)
	{
		OnExit();
	}
	/// <summary>
	/// Triggered on OnClick
	/// </summary>
	/// <param name="data"></param>
	public virtual void OnPointerClick(PointerEventData data)
	{

	}



	public void SetActive(GameObject _container, bool value)
	{
		_container.gameObject.SetActive(value);
		if (value)
		{
			OnEnter();
		} else {
			OnExit();
		}
	}

	public void SetInteractable(bool b)
	{

		if (_image != null)
		{

			if (!b)
			{
				_image.color = DisabledColor ;

			}

			_image.sprite = RestSprite;

		}


		isInteractable = b;

	}


}
