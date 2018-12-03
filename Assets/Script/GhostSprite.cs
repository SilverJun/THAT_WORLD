//	Copyright (c) KimPuppy.
//	http://bakak112.tistory.com/

using UnityEngine;

public class GhostSprite : MonoBehaviour
{
    public bool IsEnable = false;
    public bool IsSolid = false;
    public bool IsShake = false;

    public Color SpriteColor = Color.white;

    public float DrawTime = 0.01f;
    public float ShakeAmount = 0.1f;

    private SpriteRenderer _objSprRender;
    private Material _solidMat;

    private Timer _drawTimer;

    private void Start()
    {
        _objSprRender = GetComponent<SpriteRenderer>();
        _solidMat = Resources.Load<Material>("Material/Sprites-Solid");

        _drawTimer = new Timer(DrawTime, true)
        {
            IsEnable = true
        };
    }

    private void Update()
    {
        if (IsEnable)
        {
            if (_drawTimer.IsDone)
            {
                GameObject sprTemp = new GameObject("@" + gameObject.name + "_GhostSprite", typeof(SpriteRenderer));

                sprTemp.transform.position = transform.position;
                if (IsShake)
                    sprTemp.transform.position += new Vector3(Random.Range(-ShakeAmount, ShakeAmount), Random.Range(-ShakeAmount, ShakeAmount), 0.001f);

                sprTemp.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1.0f);
                sprTemp.transform.localEulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z);
                sprTemp.GetComponent<SpriteRenderer>().sprite = _objSprRender.sprite;
                sprTemp.GetComponent<SpriteRenderer>().color = SpriteColor - new Color(0.0f, 0.0f, 0.0f, 0.8f);

                if (IsSolid)
                    sprTemp.GetComponent<SpriteRenderer>().material = _solidMat;

                Destroy(sprTemp, 0.2f);
            }
        }
    }
}