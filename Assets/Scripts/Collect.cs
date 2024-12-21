using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public bool collect = false;

    public GameObject CollectText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && collect == true)
        {
            Objective.Collection += 1;
            CollectText.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collect = true;
        CollectText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        collect = false;
        CollectText.SetActive(false);
    }
}
