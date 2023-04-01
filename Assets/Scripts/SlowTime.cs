using UnityEngine;
using UnityEngine.UI;

public class SlowTime : MonoBehaviour
{
    public Image fireStatus;
    public float Timer;
    public float percentage;
    

    public void Awake()
    {
        fireStatus = GetComponent<Image>();
    }
    public void SlowShadowBar()
    {
        fireStatus.fillAmount += percentage/Timer * Time.deltaTime; 
    }
    
}
