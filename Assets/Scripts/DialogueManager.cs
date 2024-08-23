using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI nameText;

    [SerializeField]
    TextMeshProUGUI sentencesText;

    private Queue<string> _sentences;
    private Animator _animator;

    private void Awake()
    {
        _sentences = new Queue<string>();
        _animator = GetComponent<Animator>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        gameObject.SetActive(true);
        _animator.SetBool("isOpen", true);
        StartCoroutine(StartDialogueCoroutine(dialogue));
    }

    public IEnumerator StartDialogueCoroutine(Dialogue dialogue)
    {
        yield return new WaitForSeconds(0.5F);
        nameText.text = dialogue.getName();

        _sentences.Clear();
        foreach (string sentence in dialogue.getSentences())
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }


        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void EndDialogue()
    {
        _animator.SetBool("isOpen", false);
        StartCoroutine(EndDialogueCoroutine());
    }

    private IEnumerator EndDialogueCoroutine()
    {
        yield return new WaitForSeconds(0.5F);
        gameObject.SetActive(false);
    }

    private IEnumerator TypeSentence(string sentence)
    {
        sentencesText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            sentencesText.text += letter;
            yield return null;
        }
    }

    
}
