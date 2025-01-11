using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quests/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    public string description;
    public int rewardGoins;
    public int rewardEnergy;
    public int rewardAlcohol;
    public int rewardCoal;
    public int rewardDopamin;
    public string questType;
    public Resources resources;
    public int wantedRoomCount;
    public string wantedresourcename;
    public int wantedresourcevalue;
    public static event System.Action OnQuestCompleted;
    public RoomTemplate wantedRoomtype;
    //public Dictionary<NPC, int> changeinnpcrelations; dictionarye inspectorda değer giremiyoruz.
    public List<NPCRelationChange> changeinnpcrelations;

    public List<roomsthatgetsupgraded> roomsthatgetsupgraded;

    public Relations relations;
    public bool isCompleted = false;

    public void CheckQuest()
    {
        switch (questType.ToLower())
        {
            case "roomcount":
                string propertyName = wantedRoomtype.Name + "RoomCount";
                if (!resources.DynamicRoomCounts.ContainsKey(propertyName))
                {
                    {
                        resources.DynamicRoomCounts[propertyName] = 0; // Varsayılan olarak 0 başlat
                    }
                }
                int currentRoomCount = (int)resources.GetType().GetProperty(propertyName).GetValue(resources);
                if (currentRoomCount >= wantedRoomCount)
                {
                    QuestComplete();
                }

                break;
            case "havexamountofroom":
                string WantedRoomType = wantedRoomtype.Name + "RoomCount";
                if((int)resources.GetType().GetProperty(WantedRoomType).GetValue(resources) > wantedRoomCount)
                QuestComplete();
            break;
            case "collectxamountofy":
                if(wantedresourcevalue >= (int)resources.GetType().GetField(wantedresourcename).GetValue(resources))
                QuestComplete();
            break;



        }

        void QuestComplete()
        {
            isCompleted = true;
            foreach (var npc in changeinnpcrelations)
            {
                relations.ModifyRelation(npc.npc.npcName, npc.relationChange);
            }

            Debug.Log("Quest Completed");
            resources.goins += rewardGoins;
            resources.energy += rewardEnergy;
            resources.alcohol += rewardAlcohol;
            resources.coal += rewardCoal;
            resources.dopamin += rewardDopamin;
            OnQuestCompleted?.Invoke();
            foreach (var room in roomsthatgetsupgraded)
            {
                room.roomType.RoomUpdates.Add(room.upgradedRoomType);
            }
        }
    }
}

[System.Serializable]
public class roomsthatgetsupgraded
{
    public RoomTemplate roomType;
    public RoomTemplate upgradedRoomType;
}
[System.Serializable]
public class NPCRelationChange
{
    public NPC npc;
    public int relationChange;
}