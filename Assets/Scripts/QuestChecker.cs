using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestChecker : MonoBehaviour
{
    public List<Quest> quests;

    public float checkInterval = 1f; // Time in seconds between checks
    private float timer = 0f;
    public Resources resources;

    void Start()
    {
        resources.TotalRoomCount =1;
        resources.DynamicRoomCounts.Clear();
    }
    void LateUpdate()
    {
        timer += Time.deltaTime; // Increment timer by the time passed since the last frame

        // Check if the interval has passed
        if (timer >= checkInterval)
        {

            for (int i = 0; i < quests.Count; i++)
            {
                var quest = quests[i];
                quest.CheckQuest();
                if (quest.isCompleted)
                {
                    // Show a popup with the quest description and reward
                    PopUp.ShowPopup(quest.description, "Claim", "Close", () => Destroy(GameObject.Find("PopUp(Clone)")), () => Destroy(GameObject.Find("PopUp(Clone)")));
                    quests.RemoveAt(i);
                    i--; // Decrease the index to account for the removed quest
                }
            }

            // Reset timer after checking quests
            timer = 0f;
        }
    }
    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
    }

}

