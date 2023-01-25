using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [Header("Player")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 spawnPosition;

    private GameObject player;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Spawn the player ball.
    /// </summary>
    public void SpawnPlayerBall()
    {
        player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }

    /// <summary>
    /// Get the player object.
    /// </summary>
    /// <returns>The player object.</returns>
    public GameObject GetPlayer()
    {
        return player;
    }
}