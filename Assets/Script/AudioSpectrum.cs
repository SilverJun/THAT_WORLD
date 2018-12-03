using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    private AudioSource _audioSource;

    public float[] _samples = new float[64];

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        AudioListener.GetSpectrumData(_samples, 0, FFTWindow.Rectangular);
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.one / 2.0f + new Vector2(_samples[0], _samples[0]), 5.0f * Time.deltaTime);
    }
}