using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Security.Cryptography;

public abstract class Emity : MonoBehaviour,ItakeDame
{
  protected virtual Emity Muc_tieu_Gan_nhat { get;}

    public abstract Doituong doituongcuascripts {  get;}
    //public abstract phePhai chuThe { get; }


    private Agent agent;
    public CanVasHealth canHealth;
    public int starthealth = 100;
    public int curenthealth;
    protected NavMeshAgent Nav_agent;




   

    protected virtual void Start()
    {
        curenthealth = starthealth;
        canHealth.setUpMaxHealth(curenthealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Takedame(int dame)
    {
        //if (phePhai == chuThe) return;
        curenthealth = curenthealth - dame;
        canHealth.sethealth(curenthealth);
        if (curenthealth <= 0)
        {
            Death();

        }


    }
    private void Death()
    {
        this.Decall(2f, () =>
        {
            Destroy(gameObject);
        }
        );

    }
    public void Takedame(int dame, Doituong doi_tuongBuletgoiDetakedame)
    {
        if (doi_tuongBuletgoiDetakedame == doituongcuascripts) return;
        curenthealth = curenthealth - dame;
        canHealth.sethealth(curenthealth);
        if (curenthealth <= 0)
        {
            Death();

        }
    }
}
