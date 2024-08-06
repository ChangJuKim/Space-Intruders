using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{

    [SerializeField] private PlayerStats basePlayerStats;
    [SerializeField] private AlienStats baseAlienStats;

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private AlienStats alienStats;

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
