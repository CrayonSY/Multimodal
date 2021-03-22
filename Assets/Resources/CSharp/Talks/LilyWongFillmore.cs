using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LilyWongFillmore : Talk
{
    [SerializeField] private GameObject _centerTextSpace;
    

    void Update()
    {
        NextLine();
    }

    private void NextLine()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!isActive) return;
        ReadNextLine();
    }
    
    private void ReadNextLine()
    {
        _scriptNum++;
        if (_scriptNum < scripts.Length) _text.text = scripts[_scriptNum];
        else FinishTalking();
    }

    private void FinishTalking()
    {
        base.FinishTalking();
        transform.parent.GetComponent<DetectMe>().SetActiveButton(false);
        _centerTextSpace.SetActive(true);
        _centerTextSpace.GetComponentInChildren<Text>().text = "Shinnosuke vowed to take the long view with programming.";
        _centerTextSpace.GetComponent<CenterTextSpace2>().OnClick();
    }

}