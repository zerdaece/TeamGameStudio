using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
                int currentRoomCount = resources.TotalRoomCount;
                if (currentRoomCount >= wantedRoomCount)
                {
                    QuestComplete();
                }

                break;
            case "havexamountofyroom":

                string WantedRoomType = wantedRoomtype.id + "RoomCount";
                Debug.Log($"Kontrol ediliyor: {wantedRoomtype.id}");


                if (!resources.DynamicRoomCounts.ContainsKey(WantedRoomType))
                {
                    {
                        resources.DynamicRoomCounts.Add(WantedRoomType, 0);
                    }
                }
                Debug.Log($"Kontrol ediliyor: {resources.DynamicRoomCounts[WantedRoomType]}");
                
                if (resources.DynamicRoomCounts[WantedRoomType] >= wantedRoomCount)
                    QuestComplete();
                break;


            case "collectxamountofy":
                if (wantedresourcevalue >= (int)resources.GetType().GetField(wantedresourcename).GetValue(resources))
                    QuestComplete();
                break;

            default:
            Debug.Log("Quest Type not found");
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