using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private ChatBot chatBot;


    public string Interact(string question)
    {
        return chatBot.GetAnswer(question);
    }
}
