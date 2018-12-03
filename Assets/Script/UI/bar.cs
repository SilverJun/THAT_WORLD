using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.UI;

public class bar : MonoBehaviour {
	public Image _img;

	void Start () {
		Sequence sequence = DOTween.Sequence();
		sequence.AppendInterval(1.0f);
		sequence.Append(_img.rectTransform.DOScaleX(3.568479f, 1.0f));

        sequence.Play();
	}
}
