using UnityEngine;

/// <summary>
/// Object used to create screen shake effects.
/// Made using https://www.youtube.com/watch?v=8PXPyyVu_6I
/// </summary>
public class ScreenShakeController : MonoBehaviour
{
    public static ScreenShakeController instance;

    [Header("Screen Shake Options")]
    [SerializeField] private float rotationMultiplier = 15f;

    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Called every frame, but after Update methods.
    /// </summary>
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

    /// <summary>
    /// Start a screen shake effect.
    /// </summary>
    /// <param name="length">The length of the screen shake effect.</param>
    /// <param name="power">The power of the screen shake effect.</param>
    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power / length;
        shakeRotation = power * rotationMultiplier;
    }
}