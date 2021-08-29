using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonC : MonoBehaviour
{
    public Text Text_E;
    public Button selfButton;
    ColumnController columnController;

    public int timerLimit = 4;

    private void Start()
    {
        columnController = FindObjectOfType<ColumnController>();
    }

    public void SkillOn()
    {
        columnController.CarolSkill();
        AudioManager.PlayRandomAudio(new string[] { AudioName.Carol1, AudioName.Carol2 });
        StartCoroutine(Skill());
    }

    IEnumerator Skill()
    {
        selfButton.interactable = false;
        while (timerLimit > 0)
        {
            Text_E.text = timerLimit.ToString();
            yield return new WaitForSeconds(1);
            timerLimit--;

        }
        timerLimit = 4;
        Text_E.text = "E";
        selfButton.interactable = true;
    }

    public bool JudgeStatus()
    {
        return selfButton.interactable;
    }

    public string GetButtonText()
    {
        return Text_E.text.ToLower();
    }
}
