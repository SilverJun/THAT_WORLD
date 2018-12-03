using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using DG.Tweening;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text _text;

	void Start ()
	{
		_text.text = PlayerPrefs.GetInt("Score").ToString();

		Sequence sequence = DOTween.Sequence();
        
		sequence.AppendInterval(1.0f);
        sequence.Append(_text.DOColor(new Color(1.0f, 1.0f, 1.0f, 1.0f), 0.5f));

        sequence.Play();
	}

    public void callBack()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
