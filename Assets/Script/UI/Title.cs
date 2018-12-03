using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Title : MonoBehaviour {
	public Text _text;
 
	void Start () {
		Sequence sequence = DOTween.Sequence();

		sequence.Append(_text.DOColor(new Color(1.0f, 1.0f, 1.0f, 1.0f), 1.5f));
		sequence.Join(transform.DOMoveY(2.5f, 1.5f));

		sequence.Play();
	}
}
