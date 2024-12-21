using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator_Audio : MonoBehaviour
{

    public AudioSource audioSource;

    public AudioClip Goal;

    public AudioClip Almost_There;

    public AudioClip Target_Dead;

    public Basic_Patrol_V2 Target;

    public GameObject TriggerBox;

    public bool AudioPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(Goal);  
    }

    // Update is called once per frame
    void Update()
    {
        if (Target.Dead == true && AudioPlayed == false)
        {
            audioSource.PlayOneShot(Target_Dead);
            AudioPlayed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AudioTrigger")
        {
            audioSource.PlayOneShot(Almost_There);
            Destroy(TriggerBox);
        }
    }
}
