using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RoomTemplate", menuName = "Rooms/RoomTemplate")]
public class RoomTemplate : ScriptableObject
{
    public int id;
    public string roomName;
    [Header("Resources")]
    public int goins;
    public int energy;
    public int alcohol;
    public int coal;
    public int dopamin;

    }
