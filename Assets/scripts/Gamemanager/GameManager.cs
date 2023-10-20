using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance=null;


    public List<Enemy> enemies;

    public List<Emity> doi_tuong_tan_cong_cua_e;

    private Transform pointcreateBoss;
   
    private   Enemy enemy;

    void Start()
    {
    
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
    }
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.L))
        {

        PointCreateBoss();
        }    
    }
    void PointCreateBoss()
    {
        if(enemy!=null)
        {

       Enemy bos = Instantiate(enemy, pointcreateBoss.position, Quaternion.identity);
        }    
    }
    private void OnDestroy()
    {
        Instance = null;
    }
}
