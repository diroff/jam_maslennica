using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blin : MonoBehaviour
{
    public Text blinTaken;

    public void Update()
    {
        blinTaken.text = PlayerStats.Money.ToString();
    }
}
