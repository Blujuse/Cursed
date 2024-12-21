using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public static int Collection;

    public Animator anim;

    public Text CollectableUI;

    public GameObject Slash;

    public GameObject Num;

    public GameObject Complete;

    public Basic_Patrol_V2 Bot;

    public GameObject Obj1;

    public GameObject Obj2;

    private void Start()
    {
        Collection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            anim.SetBool("Slide", true);
        }
        else
        {
            anim.SetBool("Slide", false);
        }

        CollectableUI.text = Collection.ToString();
    
        if (Collection >= 20)
        {
            CollectableUI.text = null;
            Slash.SetActive(false);
            Num.SetActive(false);
            Complete.SetActive(true);
        }
    
        if (Bot.Dead == false)
        {
            Obj1.SetActive(true);
            Obj2.SetActive(false);
        }
        else
        {
            Obj1.SetActive(false);
            Obj2.SetActive(true);
        }
    }
}
