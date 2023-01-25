using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager instance;

    private Objective currentObjective;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        NewObjective();
    }

    /// <summary>
    /// Generate a new objective with a random block type.
    /// </summary>
    /// <returns>The new objective.</returns>
    public Objective NewObjective()
    {
        IBlockType blockType = IBlockType.RandomBlockType();

        currentObjective = new Objective(operatorBlock: blockType, termAmount: 2);

        return currentObjective;
    }

    /// <summary>
    /// Check if given block type fits the objective by applying the operator.
    /// </summary>
    /// <param name="blockType">The block type to check.</param>
    /// <returns>Whether or not the block type fits the objective.</returns>
    public bool FitsObjective(BlockType blockType)
    {
        return IBlockType.GetFromType(blockType).ApplyOperator(terms: currentObjective.terms) == currentObjective.solution;
    }

    /// <summary>
    /// Get the current objective.
    /// </summary>
    /// <returns>The current objective.</returns>
    public Objective CurrentObjective()
    {
        return currentObjective;
    }
}