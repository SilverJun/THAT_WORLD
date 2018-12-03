using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpObject : MonoBehaviour
{
    public Vector3 Size = Vector3.one;

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Size, 5.0f * Time.deltaTime);
    }
}