using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public  class Player :Emity
{
    protected override Emity Muc_tieu_Gan_nhat => GameManager.Instance.enemies.OrderBy(e=>Vector3.Distance(transform.position,e.transform.position)).First();

    public override Doituong doituongcuascripts => Doituong.player;
    //public override phePhai chuThe => phePhai.player;

    private Agent _agent;
    protected NavMeshAgent navMesh;

    private void Awake()
    {
        _agent = GetComponent<Agent>();
        navMesh = GetComponent<NavMeshAgent>();
        

}
protected override void Start()
    {
        base.Start();
       
    }

   
    void Update()
    {
        float ho = Input.GetAxisRaw("Horizontal");
        float Ve = Input.GetAxisRaw("Vertical");


        Vector3 huongbanphim = new Vector3(ho, 0, Ve);

        if (huongbanphim != Vector3.zero)
        {

            _agent.Movehuong(huongbanphim);

        }


    }
   
}
