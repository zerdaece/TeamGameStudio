using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestChecker : MonoBehaviour
{
    public List<Quest> quests;
    public float checkInterval = 1f; // Time in seconds between checks
    private float timer = 0f;
    void LateUpdate()
    {
        timer += Time.deltaTime; // Increment timer by the time passed since the last frame

        // Check if the interval has passed
        if (timer >= checkInterval)
        {
            foreach (var quest in quests)
            {
                quest.CheckQuest();
            }

            // Reset timer after checking quests
            timer = 0f;
        }
    }


}

