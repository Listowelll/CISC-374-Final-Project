using UnityEngine;
using UnityEngine.SceneManagement;
public class Switch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      Debug.Log("Switch script started.");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        Debug.Log("Loading game scene...");
        // Logic to handle the switch being activated
        SceneManager.LoadScene("MainScene");
        // Console.WriteLine("Switch activated! Loading MainScene...");
    }
}
