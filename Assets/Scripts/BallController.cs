﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private Transform ballLandingPoint;
    [SerializeField] private float force;
    private new Rigidbody rigidbody;
    private bool isStartPositionSelected;

    private Vector3 startVelocity;
    private Vector3 endVelocity;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void MoveToLandingPoint()
    {
        // Перемещение мячика к точке призмеления
        Vector3 velocity = rigidbody.velocity;
        rigidbody.isKinematic = true;
        StartCoroutine(MoveToPoint(velocity));
    }

    private IEnumerator MoveToPoint(Vector3 velocity)
    {
        float speed = velocity.magnitude;
        while (Vector3.Distance(transform.position, ballLandingPoint.position) >= 0.25f)
        {
            // Двигаем мячик к точке приземления
            transform.position = Vector3.MoveTowards(transform.position, ballLandingPoint.position, speed * Time.deltaTime);
            yield return null;
        }

        rigidbody.isKinematic = false;
        rigidbody.velocity = velocity;
        StopCoroutine("MoveToPoint");
    }

    public void AddForceToBall()
    {
        StartCoroutine(CalulateMotionVector());
    }

    private void AddForceInDirection(Vector3 direction)
    {
        rigidbody?.AddForce(direction * force, ForceMode.VelocityChange);
    }

    private IEnumerator CalulateMotionVector()
    {
        if(!isStartPositionSelected)
        {
            startVelocity = rigidbody.velocity;
            isStartPositionSelected = true;
            yield return new WaitForSeconds(1.0f);
        }
        else
        {
            endVelocity = rigidbody.velocity;
            Vector3 direction = (endVelocity - startVelocity).normalized;
            AddForceInDirection(direction);
            isStartPositionSelected = false;
            StopCoroutine(CalulateMotionVector());
        }
    }
}
