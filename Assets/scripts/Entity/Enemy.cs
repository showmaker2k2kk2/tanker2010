using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy :Emity
{
    protected Enemy enemygannhat { get; }

    public Transform diemien;
    public Transform position_Gun;
    public GameObject bullet;
    public float speedbul = 50f;


    private Agent agent;
    public float tocdoxoay;


    public float Time_giua_cac_lan_tan_cong=1f;
    public float timeattackstart = 0f;
    public bool canattack = true;
  
    protected override Emity Muc_tieu_Gan_nhat=>GameManager.Instance.doi_tuong_tan_cong_cua_e.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).First();

    public override Doituong doituongcuascripts => Doituong.enemy;

    //public override phePhai chuThe => phePhai.enemy;

    NavMeshAgent mesh;

    bool ban_tank=true; 
    private float Range_attack_enemy = 40f;


    private void Awake()
    {
        mesh= GetComponent<NavMeshAgent>();
        agent= GetComponent<Agent>();
      
    }

    
    protected override void Start()
    {
        base.Start();
        
        //// kc tu enemy den doi tuong tan cong nho (pham vi tan con ) 
        //if (mucTieuGanNhat && kc_tu_enemy_den_target < Range_attack_enemy) 
        //{
        //    AttackTarget(mucTieuGanNhat);
        //} 
        Di_den_tru();

    }

    // Update is called once per frame
    void Update()
    {
        timeattackstart += Time.deltaTime;

      
        Emity mucTieuGanNhat = Muc_tieu_Gan_nhat;
        float kc_tu_enemy_den_target = Vector3.Distance(transform.position, mucTieuGanNhat.transform.position);
    
        if (kc_tu_enemy_den_target <= Range_attack_enemy)
        {
            //AttackTarget(mucTieuGanNhat);
            mesh.isStopped = true;       
            xoay(mucTieuGanNhat);

            if(timeattackstart>Time_giua_cac_lan_tan_cong)
            {
                tancong(mucTieuGanNhat);
                timeattackstart=0;
            }        
        }
        else
        {
        mesh.isStopped = false;
        }
        //if(kc_tu_enemy_den_target<=Range_attack_enemy)
        //{
        //    mesh.isStopped = true;
        //}    
    }
    protected void AttackTarget(Emity doi_tuong_tan_cong)
    {
        Nav_agent.isStopped = true;
        xoay(doi_tuong_tan_cong);


    }
    void xoay(Emity target)
    {
        Vector3 huongfoward=(target.transform.position-transform.position).normalized;
        Quaternion huong = Quaternion.LookRotation(huongfoward,Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, huong, agent.tocdoxoay * Time.deltaTime);
    }
  


    void tancong(Emity target)
    {
        GameObject Dan = Instantiate(bullet, position_Gun.position, Quaternion.identity);
        Rigidbody rigidbulet = Dan.GetComponent<Rigidbody>();
        Bulet bulle2 = Dan.GetComponent<Bulet>();
        rigidbulet.AddForce(transform.forward * speedbul, ForceMode.Impulse);
        Destroy(Dan, 2);
        bulle2.doituong = doituongcuascripts;
    }

    void Di_den_tru()
    {
        mesh.SetDestination(diemien.position);
    }    

    
}
