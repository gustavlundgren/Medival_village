using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class ChatBot : MonoBehaviour
{
    private List<FAQ> faqs;

    private void Start()
    {
        faqs = GetFaqs("C:/Users/GustavLundgren/Desktop/Unity/3D/Gymnaisearbete-Medival_Village/ChatBotData");
    }

    // On interaction

    public string GetAnswer(string question)
    {

        return "Janne";
    }

    private List<FAQ> GetFaqs(string jsonPath)
    {
        try
        {
            var json = File.ReadAllText(jsonPath);

            // return JsonConvert.DeserializeObject<List<FAQ>>(json);

            return new List<FAQ>();
        }
        catch
        {
            return new List<FAQ>();
        }
    }
}

public class FAQ
{
    public string question { get; set; }
    public string answers { get; set; }
}