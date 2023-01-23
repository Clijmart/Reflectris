using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    private Vector3 initialPosition;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        initialPosition = transform.position;

        int2 gridSize = GridController.instance.GetGridSize();
        int largestSide = Mathf.Max(gridSize.x, gridSize.y);
        float ortho = 0.5f * largestSide + 1.5f;

        Camera.main.orthographicSize = ortho;
    }

    private void Update()
    {
        transform.position = initialPosition;
    }
}
