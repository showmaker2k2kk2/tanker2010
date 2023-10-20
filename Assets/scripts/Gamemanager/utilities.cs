using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utilities : MonoBehaviour
{
    public Transform pointcreateBoss;

    public Enemy enemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {

            PointCreateBoss();
        }
    }
    void PointCreateBoss()
    {
        if (enemy != null)
        {

            Enemy bos = Instantiate(enemy, pointcreateBoss.position, Quaternion.identity);
        }
    }
}
