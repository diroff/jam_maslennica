using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<Quest> _quests;

    private void OnEnable()
    {
        for (int i = 0; i < _quests.Count; i++)
        {
            _quests[i].QuestEnded.AddListener(CompleteLevel);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _quests.Count; i++)
        {
            _quests[i].QuestEnded.RemoveListener(CompleteLevel);
        }
    }

    private void CompleteLevel()
    {
        int finishedCount = 0;

        for (int i = 0; i < _quests.Count; i++)
        {
            if (_quests[i].IsFinished)
            {
                _quests[i].QuestEnded.RemoveListener(CompleteLevel);
                finishedCount++;
            }
        }

        if (finishedCount == _quests.Count)
            Debug.Log("Win!");
    }
}
