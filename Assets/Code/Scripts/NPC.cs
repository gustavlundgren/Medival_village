using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject dialouge;

    public string Interact(string question)
    {
        // dialouge.GetComponent<TextMeshPro>().text = "test";
        dialouge.SetActive(true);
        return "Working NPC interactions";
    }
}
