using UnityEngine;
using UnityEngine.UI;

public class ShadowLevel : MonoBehaviour
{
    public Image fireStatus;
    public float Timer;
    
    public int number;
    public PlayerStats player;
    public Darkness dark;
    private Node _node;
    [SerializeField]private float _timer;
    public void Awake()
    {
        fireStatus = GetComponent<Image>();
    }
    

    public void Update()
    {
        fireStatus.fillAmount += 1.0f/Timer * Time.deltaTime;
        if((fireStatus.fillAmount >= 0.25f) && (fireStatus.fillAmount < 0.5f))
        {
            if (_timer >= 2f)
            {
                _timer = 0;
                dark.SetRandomDark();
            }
            _timer += Time.deltaTime;
            
        }

        if ((fireStatus.fillAmount >= 0.5f) && (fireStatus.fillAmount < 0.75f))
        {
            if (_timer >= 2f)
            {
                _timer = 0;
                dark.DestroyHouse();
            }
            _timer += Time.deltaTime;

        }

        if (fireStatus.fillAmount == 1f)
        {
            player.Dead(number);
        }
    }
}
