using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 destination;
    Vector3 lastLoc;
    Vector3 dir;
    NavMeshAgent navMeshAgent;

    public bool lookAt;
    public bool seen;
    public bool isPatrolling;
    private float time;
    private float patrollingTime;

    private float bounds;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        bounds = 34.5f;
    }

    private void Update()
    {
        time += Time.deltaTime;
        patrollingTime += Time.deltaTime;
        
        dir = player.transform.position - transform.position;
        //print(time);
        // print(seen);
        //print(Vector3.Dot(transform.forward.normalized, dir.normalized));
        //print((transform.position - lastLoc).magnitude);

        if(Vector3.Dot(transform.forward.normalized, dir.normalized) > 0.8f)
        {
            lookAt = true;
        }
        else
        {
            lookAt = false;
        }

        if (lookAt)
        {
            Ray ray = new Ray(transform.position, dir);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    destination = player.transform.position;
                    lastLoc = destination;
                    SetDestination();
                    time = 0;
                    seen = true;
                }
                else
                {
                    //seen = false;
                }
            }
        }
        else if (time > 1f && (transform.position - lastLoc).magnitude < 0.5f)
        {
            seen = false;
            time = 0;
            isPatrolling = false;
        }


        /*
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            print("A");
            //print(hit.collider.tag);
            if (hit.collider.tag == "Player")
            {
                time = 0;
                seen = true;
            }
        }
        else if (time > 5f)
        {
            seen = false;
            time = 0;
        }
        */

        if (seen)
        {
            //destination = player.transform.position;
            //SetDestination();
        }
        else
        {
            if (!isPatrolling)
            {
                destination = new Vector3(UnityEngine.Random.Range(-bounds, bounds), 0, UnityEngine.Random.Range(-bounds, bounds));
                isPatrolling = true;
                patrollingTime = 0;
                SetDestination();
            }
            else
            {
                if (patrollingTime > 5)
                {
                    isPatrolling = false;
                }
            }
        }

        /*
        if (Input.GetMouseButtonUp(0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(transform.position, player.transform.position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                print(hit.collider.tag);
                if(hit.collider.tag == "Player" && time > 5)
                {
                    destination = hit.point;
                    SetDestination();
                    time = 0;
                }
            }
        }
        */
    }

    private void SetDestination()
    {
        if(destination != null)
        {
            ///Vector3 targetVector = destination;
            navMeshAgent.SetDestination(destination);
        }
        else
        {

        }
    }
}
