public class Objective
{
    private IBlockType operatorBlock;

    public int[] terms;
    public float solution;

    private string equation;

    public Objective(IBlockType operatorBlock, int termAmount)
    {
        this.operatorBlock = operatorBlock;

        terms = operatorBlock.GenerateTerms(termAmount);
        solution = operatorBlock.ApplyOperator(terms);

        equation = "";
        for (int i = 0; i < terms.Length; i++)
        {
            if (i > 0) equation += " ... ";
            equation += terms[i];
        }

        equation += string.Format(" = {0}", solution);
    }

    public IBlockType GetOperatorBlock()
    {
        return operatorBlock;
    }

    public string GetEquation()
    {
        return equation;
    }
}
