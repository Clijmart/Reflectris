using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private Material blockMaterial;

    [SerializeField]
    private Material blockCollidingMaterial;

    private bool colliding;

    public Material GetMaterial()
    {
        if (colliding) return blockCollidingMaterial;
        return blockMaterial;
    }

    public void Colliding(bool colliding)
    {
        if (colliding)
        {
            Debug.Log("Colliding");
        }
        this.colliding = colliding;
    }

    public bool Colliding()
    {
        return colliding;
    }
}
