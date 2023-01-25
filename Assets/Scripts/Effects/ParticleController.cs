using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [Header("Particle Options")]
    [SerializeField] public float lifetime = 3f;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
