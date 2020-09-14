using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private Transform ballLandingPoint;
    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void MoveToLandingPoint()
    {
        // Перемещение мячика к точке призмеления
        StartCoroutine(MoveToPoint(rigidbody.velocity));
    }

    private IEnumerator MoveToPoint(Vector3 velocity)
    {
        float speed = velocity.magnitude;
        while (transform.position.y >= ballLandingPoint.position.y)
        {
            // Двигаем мячик к точке приземления
            transform.position = Vector3.MoveTowards(transform.position, ballLandingPoint.position, speed * 0.25f * Time.deltaTime);
            yield return null;
        }

        StopCoroutine("MoveToPoint");
    }
}
