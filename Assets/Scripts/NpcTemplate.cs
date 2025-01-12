using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewNPC", menuName = "NPC/NPC")]

[System.Serializable] public class NPC : ScriptableObject
{
    [Header("NPC Information")]
    public string npcName;
    public Sprite npcSprite;
    public string description;
    public List<Quest> Quests;
    public List<Quest> OnGoingQuests;

}