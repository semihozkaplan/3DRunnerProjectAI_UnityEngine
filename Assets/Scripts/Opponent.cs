using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{

    public NavMeshAgent OpponentAgent;
    public GameObject Target;
    Vector3 OpponentStartPos;
    public GameObject speedBoostIcon;

    void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();
        OpponentStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoostIcon.SetActive(false);
    }

    void Update()
    {
        OpponentAgent.SetDestination(Target.transform.position);

        if (GameManager.instance.isGameOver)
        {
            OpponentAgent.speed = 0f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.collider.CompareTag("obstacle"))
        {
            transform.position = OpponentStartPos;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("speedboost"))
        {
            OpponentAgent.speed += 3f;
            speedBoostIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }

    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {

        yield return new WaitForSeconds(2f);
        OpponentAgent.speed -= 3f;
        speedBoostIcon.SetActive(false);

    }

}
