using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    private ObjectPooler pooler;
    public Transform position_Gun;
    public GameObject bullet;

    public float speedbul;

    //public phePhai phephai;

    public Doituong doituongcuascripts;
    public float speedro;
    //public Canvas canvas;
    //public Joystick joy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }


    }
    private void FixedUpdate()
    {
        lookmouse();
        
    }
    void RoGun(Vector3 huong)
    {
        Quaternion huongro = Quaternion.LookRotation(huong, Vector3.up);//Vector3.up allway
                                                                        //tạo 1 quaternion mà chỉ định hướng nhìn từ một vị trí đến một điểm xác định.
        transform.rotation = Quaternion.Lerp(transform.rotation, huongro, speedro * Time.deltaTime);
    }
    void lookmouse()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    
         if(Physics.Raycast(ray,out hit))
            {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

    }
    void shoot()
    {
        GameObject bulet = ObjectPooler.Instance.spamObject("Bulet 1", position_Gun.position, Quaternion.identity);/*Instantiate(bullet, position_Gun.position, Quaternion.identity);*/

        Rigidbody rigidbulet = bulet.GetComponent<Rigidbody>();  
        rigidbulet.AddForce(transform.forward * speedbul, ForceMode.Impulse);
        Bulet butlet2= bulet.GetComponent<Bulet>();
        butlet2.doituong = doituongcuascripts;
       
    }
}
