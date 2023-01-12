using Assets.Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC_Dialog : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    public DialogueSettings dialogue;

    private bool playerHit;
    //private List<string> sentences = new List<string>();
    private string[] sentences = { };

    private void Start()
    {
        GetNpcSentences();
    }

    // Chamado a cada frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogControl.instance.Speech(sentences);
        }
    }

    // É usado pela física
    void FixedUpdate()
    {
        ShowDialog();
    }


    void GetNpcSentences()
    {
        // Mesma lógica só que com LinQ
        sentences = dialogue.dialogues.Select(d => GetTextByIdiom(d)).ToArray();
    }

    private string GetTextByIdiom(Sentences sentences)
    {
        switch (DialogControl.instance.language)
        {
            case Idiom.portuguese:
                return sentences.sentence.potuguese;
            case Idiom.english:
                return sentences.sentence.english;
            case Idiom.spanish:
                return sentences.sentence.spanish;
            default:
                return "No translate";
        }
    }

    void ShowDialog()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            DialogControl.instance.CloseDialog();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
