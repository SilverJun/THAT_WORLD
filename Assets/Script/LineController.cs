using UnityEngine;

[ExecuteInEditMode()]
public class LineController : MonoBehaviour
{
    public float Size = 1.0f;
    public int Segments = 3;

    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _lineRenderer.positionCount = Segments + 1;
        for (int i = 0; i < Segments; i++)
        {
            Vector2 dirVec = new Vector2(Mathf.Cos(360.0f / Segments * i * Mathf.Deg2Rad), Mathf.Sin(360.0f / Segments * i * Mathf.Deg2Rad));
            _lineRenderer.SetPosition(i, Vector2.Lerp(_lineRenderer.GetPosition(i), dirVec * Size / 2, 5.0f * Time.deltaTime));
        }
        _lineRenderer.SetPosition(Segments, _lineRenderer.GetPosition(0));
    }
}