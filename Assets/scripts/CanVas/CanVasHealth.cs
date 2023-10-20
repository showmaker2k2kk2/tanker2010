using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanVasHealth : MonoBehaviour
{
    //public Canvas canvas;
    public Slider slidehealth;// cần phải có sldier bên ngoài để tham chiếu vào. sau đó mới có thể sử dụng
   
    public void sethealth(int curenthealth)
    {
        slidehealth.value = curenthealth;
    }    
    public void setUpMaxHealth(int mau_ban_dau)
    {
        slidehealth.maxValue=mau_ban_dau;
        //slidehealth.value = mau_ban_dau;
    }    
    
}
