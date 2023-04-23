using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{
    [TextArea(1, 2)]
    [SerializeField] private string _decription;

    [SerializeField] protected PlayerStats PlayerStats;
    [SerializeField] protected int NeedToEnd;

    protected int CurrentValue = 0;
    private bool _isFinished = false;

    public string Description => _decription;
    public bool IsFinished => _isFinished;

    public UnityEvent<int, int> ValueChanged;
    public UnityEvent QuestEnded;

    private void Start()
    {
        ValueChanged?.Invoke(CurrentValue, NeedToEnd);
    }

    public void AddValue(int value)
    {
        CurrentValue += value;
        CheckValue();
        ValueChanged?.Invoke(CurrentValue, NeedToEnd);
    }

    protected void CheckValue()
    {
        if (CurrentValue >= NeedToEnd)
        {
            _isFinished = true;
            QuestEnded?.Invoke();
            CurrentValue = NeedToEnd;
        }
    }
}