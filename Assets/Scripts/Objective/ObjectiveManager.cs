using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager instance;

    public static List<Objective> availableObjectives = new();

    private Objective currentObjective;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        NewObjective();
    }

    public Objective NewObjective()
    {
        IBlockType blockType = IBlockType.RandomBlockType();

        currentObjective = new Objective(blockType, 2);

        return currentObjective;
    }

    public bool FitsObjective(BlockType blockType)
    {
        return IBlockType.GetFromType(blockType).ApplyOperator(currentObjective.terms) == currentObjective.solution;
    }

    public Objective CurrentObjective()
    {
        return currentObjective;
    }
}
