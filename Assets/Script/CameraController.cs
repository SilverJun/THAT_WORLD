//	Copyright (c) KimPuppy.
//	http://bakak112.tistory.com/

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target = null;
    public float Speed = 5.0f;
    public Vector3 Offset = Vector3.zero;

    private Vector3 _anchorPoint = Vector3.zero;
    private float _shakePower = 0.0f;
    private float _shakeAmount = 7.5f;

    private void LateUpdate()
    {
        if (Target != null)
        {
            _anchorPoint = Vector3.Lerp(_anchorPoint, Target.position, Speed * Time.deltaTime);
        }
        _shakePower -= _shakePower / _shakeAmount;
        transform.position = _anchorPoint + Offset + new Vector3(Random.Range(-_shakePower, _shakePower), Random.Range(-_shakePower, _shakePower), -0.0f);
    }

    public void Shake(float shakePower, float shakeAmount)
    {
        _shakePower = shakePower;
        _shakeAmount = shakeAmount;
    }
}