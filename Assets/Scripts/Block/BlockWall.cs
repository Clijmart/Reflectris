using UnityEngine;

public class BlockWall : MonoBehaviour
{
    [Header("Wall Options")]
    [SerializeField] private GameObject reflectParticle;

    /// <summary>
    /// Called when something reflects on the wall, creating an effect and destroying the wall.
    /// </summary>
    public void Reflect()
    {
        Instantiate(reflectParticle, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));

        GetComponentInParent<Block>().RemoveBlockWall(this);

        Destroy(gameObject);
    }
}