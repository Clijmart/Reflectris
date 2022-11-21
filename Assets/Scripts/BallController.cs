using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.01f;

    private Vector3 movement;
    private Collider[] colliders;

    private void Start()
    {
        movement = new Vector3(speed, 0, 0);
    }

    private void Update()
    {
        transform.Translate(movement);

        colliders = Physics.OverlapSphere(transform.position, 0.0f);
        if (colliders.Length > 0)
        {
            Collider collider = colliders[0];
            Debug.Log("Inside " + collider.name);

            Vector3 normal = collider.transform.forward;
            Debug.Log("normal: " + normal);
            Vector3 reflected = Vector3.Reflect(movement, normal);
            Debug.Log("reflected: " + reflected);
            movement.x = reflected.x;
            movement.z = reflected.z;

            bool straightWall = Mathf.RoundToInt(collider.transform.rotation.eulerAngles.y) % 90 == 0;
            if (!straightWall)
            {
                Debug.Log("Not straight wall! " + collider.transform.rotation.eulerAngles.y);
                transform.position = collider.transform.position;
            }

            if (!collider.gameObject.CompareTag("Border"))
            {
                Destroy(collider.gameObject);
            }
        }

        RoundPosition();
    }

    private void RoundPosition()
    {
        Vector3 rawPosition = transform.position;

        rawPosition.x = Mathf.Round(rawPosition.x * 1000f) / 1000f;
        rawPosition.z = Mathf.Round(rawPosition.z * 1000f) / 1000f;

        transform.position = rawPosition;
    }
}
