using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 10;
    

    private void Start()
    {
        Money = startMoney;
    }

    public void Dead(int number)
    {
        SceneManager.LoadScene(number);
    }
}
