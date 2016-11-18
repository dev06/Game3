using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthIndiciator : MonoBehaviour {


	private Image _fillImage;
	private Text _text;
	private Mob _target;

	void Start ()
	{
		_fillImage = transform.FindChild("FillImage").GetComponent<Image>();
		_text = transform.FindChild("Text").GetComponent<Text>();
		if (transform.parent.GetComponent<Mob>() != null)
		{
			_target = transform.parent.GetComponent<Mob>();
		} else
		{
			Debug.Log("Can't attach health indicator to non-mob object");
		}
	}

	void Update ()
	{
		UpdateComponents();
	}

	private void UpdateComponents()
	{
		_fillImage.fillAmount = _target.GetHealth / _target.GetMaxHealth;
		_text.text = "" + (int)(_fillImage.fillAmount * _target.GetMaxHealth);
		transform.LookAt(Camera.main.transform.position);
	}
}
