using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWall : MonoBehaviour
{
    [SerializeField]
    private GameObject reflectParticle;

    public void Reflect()
    {
        Instantiate(reflectParticle, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));

        GetComponentInParent<Block>().RemoveBlockWall(this);

        Destroy(gameObject);
    }
}
