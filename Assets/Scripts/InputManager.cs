using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameDataManager.instance.SetSelectedBlockType(BlockType.ADDITION);
            GameDataManager.instance.ResetSelectedBlockRotation();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameDataManager.instance.SetSelectedBlockType(BlockType.SUBTRACTION);
            GameDataManager.instance.ResetSelectedBlockRotation();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameDataManager.instance.SetSelectedBlockType(BlockType.MULTIPLICATION);
            GameDataManager.instance.ResetSelectedBlockRotation();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameDataManager.instance.SetSelectedBlockType(BlockType.DIVISION);
            GameDataManager.instance.ResetSelectedBlockRotation();
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            int mouseScroll = Mathf.RoundToInt(Input.mouseScrollDelta.normalized.y);
            GameDataManager.instance.ChangeSelectedBlockType(cycleAmount: mouseScroll);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameDataManager.instance.ChangeSelectedBlockRotation(rotationChange: -90);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonDown(1))
        {
            GameDataManager.instance.ChangeSelectedBlockRotation(rotationChange: 90);
        }

        if (Input.GetMouseButtonDown(0))
        {
            BlockManager.instance.Place(isGhost: false);
        }
    }
}
