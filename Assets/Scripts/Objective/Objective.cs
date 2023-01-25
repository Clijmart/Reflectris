public class Objective
{
    private IBlockType operatorBlock;

    public int[] terms;
    public float solution;

    private string equation;

    /// <summary>
    /// Create an objective with a given operator block and term amount.
    /// </summary>
    /// <param name="operatorBlock">The operator block to create the objective with.</param>
    /// <param name="termAmount">The amount of terms to add to the objective.</param>
    public Objective(IBlockType operatorBlock, int termAmount)
    {
        this.operatorBlock = operatorBlock;

        terms = operatorBlock.GenerateTerms(amount: termAmount);
        solution = operatorBlock.ApplyOperator(terms);

        // Format the equation neatly
        equation = "";
        for (int i = 0; i < terms.Length; i++)
        {
            if (i > 0) equation += " ... ";
            equation += terms[i];
        }

        equation += string.Format(" = {0}", solution);
    }

    /// <summary>
    /// Get the operator block belonging to the objective.
    /// </summary>
    /// <returns>The connected operator block.</returns>
    public IBlockType GetOperatorBlock()
    {
        return operatorBlock;
    }

    /// <summary>
    /// Get the equation belonging to the objective.
    /// </summary>
    /// <returns>The connected equation.</returns>
    public string GetEquation()
    {
        return equation;
    }
}