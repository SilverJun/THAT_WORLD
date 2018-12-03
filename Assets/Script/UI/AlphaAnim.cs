using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class AlphaAnim : MonoBehaviour {

	public SpriteRenderer sprite;

	void Start () {
		Sequence seq = DOTween.Sequence();

		seq.Append(sprite.DOFade(20.0f / 255.0f, 1.0f));
		seq.Append(sprite.DOFade(80.0f / 255.0f, 1.0f));
		seq.SetLoops(-1);
		seq.Play();
	}
}
