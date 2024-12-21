using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Health : MonoBehaviour
{
    public int HP = 100;
    
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            //play death animation
        }
    }
}
