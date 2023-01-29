using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [Header("Life Options")]
    [SerializeField] private Sprite fullLife, emptyLife;

    Image lifeImage;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        lifeImage = GetComponent<Image>();
    }

    /// <summary>
    /// Set the life image depending on the given status.
    /// </summary>
    /// <param name="status">The status of the life to set the image of.</param>
    public void SetLifeImage(LifeStatus status)
    {
        lifeImage.sprite = (status == LifeStatus.Empty) ? emptyLife : fullLife;
    }
}

public enum LifeStatus
{
    Empty = 0,
    Full = 1,
}
