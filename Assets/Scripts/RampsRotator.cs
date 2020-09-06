using UnityEngine;
using UnityEngine.EventSystems;

public class RampsRotator : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform level;
    [SerializeField] private Transform pivot;
    [SerializeField] private float rotationSensitivity;
    [SerializeField] private Vector2 rotationLimits;

    private BallController ballRigidbody;

    private void Awake()
    {
        ballRigidbody = pivot.gameObject.GetComponent<BallController>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        RotateLevel(eventData.delta);
    }

    private void RotateLevel(Vector2 delta)
    {
        level.RotateAround(pivot.position, Vector3.right, delta.x * rotationSensitivity);
        level.RotateAround(pivot.position, Vector3.forward, delta.y * rotationSensitivity);
        ClampRotation(delta);
    }

    private void ClampRotation(Vector2 delta)
    {
        ClampRotationOnAxis(delta.x, Vector3.right);
        ClampRotationOnAxis(delta.y, Vector3.forward);
    }

    private void ClampRotationOnAxis(float angleDelta, Vector3 axis)
    {
        Vector3 levelUpProjection = level.up;
        levelUpProjection.x *= 1 - Mathf.Abs(axis.x);
        levelUpProjection.y *= 1 - Mathf.Abs(axis.y);
        levelUpProjection.z *= 1 - Mathf.Abs(axis.z);

        float angle = Vector3.Angle(levelUpProjection, Vector3.up);
        if (angle <= rotationLimits.x || angle >= rotationLimits.y)
        {
            level.RotateAround(pivot.transform.position, axis, -angleDelta * rotationSensitivity);
        }
    }
}