using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Basic_Patrol_V2 : MonoBehaviour
{

    NavMeshAgent myAgent;
    
    public float botStartWaitTime = 4f;
    public float botWalkSpeed = 6f;
    float bot_WaitTime;
    float bot_ResumeTime;

    public Transform[] patrolWaypoints;

    int botCurrentWaypointIndex;

    public bool faceNextLocation;

    public bool bot_IsPatrolling = true;
    public bool bot_IsInvestigating = false;
    public bool bot_LookingBehind = false;
    public bool bot_AtDestination = false;

    private Vector3 locationToCheck;

    public FOV see;

    public Animator ani;

    public int HP = 100;

    public Collider AssassinBox;
    public bool InAssassinBox = false;
    public bool Dead = false;
    public Collider EnemyCol;

    public bool Player_dead = false;

    // Sounds
    
    public AudioSource audioSource;
    public AudioClip DeathSound;
    public AudioClip Wind;
    public AudioClip Stop_There;
    public bool CanPlayAudioDeath = true;
    public bool CanPlayAudioWind = false;
    public bool CanPlayAudioStopThere = true;
    public bool DoNotPlayAtStart = true;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        botCurrentWaypointIndex = 0;
        bot_WaitTime = botStartWaitTime;
        myAgent.SetDestination(patrolWaypoints
        [botCurrentWaypointIndex].position);
        
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Space))
        {
           // bot_IsPatrolling = false;
           // bot_IsInvestigating = false;
           // bot_IsSuspicious = true;
        }
   
        if (see.canSeePlayer == true)
        {
            bot_IsPatrolling = false;
            bot_IsInvestigating = true;
            bot_AtDestination = false;
            locationToCheck = (see.playerRef.transform.position);
            
        }

        if (Dead == true)
        {
            myAgent.isStopped = true;
            Destroy(EnemyCol);
            InAssassinBox = false;
            Destroy(AssassinBox);
            if (CanPlayAudioDeath == true)
            {
                audioSource.PlayOneShot(DeathSound);
                CanPlayAudioDeath = false;
            }
        }
        else if (bot_IsInvestigating)
        {
            Investigating();
            if (CanPlayAudioStopThere == true)
            {
                audioSource.PlayOneShot(Stop_There);
                CanPlayAudioStopThere = false;
            }
            CanPlayAudioWind = true;
        }
        else
        {
            Patrolling();
            CanPlayAudioStopThere = true;
            if (CanPlayAudioWind == true)
            {
                audioSource.PlayOneShot(Wind, 1.5f);
                CanPlayAudioWind = false;
            }
        }
    
        if (botWalkSpeed > 0.1 && myAgent.isStopped == false)
        {
            ani.SetBool("Walking", true);
        }
        else 
        {
            ani.SetBool("Walking", false);
        }


        if (Player_dead == true && bot_IsInvestigating == true && InAssassinBox == false)
        {
            SceneManager.LoadScene("Fail_Screen");
        }
    }

    private void Investigating()
    {
        if (!bot_AtDestination)
        {
            Move(botWalkSpeed + 4);
            myAgent.SetDestination(locationToCheck);
            bot_ResumeTime = botStartWaitTime;
        }
        
        if (myAgent.remainingDistance <= myAgent.stoppingDistance)
        {
            bot_AtDestination = true;
            Stop();

            if (bot_WaitTime <= 0)
            {
                bot_ResumeTime -= Time.deltaTime;

                if (bot_ResumeTime <= 0)
                {
                    bot_LookingBehind = false;
                    bot_IsInvestigating = false;
                    Move(botWalkSpeed);
                    bot_WaitTime = botStartWaitTime;
                    bot_IsPatrolling = true;
                    myAgent.SetDestination(patrolWaypoints
                        [botCurrentWaypointIndex].position);
                }
            }
            else
            {
                Stop();
                bot_WaitTime -= Time.deltaTime;
            }
        }
    }

    private void Patrolling()
    {
        bot_IsPatrolling = true;
        bot_IsInvestigating = false;
        bot_AtDestination = false;
        myAgent.SetDestination(patrolWaypoints[botCurrentWaypointIndex].position);
        //  Set the bots current destination to the next waypoint in Array

        if (myAgent.remainingDistance <= myAgent.stoppingDistance)
        {
            //  If the bot arrives to the waypoint position based on stop range
            //  then wait for a moment and go to the next

            if (faceNextLocation)  // only executed if Face Next Location is True, causes Bot to face next waypoint while waiting
            {
                int nextWaypoint = (botCurrentWaypointIndex + 1) % patrolWaypoints.Length; // location of waypoint after current destination
                Vector3 nextWayPointDirection = patrolWaypoints[nextWaypoint].position;

                StartCoroutine(RotateToFaceNextWayPoint(transform, nextWayPointDirection, botStartWaitTime / 2f));
            }
            else
            {
                StopCoroutine(RotateToFaceNextWayPoint(transform, new Vector3(0, 0, 0), 0f));
            }


            if (bot_WaitTime <= 0)   // Bot moves to next point in patrol pattern
            {
                NextPoint();
                Move(botWalkSpeed);
                bot_WaitTime = botStartWaitTime;
            }
            else                    // Bot pauses until timer elapsed
            {
                Stop();
                bot_WaitTime -= Time.deltaTime;
            }
        }
    }

    public void NextPoint()  // fetches next position in array and sets this to the NavMeshDestination
    {
        botCurrentWaypointIndex = (botCurrentWaypointIndex + 1) % patrolWaypoints.Length;
        myAgent.SetDestination(patrolWaypoints[botCurrentWaypointIndex].position);
    }

    void Stop()              // deactivates NavMeshAgent and sets Bot speed to 0 (used while pausing) 
    {
        myAgent.isStopped = true;
        myAgent.speed = 0;
    }

    void Move(float speed)   // reactivates NavMeshAgent and speed after being stopped
    {
        myAgent.isStopped = false;
        myAgent.speed = speed;
    }

    // Coroutine runs independently of Update(), used to Rotate Bot to face next waypoint (if setting active)
    public IEnumerator RotateToFaceNextWayPoint(Transform transform, Vector3 positionToLook, float timeToRotate)
    {
        var startRotation = transform.rotation;                  // the bots current rotation as a Quaternion
        var direction = positionToLook - transform.position;     // subtracts the target location from objects current position
        var finalRotation = Quaternion.LookRotation(direction);  // creates a rotation amount in Quaternions based on the calculated direction

        // convert and strip out X and Z Quaternion values so Bot only rotates around Y axis
        // bot sometimes tilts on short movement runs without this
        Vector3 finRotAsEuler = finalRotation.eulerAngles;   // stores finalRotation as a Vector3 containing Eulers
        finRotAsEuler = new Vector3(0, finRotAsEuler.y, 0);  // strips out and replaces X and Z values with 0's
        finalRotation = Quaternion.Euler(finRotAsEuler);     // converts the modified value back into a Quarternion

        var t = 0f;      // used to keep track of elapsed time
        while (t <= 1f)  // loops while t value is less than 1
        {
            t += Time.deltaTime / timeToRotate;  // increments t counter value by deltatime divided by time specified for rotation  
            transform.rotation = Quaternion.Lerp(startRotation, finalRotation, t);
            //performs the rotation gradually based on value of 't' timer using Lerp
            yield return null; // waits for next update to continue this while loop in the co-routine
        }
        transform.rotation = finalRotation; // ensures the objects final rotation is locked to 
    }

    public IEnumerator RotateToDirection(Transform transform, float timeToRotate)
    {
        //used to rotate bot 180 when suspicious
        var startRotation = transform.rotation;
        var DirectionToFace = new Vector3(0, transform.eulerAngles.y + 180, 0);
        var finalRotation = Quaternion.Euler(DirectionToFace);
        var t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / timeToRotate;
            transform.rotation = Quaternion.Lerp(startRotation, finalRotation, t);
            yield return null;
        }
        transform.rotation = finalRotation;
        bot_ResumeTime = botStartWaitTime;
    }

    // Assassin
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            ani.SetBool("Death", true);

            bot_IsPatrolling = false;
            bot_IsInvestigating = false;
            bot_AtDestination = false;

            Dead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InAssassinBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InAssassinBox = false;
        }
    }

    // player die
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Dead");

            Player_dead = true;
        }
        else
        {
            Player_dead = false;
        }
    }
}

