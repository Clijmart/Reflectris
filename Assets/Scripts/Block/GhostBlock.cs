using UnityEngine;

public class GhostBlock : MonoBehaviour
{
    [Header("Ghost Block Options")]
    [SerializeField] private Material blockMaterial;
    [SerializeField] private Material blockCollidingMaterial;

    private bool colliding;

    /// <summary>
    /// Get the material of the ghost block.
    /// </summary>
    /// <returns>The material of the ghost block.</returns>
    public Material GetMaterial()
    {
        if (colliding) return blockCollidingMaterial;
        return blockMaterial;
    }

    /// <summary>
    /// Set whether or not the ghost block is colliding with another object.
    /// </summary>
    /// <param name="colliding">Whether or not the ghost block is colliding.</param>
    public void Colliding(bool colliding)
    {
        this.colliding = colliding;
    }

    /// <summary>
    /// Check if the ghost block is colliding with another object.
    /// </summary>
    /// <returns>Whether or not the ghost block is colliding.</returns>
    public bool Colliding()
    {
        return colliding;
    }
}