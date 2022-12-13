using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float initialSpeed = 1f;

    [SerializeField]
    private Vector3 initialMovement;

    [SerializeField]
    private GameObject BoomParticle;

    [SerializeField]
    private GameObject ReflectParticle;

    private float speed;
    private Vector3 movement;
    
    private void Start()
    {
        speed = initialSpeed;
        movement = initialMovement;
    }

    private void Update()
    {
        Vector3 normals = movement.normalized;
        movement = normals * speed * Time.deltaTime;

        transform.Translate(movement);
    }

    private void OnTriggerEnter(Collider collider)
    {
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

        if (collider.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);

            Instantiate(BoomParticle, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(-90, 0, 0));
        }
        else
        {
            Destroy(collider.gameObject);

            Instantiate(ReflectParticle, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
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
