using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonE : MonoBehaviour
{
    public Text Text_C;
    public Button selfButton;
    public PlayerCharacter player;

    public int timerLimit = 1;

    void Start()
    {
        player = FindObjectOfType<PlayerCharacter>();
    }

    public void SkillOn()
    {
        player.QueenSkill();
        GameMode.instance.ChangeScale(2f);
        AudioManager.PlayRandomAudio(new string[] { AudioName.Elieen1, AudioName.Elieen2, AudioName.Elieen3 });
        StartCoroutine(Skill());
    }

    IEnumerator Skill()
    {
        selfButton.interactable = false;
        while (timerLimit > 0)
        {
            Text_C.text = timerLimit.ToString();
            yield return new WaitForSeconds(1);
            timerLimit--;

        }
        timerLimit = 1;
        Text_C.text = "C";
        selfButton.interactable = true;
    }

    public bool JudgeStatus()
    {
        return selfButton.interactable;
    }

    public string GetButtonText()
    {
        return Text_C.text.ToLower();
    }
}
