using UnityEngine;

/// <summary>
/// Следование камеры за Игровым объектом
/// </summary>
public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;


    private void Update()
    {
        MoveCameraToTarget();
    }

    /// <summary>
    /// Изменение положение камеры вслед за игроком
    /// </summary>
    private void MoveCameraToTarget()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}