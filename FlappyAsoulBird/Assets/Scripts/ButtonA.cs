using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonA : MonoBehaviour
{
    public Text Text_W;
    public Button selfButton;
    public enum ButtonText { W,A,S,D };
    ButtonText buttonText;

    public int timerLimit;

    //private void Start()
    //{
    //    selfButton = transform.Find("Button").GetComponent<Button>();
    //}

    public void SkillOn()
    {
        GameMode.instance.ScoreUp();
        AudioManager.PlayRandomAudio(new string[]{AudioName.Ava1, AudioName.Ava2, AudioName.Ava3 });
        StartCoroutine(Skill());
    }

    IEnumerator Skill()
    {
        selfButton.interactable = false;
        while (timerLimit > 0)
        {
            Text_W.text = timerLimit.ToString();
            yield return new WaitForSeconds(1);
            timerLimit--;
            
        }
        timerLimit = Random.Range(2,5);

        buttonText = (ButtonText)Random.Range(0, 4);
        
        switch (buttonText)
        {
            case ButtonText.A:
                Text_W.text = "A";
                break;

            case ButtonText.W:
                Text_W.text = "W";
                break;

            case ButtonText.S:
                Text_W.text = "S";
                break;

            case ButtonText.D:
                Text_W.text = "D";
                break;
            default:
                break;
        }
        selfButton.interactable = true;
    }

    public bool JudgeStatus()
    {
        return selfButton.interactable;
    }

    public string GetButtonText()
    {
        return Text_W.text.ToLower();
    }
}
