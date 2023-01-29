using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance;

    [Header("Life")]
    [SerializeField] private GameObject lifePrefab;

    List<LifeController> lives = new();

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Draw the lives on the screen.
    /// </summary>
    public void DrawLives()
    {
        ClearLives();

        for (int i = 0; i < GameDataManager.instance.MaxLives(); i++)
        {
            CreateLife(i < GameDataManager.instance.Lives() ? LifeStatus.Full : LifeStatus.Empty);
        }
    }

    /// <summary>
    /// Create a new life object.
    /// </summary>
    /// <param name="status">The status of the life to create.</param>
    public void CreateLife(LifeStatus status)
    {
        GameObject newLife = Instantiate(lifePrefab);
        newLife.transform.SetParent(transform);

        LifeController lifeComponent = newLife.GetComponent<LifeController>();
        lifeComponent.SetLifeImage(status);
        lives.Add(lifeComponent);
    }

    /// <summary>
    /// Clear the currently drawn lives.
    /// </summary>
    public void ClearLives()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        lives = new();
    }
}
