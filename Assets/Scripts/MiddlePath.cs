using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePath : MonoBehaviour
{
    public GameObject Bamboo1;

    public GameObject Bamboo2;

    public Basic_Patrol_V2 Target;

    private void Start()
    {
        Bamboo1.SetActive(false);
        Bamboo2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Target.Dead == true)
        {
            Bamboo1.SetActive(true);
            Bamboo2.SetActive(true);
        }
    }
}
