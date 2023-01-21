using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
    // Done using tutorial: https://www.youtube.com/watch?v=8PXPyyVu_6I

    public static ScreenShakeController instance;

    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;

    [SerializeField]
    private float rotationMultiplier = 15f;

    private void Awake()
    {
        instance = this;
    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float zAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, 0f, zAmount);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, shakeRotation * Random.Range(-1f, 1f), transform.rotation.eulerAngles.z);
    }

    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power / length;

        shakeRotation = power * rotationMultiplier;
    }
}
