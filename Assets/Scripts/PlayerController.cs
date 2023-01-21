using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) GameDataManager.instance.SetSelectedBlockType(BlockType.MULTIPLY);
        if (Input.GetKeyDown(KeyCode.P)) GameDataManager.instance.SetSelectedBlockType(BlockType.PLUS);
    }
}
