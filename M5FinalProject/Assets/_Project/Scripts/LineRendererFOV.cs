using System.Collections;
using UnityEngine;

public class LineRendererFOV : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _subdivisions = 12;
    [SerializeField] private float _interval = 0.5f;
    [SerializeField] private LayerMask _layerMask;

    private LineRenderer _lineRenderer;
    private TargetDetection _playerDetection;

    private void Awake()
    {
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        _playerDetection = GetComponent<TargetDetection>();
    }

    private void Start()
    {
        StartCoroutine(CustomUpdate());
    }

    private IEnumerator CustomUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);
            EvaluateConeOfViewWithQuaternion(_subdivisions);
        }
    }

    private void EvaluateConeOfViewWithQuaternion(int subdivions)
    {
        _lineRenderer.positionCount = subdivions + 1;

        Vector3 lineOrigin = Vector3.zero;
        _lineRenderer.SetPosition(0, lineOrigin);

        float startAngle = - _playerDetection.ViewAngle;
        float deltaAngle = (2 * _playerDetection.ViewAngle / subdivions);

        Vector3 worldOrigin = _playerDetection.transform.position;
        Vector3 forward = _playerDetection.transform.forward;

        for (int i = 0; i < subdivions; i++)
        {
            float currentAngle = startAngle + deltaAngle * i;
            Vector3 direction = Quaternion.AngleAxis(currentAngle, _playerDetection.transform.up) * forward;

            Vector3 worldEndPoint;

            if (Physics.Raycast(worldOrigin, direction, out RaycastHit hit, _playerDetection.SightDistance, _layerMask))
            {
                worldEndPoint = hit.point;
            }
            else
            {
                worldEndPoint = worldOrigin + direction * _playerDetection.SightDistance;
            }

            Vector3 localPoint = _playerDetection.transform.InverseTransformPoint(worldEndPoint);

            _lineRenderer.SetPosition(i + 1, localPoint);
        }
    }
}
