using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Relations", menuName = "Game/Relations")]
public class Relations : ScriptableObject
{
    [Header("NPC Relations")]
    public int relationWithVictor;
    public int relationWithAshley;
    public int relationWithSergio;
    public int relationWithMarcel;
    public int relationWithGary;
    public int relationWithHank;
    public int relationWithOutsider;

    /// İlgili NPC'nin ilişki değerini artırır veya azaltır.
    public void ModifyRelation(string npcName, int value)
    {
        switch (npcName)
        {
            case "Victor":
                relationWithVictor += value;
                break;
            case "Ashley":
                relationWithAshley += value;
                break;
            case "Sergio":
                relationWithSergio += value;
                break;
            case "Marcel":
                relationWithMarcel += value;
                break;
            case "Gary":
                relationWithGary += value;
                break;
            case "Hank":
                relationWithHank += value;
                break;
            case "Outsider":
                relationWithOutsider += value;
                break;
            default:
                Debug.LogWarning($"NPC '{npcName}' is not defined in the relations!");
                break;
        }
    }
}
