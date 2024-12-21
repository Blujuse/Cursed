using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inhibitor : MonoBehaviour
{
    public bool NoTeleport = false;

    public GameObject BarImage;

    public GameObject CursedText;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NoTeleport = true;
            Debug.Log("Inhibiting");
            BarImage.SetActive(true);
            CursedText.SetActive(true);
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NoTeleport = false;
            Debug.Log("Not Inhibiting");
            BarImage.SetActive(false);
            CursedText.SetActive(false);
        } 
    }
}
