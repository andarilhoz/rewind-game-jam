using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace _Game.Scripts.Dialogue
{
    [CreateAssetMenu(fileName = "DialogueConfig", menuName = "Rewind/DialogueConfig", order = 1)]
    public class Dialogue : ScriptableObject
    {
        public List<DialogueMesssages> dialogues;
    }
    
    [Serializable]
    public class DialogueMesssages
    {
        public string id;
        public string message;
    }
}