using UnityEngine;
using DG.Tweening;

public class BeatObject : MonoBehaviour
{
    private BeatController _beatController;

    private int _beatCount = 0;

    private void Start()
    {
        InvokeRepeating("MakeBeat", 60.0f / 160.0f * 32.0f, 60.0f / 160.0f * 32.0f);
    }

    private void MakeBeat()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DORotate(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 120), 0.5f));
        seq.Play();
    }
}