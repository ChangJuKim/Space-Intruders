using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public PlayerStats basePlayerStats;
    public AlienStats baseAlienStats;

    public PlayerStats playerStats;
    public AlienStats alienStats;

    // Start is called before the first frame update
    void Start()
    {
        ResetPlayerStats();
        ResetAlienStats();
    }

    public void ResetPlayerStats()
    {
        playerStats.ResetTo(basePlayerStats);
    }

    public void ResetAlienStats()
    {
        alienStats.ResetTo(baseAlienStats);
    }


}
