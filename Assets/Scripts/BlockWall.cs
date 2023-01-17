using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWall : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().material = GetComponentInParent<Block>().GetMaterial();
    }

    void Update()
    {
        GetComponent<MeshRenderer>().material = GetComponentInParent<Block>().GetMaterial();
    }
}
