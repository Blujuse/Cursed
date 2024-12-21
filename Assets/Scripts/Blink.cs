using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    Camera cam;

    public BlinkLocation teleportationSpot;

    public bool BlinkToggle = false;

    public GameObject BlinkBox;

    public ManaHandler Mana;

    public float TeleportDistance;

    public Inhibitor InhibTele;
   
    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        BlinkBox.SetActive(false);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) && BlinkToggle == false)
        {
            BlinkToggle = true;
            BlinkBox.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && BlinkToggle == true)
        {
            BlinkToggle = false;
            BlinkBox.SetActive(false);
        }


        if (InhibTele.NoTeleport == false)
        {

            if (BlinkToggle == true)
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, TeleportDistance))
                {
                    teleportationSpot.transform.position = hit.point;
                    teleportationSpot.transform.rotation = Quaternion.LookRotation(hit.normal);

                    if (Input.GetMouseButtonDown(1) && Mana.currentMana > 1)
                    {
                        transform.position = teleportationSpot.transform.position;
                        Mana.ReduceMana(1);
                    }
                }
            }
        }
        else
        {
            BlinkToggle = false;
            BlinkBox.SetActive(false);
        }
    }
}
