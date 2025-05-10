using System;

[Serializable]
public class QuestionData
{
    public string question;
    public string[] options;

    public string explanation;

    public int correctIndex;
}