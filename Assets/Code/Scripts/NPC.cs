using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class NPC : MonoBehaviour
{
    public Dialouge dialouge;
    public void Interact()
    {
        FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
    }
}
