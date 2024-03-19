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
    [SerializeField] private PlayerController player;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialouge(Dialouge dialouge)
    {
        player.isTalking = true;
        animator.SetBool("IsOpen", true);

        nameText.text = dialouge.name;

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
        animator.SetBool("IsOpen", false);
        player.isTalking = false;
    }
}
