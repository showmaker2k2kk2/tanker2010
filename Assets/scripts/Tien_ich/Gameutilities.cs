using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Gameutilities
{ 
    public static void Decall(this MonoBehaviour mono,float time,Action phuong_thuc_truyen_vao)
    {
        mono.StartCoroutine(IEDecall(time, phuong_thuc_truyen_vao));
    }
    public static IEnumerator IEDecall(float time,Action Phuong_thuc_truyen_vao)
    {
        yield return new WaitForSeconds(time);
        Phuong_thuc_truyen_vao?.Invoke();
    }

}
