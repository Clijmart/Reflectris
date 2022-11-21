using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Rigidbody body;

    void Start()
    {
        body.velocity = new Vector3(speed, 0, 0);
    }

    private void Update()
    {
        Debug.Log($"Ball speed: {body.velocity.magnitude}");
    }
}
