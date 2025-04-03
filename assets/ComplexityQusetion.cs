[System.Serializable]
public class ComplexityQuestion
{
    [TextArea(3,5)] 
    public string algorithmDescription;
    
    [Header("Correct answer")]
    public string bigOComplexity;
    
    [Header("interference term")]
    public string[] wrongOptions;
}
