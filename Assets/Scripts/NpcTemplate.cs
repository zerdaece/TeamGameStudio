using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewNPC", menuName = "NPC/NPC")]
public class NPC : ScriptableObject
{
    [Header("NPC Information")]
    public string npcName;
    public string description;

}