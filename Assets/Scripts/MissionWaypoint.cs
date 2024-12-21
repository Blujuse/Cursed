using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{

    public Image img;
    public Transform target;
    public Text metre;
    public Vector3 offset;
    
    public Basic_Patrol_V2 bot;
    public Transform target2;

    // Update is called once per frame
    void Update()
    {
        if (bot.Dead == false)
        {
            float minX = img.GetPixelAdjustedRect().width / 2;
            float maxX = Screen.width - minX;

            float minY = img.GetPixelAdjustedRect().height / 2;
            float maxY = Screen.height - minY;

            Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

            if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
            {
                // target is behind the player
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                }
            }

            img.transform.position = pos;
            metre.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";

            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
        }
        else if (bot.Dead == true)
        {
            float minX = img.GetPixelAdjustedRect().width / 2;
            float maxX = Screen.width - minX;

            float minY = img.GetPixelAdjustedRect().height / 2;
            float maxY = Screen.height - minY;

            Vector2 pos = Camera.main.WorldToScreenPoint(target2.position + offset);

            if (Vector3.Dot((target2.position - transform.position), transform.forward) < 0)
            {
                // target is behind the player
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                }
            }

            img.transform.position = pos;
            metre.text = ((int)Vector3.Distance(target2.position, transform.position)).ToString() + "m";

            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
        }
        
    }
}
