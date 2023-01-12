using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[Serializable]
public class Sentences
{
    public string actorname;
    public Sprite profile;
    public Languages sentence;
}

[Serializable]
public class Languages
{
    public string potuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR

[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings dialogueSettings = (DialogueSettings)target;
        
        Languages languages = new Languages();
        languages.potuguese = dialogueSettings.sentence;

        Sentences sentences = new Sentences();
        sentences.profile = dialogueSettings.speakerSprite;
        sentences.sentence = languages;

        if (GUILayout.Button("Create Dialogue"))
        {
            if (!string.IsNullOrEmpty(dialogueSettings.sentence))
            {
                dialogueSettings.dialogues.Add(sentences);

                // Limpar campos
                dialogueSettings.speakerSprite = null;
                dialogueSettings.sentence = string.Empty;
            }
        }
    }
}

#endif
