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
        // TODO: Add to JSON file
        availableObjectives.Add(new Objective(BlockType.MULTIPLY, "6 ... 5 = 30"));
        availableObjectives.Add(new Objective(BlockType.PLUS, "6 ... 5 = 11"));

        NewObjective();
    }

    public Objective NewObjective()
    {
        currentObjective = availableObjectives[Random.Range(0, availableObjectives.Count)];
        return currentObjective;
    }

    public bool FitsObjective(BlockType blockType)
    {
        return blockType == currentObjective.GetOperatorBlock();
    }

    public Objective CurrentObjective()
    {
        return currentObjective;
    }
}
