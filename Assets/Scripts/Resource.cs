using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public float Timer;
    public float Counter;
    public int moneyGiven;
    // Update is called once per frame
    void Update()
    {
        if(Counter >= Timer)
        {
            PlayerStats.Money += moneyGiven;
            Counter = 0;
        }
        Counter += Time.deltaTime;
    }
}
