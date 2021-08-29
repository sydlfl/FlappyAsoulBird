using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonB : MonoBehaviour
{
    public Text Text_Q;
    public Button selfButton;
    ColumnController columnController;

    public int timerLimit=15;

    private void Start()
    {
        columnController = FindObjectOfType<ColumnController>();
    }
    public void SkillOn()
    {
        columnController.BellaSkill();
        AudioManager.PlayRandomAudio(new string[] { AudioName.Bella1, AudioName.Bella2, AudioName.Bella3 });
        StartCoroutine(Skill());
    }

    IEnumerator Skill()
    {
        selfButton.interactable = false;
        while (timerLimit > 0)
        {
            Text_Q.text = timerLimit.ToString();
            yield return new WaitForSeconds(1);
            timerLimit--;

        }
        timerLimit = 15;
        Text_Q.text = "Q";
        selfButton.interactable = true;
    }

    public bool JudgeStatus()
    {
        return selfButton.interactable;
    }

    public string GetButtonText()
    {
        return Text_Q.text.ToLower();
    }
}
