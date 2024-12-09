using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RoomTemplate", menuName = "Rooms/RoomTemplate")]
public class RoomTemplate : ScriptableObject
{
    public int id;
    public string roomType;
    public string Description;
    [Header("Resources")]
    public int goins;
    public int energy;
    public int alcohol;
    public int coal;
    public int dopamin;
    public List<RoomTemplate> RoomUpdates;
    }
