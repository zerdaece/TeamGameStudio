using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcrelationuibar : MonoBehaviour
{
    public NPC Npc1;
    public NPC Npc2;
    public Relations relations;
    [SerializeField] private RectTransform relationstatus;
    void Update()
    {
        int npc1relation = (int)relations.GetType().GetField( "relationWith" +  Npc1.npcName ).GetValue( relations );
        int npc2relation = (int)relations.GetType().GetField( "relationWith" + Npc2.npcName ).GetValue( relations );
        relationstatus.sizeDelta = new Vector2(  (npc1relation - npc2relation + 1) * 10 + 740, relationstatus.sizeDelta.y );
    }
}
