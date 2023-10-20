using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{

    public float speed;
    public float tocdoxoay;

    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
    }

    
    void Update()
    {
      
    }
     public void Movehuong(Vector3 huong)
    {
        xoay(huong);
    
        agent.Move(transform.forward * speed * Time.deltaTime);
    }
     public void xoay(Vector3 a)
    {
        Quaternion huongnhin = Quaternion.LookRotation(a, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, huongnhin, tocdoxoay * Time.deltaTime);
    }

}
