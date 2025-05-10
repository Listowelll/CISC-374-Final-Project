using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int questionsPerLevel = 5;   
    public UIManager uiManager;
    public SimpleChest chest;
    public TimerController timer;
    public FailPanel failPanel;

    public GameObject bgLevel1;
    public GameObject bgLevel2;
    public GameObject bgLevel3;
    public GameObject victoryPanel;

    [Header("Chest UI (per level)")]
    public Image chestL1;
    public Image chestL2;
    public Image chestL3;

    [Header("Chest Sprites")]
    public Sprite chestClosedSprite;
    public Sprite chestOpenSprite;

    private Image currentChest;   

    private readonly List<QuestionData> questions = new(); 
    private int level = 1;            
    private int currentQuestion = 0;  
    public Vector3[] chestPositions;   
    private void Start()
    {
        LoadDefaultQuestions();
        //StartFirstQuestion();         
    }

    public void StartFirstQuestion()
    {
        level = 1;
        currentQuestion = 0;
        ActivateBackground();
        ShowNextQuestion();
    }

    public void HandleFail(string tip) => failPanel.ShowFail(tip);
   
    public void HandleFail() => failPanel.ShowFail(string.Empty);

    public void RestartGame() => SceneManager.LoadScene(0);

    private void ShowNextQuestion()
    {
        if (level > 3)
        {
            victoryPanel.SetActive(true);
            AudioManager.I?.PlayVictory();
            Time.timeScale = 0;
            return;
        }

        if (currentQuestion >= questionsPerLevel)
        {
            level++;
            currentQuestion = 0;
            ActivateBackground();
        }

        if (level > 3) { ShowNextQuestion(); return; }

        if (currentChest != null && chestClosedSprite != null)
            currentChest.sprite = chestClosedSprite;

        timer.StartTimer();
        uiManager.DisplayQuestion(questions[(level - 1) * questionsPerLevel + currentQuestion]);
    }

    public void SubmitAnswer(int index)
    {
        var idx = (level - 1) * questionsPerLevel + currentQuestion;
        bool correct = index == questions[idx].correctIndex;
        uiManager.ShowAnswerResult(correct);

        if (correct)
        {
            AudioManager.I?.PlayCorrect();

            if (currentChest != null && chestOpenSprite != null)
                currentChest.sprite = chestOpenSprite;

            currentQuestion++;
            Invoke(nameof(ShowNextQuestion), 1f);
        }
        else
        {
            AudioManager.I?.PlayWrong();
            HandleFail(questions[idx].explanation);
        }
    }

    private void ActivateBackground()
    {
        bgLevel1.SetActive(level == 1);
        bgLevel2.SetActive(level == 2);
        bgLevel3.SetActive(level == 3);

        
        chestL1.gameObject.SetActive(level == 1);
        chestL2.gameObject.SetActive(level == 2);
        chestL3.gameObject.SetActive(level == 3);

        currentChest = level switch
        {
            1 => chestL1,
            2 => chestL2,
            _ => chestL3
        };
    }
    private void LoadDefaultQuestions()
    {
        questions.Add(new QuestionData {
            question = "What is the time complexity of random array access by index?",
            options = new[] { "O(1)", "O(log n)", "O(n)", "O(n log n)" },
            correctIndex = 0,
            explanation = @" Constant Time Access
    • Arrays use contiguous memory blocks
    • Address calculation: base_address + index * element_size
    • Example: Accessing element[50] in int[100] (4 bytes/element):
    Address = 1000 + 50*4 = 1200 (single calculation)
    Common mistake: Confusing with linked list access (O(n))"
        });

        questions.Add(new QuestionData {
            question = "Worst-case time complexity of linear search:",
            options = new[] { "O(1)", "O(log n)", "O(n)", "O(n^2)" },
            correctIndex = 2,
            explanation = @" Sequential Search Analysis
    • Must check all elements in worst case
    • Example: 1000 elements = 1000 checks
    • Mathematical proof: Σ(1) from 1 to n = n
     Better alternative: Binary search (O(log n)) for sorted data"
        });

        questions.Add(new QuestionData {
            question = "Amortized cost of appending to dynamic arrays:",
            options = new[] { "O(1)", "O(n)", "O(log n)", "O(n log n)" },
            correctIndex = 0,
            explanation = @" Resizing Strategy
    • Default growth factor: 2x
    • Amortized analysis: n inserts with doubling strategy
    • Cost equation: n + (n/2 + n/4 + ... + 1) ≤ 2n
     Key insight: Infrequent resizes spread cost over many operations"
        });

        questions.Add(new QuestionData {
            question = "Worst-case time complexity of bubble sort:",
            options = new[] { "O(n)", "O(n log n)", "O(n^2)", "O(log n)" },
            correctIndex = 2,
            explanation = @" Sorting Mechanism
    • Worst case: Reverse-sorted array
    • Comparisons: (n-1) + (n-2) + ... + 1 = n(n-1)/2
    • Mathematical simplification: O(n^2)
     Optimization: Early termination check reduces best case to O(n))"
        });

        questions.Add(new QuestionData {
            question = "Time complexity of binary search on sorted array:",
            options = new[] { "O(1)", "O(log n)", "O(n)", "O(n^2)" },
            correctIndex = 1,
            explanation = @" Divide and Conquer
    • Search space halves each iteration
    • Mathematical proof: n/(2^k) = 1 → k = log2(n)
    • Example: 1024 elements → 10 comparisons max
     Requirement: Array must be sorted (O(n log n) sort cost))"
        });

        questions.Add(new QuestionData {
            question = "Average-case insertion in hash table with load factor Alphard < 0.7:",
            options = new[] { "O(1)", "O(n)", "O(log n)", "O(n^2)" },
            correctIndex = 0,
            explanation = @" Hashing Fundamentals
    • Load factor Alphard = entries/buckets
    • Successful search cost: 1/2(1 + 1/(1-Alphard))
    • Unsuccessful search cost: 1/(1-Alphard)
    Perfect hashing: O(1) with no collisions"
        });

        questions.Add(new QuestionData {
            question = "Search in balanced BST (AVL/Red-Black):",
            options = new[] { "O(n)", "O(log n)", "O(1)", "O(n log n)" },
            correctIndex = 1,
            explanation = @" Tree Properties
    • Balance condition: Height = O(log n)
    • Search path: Root to leaf traversal
    • Mathematical proof: 2^h ≥ n → h ≥ log2(n)
     Unbalanced trees can degrade to O(n))"
        });

        questions.Add(new QuestionData {
            question = "Time to build heap with Floyd's algorithm:",
            options = new[] { "O(n)", "O(n log n)", "O(log n)", "O(n^2)" },
            correctIndex = 0,
            explanation = @" Heap Construction
    • Bottom-up approach
    • Complexity analysis: Σ(height of each node)
    • Mathematical result: Sum ≤ 2n → O(n)
     Comparison: Top-down insertion would be O(n log n))"
        });

        questions.Add(new QuestionData {
            question = "Amortized dequeue cost using two stacks:",
            options = new[] { "O(1)", "O(n)", "O(log n)", "O(n log n)" },
            correctIndex = 0,
            explanation = @" Stack Reversal Strategy
    • Enqueue: Push to input stack
    • Dequeue: Pop from output stack (reverse when empty)
    • Amortized analysis: Each element moved twice max
     Real-world analogy: Loading/unloading shipping containers"
        });

        questions.Add(new QuestionData {
            question = "Merge sort time complexity:",
            options = new[] { "O(n)", "O(n^2)", "O(log n)", "O(n log n)" },
            correctIndex = 3,
            explanation = @" Divide and Conquer
    • Recursion tree depth: log2(n)
    • Work per level: O(n) merges
    • Total cost: n * log n
     Space complexity: O(n) auxiliary space"
        });

        questions.Add(new QuestionData {
            question = "Dijkstra's algorithm with binary heap:",
            options = new[] { "O(|E|+|V|)", "O(|E| log |V|)", "O(|V|^2)", "O(|E| log |E|)" },
            correctIndex = 1,
            explanation = @" Shortest Path Analysis
    • |V| vertices, |E| edges
    • Heap operations: |E| decrease-key, |V| extract-min
    • Cost: O((|E| + |V|) log |V|) → simplifies to O(|E| log |V|)
     Different implementations: Fibonacci heap O(|E| + |V| log |V|))"
        });

        questions.Add(new QuestionData {
            question = "Strassen's matrix multiplication complexity:",
            options = new[] { "O(n^3)", "O(n^2.81)", "O(n^2)", "O(n log n)" },
            correctIndex = 1,
            explanation = @" Matrix Algorithm Breakthrough
    • Traditional: 8 recursive calls → O(n^3)
    • Strassen's: 7 recursive calls → O(n^log2(7)) ≈ O(n^2.8074)
    • Practical use: Faster for n > 100 typically
     Current best: Coppersmith-Winograd O(n^2.373))"
        });

        questions.Add(new QuestionData {
            question = "Quickselect average-case complexity:",
            options = new[] { "O(n)", "O(n log n)", "O(log n)", "O(n^2)" },
            correctIndex = 0,
            explanation = @" Selection Algorithm
    • Based on quicksort partitioning
    • Average case analysis: T(n) = T(n/2) + O(n)
    • Geometric series sum: n + n/2 + n/4 + ... ≈ 2n
    Worst case: Poor pivot selection → O(n^2))"
        });

        questions.Add(new QuestionData {
            question = "FFT (Cooley-Tukey) runtime:",
            options = new[] { "O(n)", "O(n^2)", "O(n log n)", "O(log n)" },
            correctIndex = 2,
            explanation = @" Fourier Transform Optimization
    • Divide-and-conquer approach
    • Recursive relation: T(n) = 2T(n/2) + O(n)
    • Master theorem solution: O(n log n)
     Applications: Signal processing, polynomial multiplication"
        });

        questions.Add(new QuestionData {
            question = "SA-IS suffix array construction:",
            options = new[] { "O(n)", "O(n log n)", "O(n^2)", "O(log n)" },
            correctIndex = 0,
            explanation = @" Suffix Array Optimization
    • Induced sorting technique
    • Two passes over the data
    • Beats naive O(n^2 log n) approaches
    💡 Applications: Genome sequencing, full-text search"
        });
    }
}