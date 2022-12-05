using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField]
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
