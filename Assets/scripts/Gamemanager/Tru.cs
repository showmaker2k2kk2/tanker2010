using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tru : Emity
{
 
    public Transform position_Gun;
    public GameObject bullet;
    public float speedbul = 50f;



    public float Time_giua_cac_lan_tan_cong = 1f;
    public float timeattackstart = 0f;


    public float speedRo;
    public override Doituong doituongcuascripts => Doituong.player;
    protected  Enemy enemygannhat => GameManager.Instance.enemies.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).First();


    private Vector3 posi;
    private float Range_attack_Tower= 40f;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        timeattackstart += Time.deltaTime;

        Enemy mucTieuGanNhat = enemygannhat;
        Debug.Log("muc tieu la "+ enemygannhat.name);
        float kc_tu_tru_den_target = Vector3.Distance(transform.position, mucTieuGanNhat.transform.position);
        if(kc_tu_tru_den_target<Range_attack_Tower)
        {
            Debug.Log("enemy den tru");
            Rotation(enemygannhat);
            if(timeattackstart>Time_giua_cac_lan_tan_cong)
            {

            tancong(enemygannhat);
                timeattackstart = 0;
            }    
        }    

    }
        void Rotation(Emity emity)
        {
            Quaternion dir = Quaternion.LookRotation(emity.transform.position-transform.position, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, dir, speedRo * Time.deltaTime);
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

}
