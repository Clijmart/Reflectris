using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectAdditionBlock();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSubtractionBlock();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectMultiplicationBlock();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectDivisionBlock();
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

    public void SelectAdditionBlock()
    {
        GameDataManager.instance.SetSelectedBlockType(BlockType.ADDITION);
    }

    public void SelectSubtractionBlock()
    {
        GameDataManager.instance.SetSelectedBlockType(BlockType.SUBTRACTION);
    }

    public void SelectMultiplicationBlock()
    {
        GameDataManager.instance.SetSelectedBlockType(BlockType.MULTIPLICATION);
    }

    public void SelectDivisionBlock()
    {
        GameDataManager.instance.SetSelectedBlockType(BlockType.DIVISION);
    }
}
