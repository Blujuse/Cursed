using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Screen : MonoBehaviour
{

    public Basic_Patrol_V2 bot;

    // Update is called once per frame
    void Update()
    {
        if (bot.Player_dead == true && bot.bot_IsInvestigating == true && bot.InAssassinBox == false)
        {
            SceneManager.LoadScene("Fail_Screen");
        }
        
    }
}
