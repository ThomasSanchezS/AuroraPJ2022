using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    private bool chasing;
    public float distanceToChase = 10f, distanceToLose = 15f, distanceToStop;

    public Vector3 targetPoint, startPoint;

    public NavMeshAgent agent;

    public float keepChasingTime = 5f;
    private float chaseCounter;


    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        targetPoint.y = transform.position.y;

        if(!chasing){
            if(Vector3.Distance(transform.position, targetPoint)< distanceToChase){
                chasing = true;
            }

            if(chaseCounter > 0){
                chaseCounter -= Time.deltaTime;
                if(chaseCounter <= 0){
                    agent.destination = startPoint;
                }
            }
        }
        else{
            //transform.LookAt(targetPoint);

            //theRB.velocity = transform.forward * moveSpeed;

            agent.destination = targetPoint;

            if(Vector3.Distance(transform.position, targetPoint) > distanceToLose){
                chasing = false;

                chaseCounter = keepChasingTime;
            }
        }
    }

     void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") {
            Debug.Log("*Lo manosea");
			PlayerHealthController health = other.gameObject.GetComponent<PlayerHealthController>();
            health.DamagePlayer(5);
		}
    }
}
