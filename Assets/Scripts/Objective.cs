using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective
{
    private BlockType operatorBlock;
    private string equation;

    public Objective(BlockType operatorBlock, string equation)
    {
        this.operatorBlock = operatorBlock;
        this.equation = equation;
    }

    public BlockType GetOperatorBlock()
    {
        return operatorBlock;
    }

    public string GetEquation()
    {
        return equation;
    }
}
