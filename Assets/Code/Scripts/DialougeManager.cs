using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    private Queue<string> sentences;
    [SerializeField] private Animator animator;
    [SerializeField] private Text nameText;
    [SerializeField] private Text dialougeText;
    [SerializeField] private Image image;
    [SerializeField] private PlayerController player;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialouge(Dialouge dialouge)
    {
        player.isTalking = true;
        Cursor.lockState = CursorLockMode.None;
        animator.SetBool("IsOpen", true);

        nameText.text = dialouge.name;
        image.sprite = dialouge.sprite;

        sentences.Clear();

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialougeText.text = "";

        foreach (char c in sentence.ToCharArray())
        {
            dialougeText.text += c;
            yield return null;
        }
    }

    void EndDialouge()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator.SetBool("IsOpen", false);
        player.isTalking = false;
    }
}
