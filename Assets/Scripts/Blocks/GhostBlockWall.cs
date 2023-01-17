using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlockWall : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().material = GetComponentInParent<GhostBlock>().GetMaterial();
    }

    void Update()
    {
        GetComponent<MeshRenderer>().material = GetComponentInParent<GhostBlock>().GetMaterial();
    }
}
