using TMPro;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private Quest _quest;
    [SerializeField] private TextMeshProUGUI _progressText;

    private void OnEnable()
    {
        _quest.ValueChanged.AddListener(ShowQuestProgress);
        _quest.QuestEnded.AddListener(EndQuestStyle);
    }

    private void OnDisable()
    {
        _quest.ValueChanged.RemoveListener(ShowQuestProgress);
    }

    private void ShowQuestProgress(int currentValue, int needValue)
    {
        _progressText.text = $"{_quest.Description}{currentValue}/{needValue}";
    }

    private void EndQuestStyle()
    {
        _progressText.fontStyle = FontStyles.Strikethrough;
        _quest.ValueChanged.RemoveListener(ShowQuestProgress);
    }
}