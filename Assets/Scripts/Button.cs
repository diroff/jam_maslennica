using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public int number;
    public void GoToLevel()
    {
        SceneManager.LoadScene(number);
    }
    
}