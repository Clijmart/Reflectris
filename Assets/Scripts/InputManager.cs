using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) GameDataManager.instance.SetSelectedBlockType(BlockType.ADDITION);
        if (Input.GetKeyDown(KeyCode.Alpha2)) GameDataManager.instance.SetSelectedBlockType(BlockType.SUBTRACTION);
        if (Input.GetKeyDown(KeyCode.Alpha3)) GameDataManager.instance.SetSelectedBlockType(BlockType.MULTIPLICATION);
        if (Input.GetKeyDown(KeyCode.Alpha4)) GameDataManager.instance.SetSelectedBlockType(BlockType.DIVISION);

        if (Input.GetMouseButtonDown(0)) BlockManager.instance.Place(isGhost: false);

        if (Input.mouseScrollDelta.y != 0)
        {
            int mouseScroll = Mathf.RoundToInt(Input.mouseScrollDelta.normalized.y);
            BlockType nextBlockType = IBlockType.RelaviteBlockType(GameDataManager.instance.GetSelectedBlockType(), mouseScroll);
            GameDataManager.instance.SetSelectedBlockType(nextBlockType);

            Debug.Log("Current mouse scroll:" + Input.mouseScrollDelta);
        }
    }
}
