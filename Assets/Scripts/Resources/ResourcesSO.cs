using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "resources", menuName = "Resources")]

public class Resources : ScriptableObject
{
    public int goins;
    public int energy;
    public int alcohol;
    public int coal;
    public int dopamin;
    public float satisfaction;
    public int TotalBorch;
    public int GeneratorRoomCount;
    public int FarmRoomCount;
    public int SpeakeasyRoomCount;
    public int AccommodationRoomCount;
    public int DistillerRoomCount;
    public int TotalRoomCount;

    public Dictionary<string, int> DynamicRoomCounts = new Dictionary<string, int>();

}
