using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{  
    public int Dame;
    public Doituong doituong;
    private float time = 1;
    private float CountTime = 0;
    //public phePhai chuThe;
   

    void Start()
    {
        CountTime = 0;

    }

    private void OnEnable()
    {
        
    }
    void Update()
    {
        CountTime += Time.deltaTime;
        if(CountTime>time)
        {
            gameObject.SetActive(false);
        }    
      
    }
    private void OnTriggerEnter(Collider collider_cua_doi_tuong)
    {      
        ItakeDame itakedame = collider_cua_doi_tuong.GetComponent<ItakeDame>();
        itakedame?.Takedame(Dame,doituong);
      gameObject.SetActive(false);

    }
       
}
public enum  Doituong
{
    player,
    enemy,
}