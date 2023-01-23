using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Ball Movement")]
    [SerializeField]
    private float initialSpeed = 1f;
    [SerializeField]
    private float speedIncreasePerMinute = 0.5f;
    [SerializeField]
    private Vector3 initialMovement;

    [Header("Effects")]
    [SerializeField]
    private GameObject DamageEffect;
    [SerializeField]
    private GameObject DeathEffect;

    private float speed;
    private Vector3 movement;

    private int SECONDS_PER_MINUTE = 60;
    
    private void Start()
    {
        speed = initialSpeed;
        movement = initialMovement;
    }

    private void Update()
    {
        if (!GameManager.instance.IsRunning())
        {
            return;
        }

        Vector3 normals = movement.normalized;
        speed = BallSpeedFromTime(GameDataManager.instance.GameLength());
        movement = speed * Time.deltaTime * normals;

        transform.Translate(movement);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Border"))
        {
            GameDataManager.instance.ChangeLives(-1);

            if (GameDataManager.instance.Lives() > 0)
            {
                ScreenShakeController.instance.StartShake(length: .5f, power: .2f);

                BlockManager.instance.DestroyAllBlocks();

                Instantiate(DamageEffect, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Destroy(gameObject);

                ScreenShakeController.instance.StartShake(length: 1f, power: .2f);

                Instantiate(DeathEffect, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(-90, 0, 0));
            }
        }
        else if (collider.gameObject.CompareTag("Wall"))
        {
            collider.GetComponent<BlockWall>().Reflect();

            GameDataManager.instance.ChangeScore(1);
            BlockManager.instance.MakeGhostBlockDirty();
        }
        else if (collider.gameObject.CompareTag("Item"))
        {
            collider.GetComponent<Item>().PickUp();
            return;
        }

        Vector3 normal = collider.transform.forward;
        //Debug.Log("normal: " + normal);
        Vector3 reflected = Vector3.Reflect(movement, normal);
        //Debug.Log("reflected: " + reflected);
        movement.x = reflected.x;
        movement.z = reflected.z;

        bool straightWall = Mathf.RoundToInt(collider.transform.rotation.eulerAngles.y) % 90 == 0;
        if (!straightWall)
        {
            //Debug.Log("Not straight wall! " + collider.transform.rotation.eulerAngles.y);
            transform.position = collider.transform.position;
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

    private float BallSpeedFromTime(float gameLength)
    {
        return Mathf.Floor(Mathf.Max(gameLength, 1) / SECONDS_PER_MINUTE * speedIncreasePerMinute * 10f) / 10f + initialSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
