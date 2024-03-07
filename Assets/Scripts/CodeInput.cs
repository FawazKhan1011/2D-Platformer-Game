using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class CodeInput : MonoBehaviour
{
    public Dictionary<DateTime, string> codeMap = new Dictionary<DateTime, string>(); // Mapping between dates and codes
    public string sceneName = "game"; // Name of the scene to load
    public TMP_InputField inputField; // Reference to the TMP_InputField component
    public TMP_Text resultText; // Reference to the TMP_Text component to display result

    private void Start()
    {
        inputField.text = "";
        PopulateCodeMap();
    }

    private void PopulateCodeMap()
    {
        // Add codes and dates from March 5th to April 7th
        codeMap.Add(new DateTime(2024, 3, 5), "0000");
        codeMap.Add(new DateTime(2024, 3, 12), "1234");
        codeMap.Add(new DateTime(2024, 3, 13), "5678");
        codeMap.Add(new DateTime(2024, 3, 14), "9876");
        codeMap.Add(new DateTime(2024, 3, 15), "4321");
        codeMap.Add(new DateTime(2024, 3, 16), "8765");
        codeMap.Add(new DateTime(2024, 3, 17), "5432");
        codeMap.Add(new DateTime(2024, 3, 18), "7890");
        codeMap.Add(new DateTime(2024, 3, 19), "2109");
        codeMap.Add(new DateTime(2024, 3, 20), "0987");
        codeMap.Add(new DateTime(2024, 3, 21), "6543");
        codeMap.Add(new DateTime(2024, 3, 22), "1098");
        codeMap.Add(new DateTime(2024, 3, 23), "8765");
        codeMap.Add(new DateTime(2024, 3, 24), "5432");
        codeMap.Add(new DateTime(2024, 3, 25), "2109");
        codeMap.Add(new DateTime(2024, 3, 26), "0987");
        codeMap.Add(new DateTime(2024, 3, 27), "6543");
        codeMap.Add(new DateTime(2024, 3, 28), "1098");
        codeMap.Add(new DateTime(2024, 3, 29), "8765");
        codeMap.Add(new DateTime(2024, 3, 30), "5432");
        codeMap.Add(new DateTime(2024, 3, 31), "2109");
        codeMap.Add(new DateTime(2024, 4, 1), "0987");
        codeMap.Add(new DateTime(2024, 4, 2), "6543");
        codeMap.Add(new DateTime(2024, 4, 3), "1098");
        codeMap.Add(new DateTime(2024, 4, 4), "8765");
        codeMap.Add(new DateTime(2024, 4, 5), "5432");
        codeMap.Add(new DateTime(2024, 4, 6), "2109");
        codeMap.Add(new DateTime(2024, 4, 7), "0987");
    }

    private void UpdateInputField()
    {
        DateTime currentDate = DateTime.UtcNow.AddHours(5.5); // Convert to IST
        Debug.Log("Time checked: " + currentDate.ToString());
    }

    public void CheckCode()
    {
        UpdateInputField();
        string input = inputField.text;
        DateTime currentDate = DateTime.UtcNow.AddHours(5.5); // Convert to IST
        currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day); // Set time to 00:00:00

        string correctCode;
        if (codeMap.TryGetValue(currentDate, out correctCode))
        {
            if (input == correctCode)
            {
                // Change the scene to the specified scene name
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
            else
            {
                resultText.text = "No code found for today's date.";
            }
        }
    }
}
