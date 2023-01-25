using UnityEngine;

public class InputManager : MonoBehaviour
{
    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectAdditionBlock();
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSubtractionBlock();
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectMultiplicationBlock();
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectDivisionBlock();

        if (Input.mouseScrollDelta.y != 0)
        {
            int mouseScroll = Mathf.RoundToInt(Input.mouseScrollDelta.normalized.y);
            GameDataManager.instance.ChangeSelectedBlockType(cycleAmount: mouseScroll);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) RotateLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonDown(1)) RotateRight();

        if (Input.GetMouseButtonDown(0)) BlockManager.instance.Place(isGhost: false);
    }

    /// <summary>
    /// Select the addition block.
    /// </summary>
    public void SelectAdditionBlock()
    {
        GameDataManager.instance.SetSelectedBlockType(BlockType.ADDITION);
    }

    /// <summary>
    /// Select the subtraction block.
    /// </summary>
    public void SelectSubtractionBlock()
    {
        GameDataManager.instance.SetSelectedBlockType(BlockType.SUBTRACTION);
    }

    /// <summary>
    /// Select the multiplication block.
    /// </summary>
    public void SelectMultiplicationBlock()
    {
        GameDataManager.instance.SetSelectedBlockType(BlockType.MULTIPLICATION);
    }

    /// <summary>
    /// Select the division block.
    /// </summary>
    public void SelectDivisionBlock()
    {
        GameDataManager.instance.SetSelectedBlockType(BlockType.DIVISION);
    }

    /// <summary>
    /// Rotate the block anti clockwise.
    /// </summary>
    public void RotateLeft()
    {
        GameDataManager.instance.ChangeSelectedBlockRotation(rotationChange: -90);
    }

    /// <summary>
    /// Rotate the block clockwise.
    /// </summary>
    public void RotateRight()
    {
        GameDataManager.instance.ChangeSelectedBlockRotation(rotationChange: 90);
    }
}