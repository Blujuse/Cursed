using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission_Complete : MonoBehaviour
{
    public Basic_Patrol_V2 Target;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Target.Dead == true)
        {
            SceneManager.LoadScene(2);
        }
    }
}
