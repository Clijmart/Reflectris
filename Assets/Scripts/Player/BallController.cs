using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Ball Movement")]
    [SerializeField] private float initialSpeed = 1f;
    [SerializeField] private float speedIncreasePerMinute = 0.5f;
    [SerializeField] private Vector3 initialMovement;

    [Header("Effects")]
    [SerializeField] private GameObject DamageEffect;
    [SerializeField] private GameObject DeathEffect;

    private static int SECONDS_PER_MINUTE = 60;

    private float speed;
    private Vector3 movement;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        speed = initialSpeed;
        movement = initialMovement;
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        if (!GameManager.instance.IsRunning())
        {
            return;
        }

        MoveBall();
    }

    /// <summary>
    /// Move the ball.
    /// </summary>
    private void MoveBall()
    {
        Vector3 normals = movement.normalized;
        speed = BallSpeedFromTime(gameLength: GameDataManager.instance.GameLength());
        movement = speed * Time.deltaTime * normals;

        transform.Translate(movement);
    }

    /// <summary>
    /// Called when the ball collides with another object.
    /// </summary>
    /// <param name="collider">The object the ball collided with.</param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Border")) CollideWithBorder();
        else if (collider.gameObject.CompareTag("Wall")) CollideWithWall(collider);
        else if (collider.gameObject.CompareTag("Item"))
        {
            CollideWithItem(collider);
            return;
        }
        else return;

        Reflect(collider);
        RoundPosition();
    }

    /// <summary>
    /// Reflect the ball on a collider.
    /// </summary>
    /// <param name="collider">The collider to reflect on.</param>
    private void Reflect(Collider collider)
    {
        Vector3 normal = collider.transform.forward;
        Vector3 reflected = Vector3.Reflect(inDirection: movement, inNormal: normal);
        movement.x = reflected.x;
        movement.z = reflected.z;

        // Teleport the ball to the center of the tile
        bool straightWall = Mathf.RoundToInt(collider.transform.rotation.eulerAngles.y) % 90 == 0;
        if (!straightWall) transform.position = collider.transform.position;
    }

    /// <summary>
    /// Deals with border collisions.
    /// </summary>
    private void CollideWithBorder()
    {
        GameDataManager.instance.ChangeLives(amount: -1);

        if (GameDataManager.instance.Lives() > 0)
        {
            ScreenShakeController.instance.StartShake(length: .5f, power: .2f);
            BlockManager.instance.DestroyAllBlocks();
            Instantiate(DamageEffect, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
            return;
        }

        Destroy(gameObject);
        ScreenShakeController.instance.StartShake(length: 1f, power: .2f);
        Instantiate(DeathEffect, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(-90, 0, 0));
    }

    /// <summary>
    /// Deals with wall collisions.
    /// </summary>
    /// <param name="wallCollider">The wall collider the ball collided with.</param>
    private void CollideWithWall(Collider wallCollider)
    {
        wallCollider.GetComponent<BlockWall>().Reflect();
        GameDataManager.instance.ChangeScore(amount: 1);
        BlockManager.instance.MakeGhostBlockDirty();
    }

    /// <summary>
    /// Deals with item collisions.
    /// </summary>
    /// <param name="itemCollider">The item collider the ball collided with.</param>
    private void CollideWithItem(Collider itemCollider)
    {
        itemCollider.GetComponent<Item>().PickUp();
    }

    /// <summary>
    /// Round the ball position to make sure it rolls straight.
    /// </summary>
    private void RoundPosition()
    {
        Vector3 rawPosition = transform.position;

        rawPosition.x = Mathf.Round(rawPosition.x * 1000f) / 1000f;
        rawPosition.z = Mathf.Round(rawPosition.z * 1000f) / 1000f;

        transform.position = rawPosition;
    }

    /// <summary>
    /// Calculate the ball speed using the time the game has been going for.
    /// </summary>
    /// <param name="gameLength">The length of the game.</param>
    /// <returns>The recalculated ball speed.</returns>
    private float BallSpeedFromTime(float gameLength)
    {
        float gameLengthInMinutes = Mathf.Max(gameLength, 1) / SECONDS_PER_MINUTE;
        float speedIncrease = gameLengthInMinutes * speedIncreasePerMinute;
        float flooredSpeedIncrease = Mathf.Floor(speedIncrease * 10f) / 10f;

        return flooredSpeedIncrease + initialSpeed;
    }

    /// <summary>
    /// Get the current ball speed.
    /// </summary>
    /// <returns>The ball speed.</returns>
    public float GetSpeed()
    {
        return speed;
    }
}