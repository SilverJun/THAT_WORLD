using UnityEngine;

public class BeatController : MonoBehaviour
{
    public float BPM = 0.0f;
    public bool IsBeat = false;

    private void Start()
    {
        AudioSource bgmPlayer = GetComponent<AudioSource>();

        bgmPlayer.Play();

        InvokeRepeating("MakeBeat", 0.0f, 60.0f / BPM);
    }

    private void Update()
    {
        IsBeat = false;
    }

    private void MakeBeat()
    {
        IsBeat = true;
    }
}