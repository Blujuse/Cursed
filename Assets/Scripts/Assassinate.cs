using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassinate : MonoBehaviour
{
    public GameObject MouseUI;
    
    public Basic_Patrol_V2 BotHP;
  
    public Basic_Patrol_V2 BotHP1;

    public Basic_Patrol_V2 BotHP2;

    public Basic_Patrol_V2 BotHP4;

    public Basic_Patrol_V2 BotHP6;

    public Basic_Patrol_V2 BotHP8;

    public Basic_Patrol_V2 BotHP9;

    public Basic_Patrol_V2 BotHP11;

    public Basic_Patrol_V2 BotHP12;

    // Update is called once per frame
    void Update()
    {
        if (BotHP.InAssassinBox == true)
        {
            MouseUI.SetActive(true);
        }
        else if (BotHP1.InAssassinBox == true)
        {
            MouseUI.SetActive(true);
        }
        else if (BotHP2.InAssassinBox == true)
        {
            MouseUI.SetActive(true);
        }
        else if (BotHP4.InAssassinBox == true)
        {
            MouseUI.SetActive(true);
        }
        else if (BotHP6.InAssassinBox == true)
        {
            MouseUI.SetActive(true);
        }
        else if (BotHP8.InAssassinBox == true)
        {
            MouseUI.SetActive(true);
        }
        else if (BotHP9.InAssassinBox == true)
        {
            MouseUI.SetActive(true);
        }
        else if (BotHP11.InAssassinBox == true)
        {
            MouseUI.SetActive(true);
        }
        else if (BotHP12.InAssassinBox == true)
        {
            MouseUI.SetActive(true);
        }
        else
        {
            MouseUI.SetActive(false);
        }
        
        if (Input.GetMouseButtonDown(0) && BotHP.InAssassinBox == true)
        {
            BotHP.TakeDamage(100);
        }
        else if (Input.GetMouseButtonDown(0) && BotHP1.InAssassinBox == true)
        {
            BotHP1.TakeDamage(100);
        }
        else if (Input.GetMouseButtonDown(0) && BotHP2.InAssassinBox == true)
        {
            BotHP2.TakeDamage(100);
        }
        else if (Input.GetMouseButtonDown(0) && BotHP4.InAssassinBox == true)
        {
            BotHP4.TakeDamage(100);
        }
        else if (Input.GetMouseButtonDown(0) && BotHP6.InAssassinBox == true)
        {
            BotHP6.TakeDamage(100);
        }
        else if (Input.GetMouseButtonDown(0) && BotHP8.InAssassinBox == true)
        {
            BotHP8.TakeDamage(100);
        }
        else if (Input.GetMouseButtonDown(0) && BotHP9.InAssassinBox == true)
        {
            BotHP9.TakeDamage(100);
        }
        else if (Input.GetMouseButtonDown(0) && BotHP11.InAssassinBox == true)
        {
            BotHP11.TakeDamage(100);
        }
        else if (Input.GetMouseButtonDown(0) && BotHP12.InAssassinBox == true)
        {
            BotHP12.TakeDamage(100);
        }
    }
}
