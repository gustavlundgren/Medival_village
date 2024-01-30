using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class ChatBot : MonoBehaviour
{
    private List<FAQ> faqs;

    private void Start()
    {
        faqs = GetFaqs("faqs.json");
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

            return JsonConvert.DeserializeObject<List<FAQ>>(json);
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