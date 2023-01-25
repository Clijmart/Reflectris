using UnityEngine;

public class GhostBlockWall : MonoBehaviour
{
    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        GetComponentInChildren<MeshRenderer>().material = GetComponentInParent<GhostBlock>().GetMaterial();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    void Update()
    {
        GetComponentInChildren<MeshRenderer>().material = GetComponentInParent<GhostBlock>().GetMaterial();
    }
}