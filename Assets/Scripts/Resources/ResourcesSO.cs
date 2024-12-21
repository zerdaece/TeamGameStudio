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
    public int satisfaction;
    public int TotalBorch;
    public int GeneratorRoomCount;
    public int FarmRoomCount;
    public int SpeakeasyRoomCount;
    public int AccommodationRoomCount;
    public int DistillerRoomCount;
    public int TotalRoomCount;

    void Start()
    {
        goins = 0;
        energy = 0;
        alcohol = 0;
        coal = 0;
        dopamin = 0;
        satisfaction = 0;
        TotalBorch = 0;
        GeneratorRoomCount = 0;
        FarmRoomCount = 0;
        SpeakeasyRoomCount = 0;
        AccommodationRoomCount = 0;
        DistillerRoomCount = 0;
        TotalRoomCount = 1;
        }
}
