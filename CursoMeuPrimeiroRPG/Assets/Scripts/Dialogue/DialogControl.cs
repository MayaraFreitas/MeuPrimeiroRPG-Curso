using Assets.Scripts.Enums;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    public Idiom language;

    [Header("Components")]
    public GameObject dialogObj; // Janela do dialogo
    public Image profileSprite; // Sprite do perfil
    public Text speechText; // Texto da fala
    public Text actorNameText; // Nome do NPC

    [Header("Settings")]
    public float typingSpeed; // Velocidade da fala

    // Variáveis de controle
    private bool _isShowing; // Se a janela está visível
    private int index; // index das sentenças (fala)
    private string[] sentences;

    public static DialogControl instance;

    public bool IsShowing { get => _isShowing; set => _isShowing = value; }

    // Awake é chamado antes de todos os Start() na hierarquia de execução de scripts (de todos)
    private void Awake()
    {
        instance = this;
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Pular para a próxima frase/fala
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = string.Empty;
                StartCoroutine(TypeSentence());
            }
            else // Quando termina os textos
            {
                CloseDialog();
            }
        }
    }


    // Chamar a fala do NPC
    public void Speech(string[] txt)
    {
        if (!_isShowing)
        {
            dialogObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            _isShowing = true;
        }
    }

    public void CloseDialog()
    {
        speechText.text = string.Empty;
        index = 0;
        dialogObj.SetActive(false);
        sentences = null;
        _isShowing = false;
    }
}
