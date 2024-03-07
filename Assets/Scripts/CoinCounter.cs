using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coinText;
    public int currentCoins = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinText.text = currentCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = currentCoins.ToString();

        // Check if currentCoins reaches 30
        if (currentCoins >= 30)
        {
            // Start a coroutine to delay the scene change
            StartCoroutine(DelayedSceneChange("End", 1f));
        }
    }

    IEnumerator DelayedSceneChange(string sceneName, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
