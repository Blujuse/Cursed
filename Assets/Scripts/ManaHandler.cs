using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaHandler : MonoBehaviour
{
    public Image manaBar;

    public float myMana;

    public float currentMana;

    public float manaRecharge;
    private void Update()
    {
        if (currentMana < myMana)
        {
            manaBar.fillAmount = Mathf.MoveTowards(manaBar.fillAmount, 1f, Time.deltaTime * manaRecharge);
            currentMana = Mathf.MoveTowards(currentMana / myMana, 1f, Time.deltaTime * manaRecharge) * myMana;
        }
    
        if (currentMana < 0)
        {
            currentMana = 0;
        }
    }

    public void ReduceMana(float mana)
    {
        currentMana -= mana;
        manaBar.fillAmount -= mana / myMana;
    }
}
