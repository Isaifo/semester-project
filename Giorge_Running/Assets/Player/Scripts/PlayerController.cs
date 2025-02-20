using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _navigator;
    private Animator _playerAnim;
    private bool walking, running;
    private Vector3 dest;

    public int currentDestNum;

    public List<Transform> destinations;
    public float currentSpeed, maxSpeed, stamina;
    public Transform currentDest;

    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _navigator = GetComponent<NavMeshAgent>();
        walking = true;
        currentDestNum = 0;
        currentDest = destinations[0];
    }
    void Update()
    {
        dest = currentDest.position;
        _navigator.destination = dest;
        VerifyDestination();
    }

    public void VerifyDestination(){
        if (_navigator.remainingDistance <= _navigator.stoppingDistance)
        {
            if(currentDestNum < destinations.Count){
                currentDestNum += 1;
                currentDest = destinations[currentDestNum];
            }
        }
    }
}