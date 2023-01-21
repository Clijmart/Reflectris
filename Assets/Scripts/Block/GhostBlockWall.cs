using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlockWall : MonoBehaviour
{
    void Start()
    {
        GetComponentInChildren<MeshRenderer>().material = GetComponentInParent<GhostBlock>().GetMaterial();
    }

    void Update()
    {
        GetComponentInChildren<MeshRenderer>().material = GetComponentInParent<GhostBlock>().GetMaterial();
    }
}
