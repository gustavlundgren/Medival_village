using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class NPC : MonoBehaviour
{
    public Dialouge dialouge;
    public void Interact(PlayerController player)
    {
        if (player.isTalking)
        {
            FindObjectOfType<DialougeManager>().DisplayNextSentence();
        }
        else
        {
            FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
        }

    }
}
