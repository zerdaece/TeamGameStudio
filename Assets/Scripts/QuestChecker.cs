using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestChecker : MonoBehaviour
{
    public List<Quest> quests;
    void LateUpdate()
    {
        foreach (var quest in quests)
        {
            quest.CheckQuest();
        }
    }
}

