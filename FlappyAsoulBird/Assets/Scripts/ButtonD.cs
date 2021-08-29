using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonD : MonoBehaviour
{
    public Text Text_Z;
    public Button selfButton;
    public PlayerCharacter player;
    public int timerLimit = 1;

    void Start()
    {
        player = FindObjectOfType<PlayerCharacter>();
    }


    public void SkillOn()
    {
        player.DianaSkill();
        GameMode.instance.ChangeScale(0.5f);
        AudioManager.PlayRandomAudio(new string[] { AudioName.Diana1, AudioName.Diana2,AudioName.Diana3 });
        StartCoroutine(Skill());
    }

    IEnumerator Skill()
    {
        selfButton.interactable = false;
        while (timerLimit > 0)
        {
            Text_Z.text = timerLimit.ToString();
            yield return new WaitForSeconds(1);
            timerLimit--;

        }
        timerLimit = 1;
        Text_Z.text = "Z";
        selfButton.interactable = true;
    }

    public bool JudgeStatus()
    {
        return selfButton.interactable;
    }

    public string GetButtonText()
    {
        return Text_Z.text.ToLower();
    }
}
