using UnityEngine;

public class MoneyQuest : Quest
{
    private void OnEnable()
    {
        PlayerStats.CountOfMoneyChanged.AddListener(SetValue);
    }

    private void OnDisable()
    {
        PlayerStats.CountOfMoneyChanged.RemoveListener(SetValue);
    }

    public void SetValue(int value)
    {
        CurrentValue = value;
        CheckValue();
        ValueChanged?.Invoke(CurrentValue, NeedToEnd);
    }
}
