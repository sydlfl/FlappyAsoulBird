using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanelController : MonoBehaviour
{
    GameObject buttonPanel;
    ButtonA buttonA;
    ButtonB buttonB;
    ButtonC buttonC;
    ButtonD buttonD;
    ButtonE buttonE;
    // Start is called before the first frame update
    void Start()
    {
        buttonA = FindObjectOfType<ButtonA>();
        buttonB = FindObjectOfType<ButtonB>();
        buttonC = FindObjectOfType<ButtonC>();
        buttonD = FindObjectOfType<ButtonD>();
        buttonE = FindObjectOfType<ButtonE>();
    }

    // Update is called once per frame
    void Update()
    {
         if(buttonA.JudgeStatus() && Input.GetKeyDown(buttonA.GetButtonText()))
        {
            buttonA.SkillOn();
        }

        if (buttonB.JudgeStatus() && Input.GetKeyDown(buttonB.GetButtonText())){
            buttonB.SkillOn();
        }

        if (buttonC.JudgeStatus() && Input.GetKeyDown(buttonC.GetButtonText()))
        {
            buttonC.SkillOn();
        }

        if (buttonD.JudgeStatus() && Input.GetKeyDown(buttonD.GetButtonText()))
        {
            buttonD.SkillOn();
        }

        if (buttonE.JudgeStatus() && Input.GetKeyDown(buttonE.GetButtonText()))
        {
            buttonE.SkillOn();
        }
    }
}
 