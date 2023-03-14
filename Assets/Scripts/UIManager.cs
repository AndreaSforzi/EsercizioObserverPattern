using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questNameTextMesh;
    [SerializeField] TextMeshProUGUI questDescriptionTextMesh;


    [SerializeField] TextMeshProUGUI currentEXPTextMesh;
    [SerializeField] TextMeshProUGUI nextLevelEXPTextMesh;
    [SerializeField] TextMeshProUGUI levelTextMesh;

    [SerializeField] TextMeshProUGUI questCompletedMessageTextMesh;
    [SerializeField] TextMeshProUGUI levelUpMessageTextMesh;

    private void Start()
    {
        Player.Instance.OnLevelChanged += NewLevel;
        Player.Instance.OnEXPChanged += EXPChanged;

        currentEXPTextMesh.text = Player.Instance.EXP.ToString();
        nextLevelEXPTextMesh.text = Player.Instance.NextLvlEXPRequired.ToString();
        levelTextMesh.text = Player.Instance.Lvl.ToString();

        questNameTextMesh.text = $"From {Player.Instance.Lvl} to {Player.Instance.levelToReachForQuest}";
        questDescriptionTextMesh.text = $"Reach level {Player.Instance.levelToReachForQuest}";
    }

    private void QuestChanged()
    {
        gameObject.GetComponent<Animator>().Play("QuestCompletedMessage");

        Player.Instance.levelToReachForQuest += 3;

        questNameTextMesh.text = $"From {Player.Instance.Lvl} to {Player.Instance.levelToReachForQuest}";
        questDescriptionTextMesh.text = $"Reach level {Player.Instance.levelToReachForQuest}";
    }

    private void EXPChanged(int newEXP)
    {
        currentEXPTextMesh.text = newEXP.ToString();

        if (Player.Instance.EXP >= Player.Instance.NextLvlEXPRequired)
        {
            Player.Instance.Lvl++;
        }
    }

    private void NewLevel(int newLevel)
    {
        levelTextMesh.text = newLevel.ToString();

        levelUpMessageTextMesh.text = $"Level {newLevel} reached!";
        gameObject.GetComponent<Animator>().Play("LevelUpMessage");

        Player.Instance.EXP = 0;

        Player.Instance.NextLvlEXPRequired += 3;
        nextLevelEXPTextMesh.text = Player.Instance.NextLvlEXPRequired.ToString() ;

        if (Player.Instance.Lvl >= Player.Instance.levelToReachForQuest)
            QuestChanged();
    }


}
