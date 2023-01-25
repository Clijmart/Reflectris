using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    private Vector3 initialPosition;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        initialPosition = transform.position;

        // Move camera so the entire grid fits in the view.
        Vector2Int gridSize = GridController.instance.GetGridSize();
        int largestSide = Mathf.Max(gridSize.x, gridSize.y);
        float ortho = 0.5f * largestSide + 1.5f;

        Camera.main.orthographicSize = ortho;
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        transform.position = initialPosition;
    }
}