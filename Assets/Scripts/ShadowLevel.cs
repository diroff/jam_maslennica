using UnityEngine;
using UnityEngine.UI;

public class ShadowLevel : MonoBehaviour
{
    public Image fireStatus;
    public float Timer;
    
    public int number;
    public PlayerStats player;

    public void Awake()
    {
        fireStatus = GetComponent<Image>();
    }
    

    public void Update()
    {
        fireStatus.fillAmount -= 1.0f/Timer * Time.deltaTime;
        if(fireStatus.fillAmount == 0f)
        {
            player.Dead(number);
        }
    }
}
