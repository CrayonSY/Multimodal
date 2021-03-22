using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CareyJewitt : Talk
{
    private string badChoiseResponses = "No... That's not what you wanna express!\nAre you really Shinnosuke?";
    private readonly int[] _eventTrigerIds = { 8 };
    [SerializeField] private GameObject _centerTextSpace;
    [SerializeField] private List<string[]> _adviceScripts = new List<string[]>();
    [TextArea] [SerializeField] private string[] _advice0;
    private int _adviceNum;

    private int _displayOptionId;
    private bool _pressedCorrectOption;
    private bool _finishedfirstTalk;

    
    void Start()
    {
        _adviceScripts.Add(_advice0);
    }

    void Update()
    {
        NextLine();
    }

    private void NextLine()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!isActive) return;
        _displayOptionId = 0;
        foreach (int e in _eventTrigerIds)
        {
            if (_scriptNum == e) DisplayOptions(_displayOptionId);
            else ReadNextLine();
        }
    }

    public void CorrectOptionPressed()
    {
        ReadNextLine();
        _options[_displayOptionId].SetActive(false);
    }
    public void IncorrectOptionPressed()
    {
        _options[_displayOptionId].SetActive(false);
        _text.text = badChoiseResponses;
        _scriptNum--;
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
        if (_finishedfirstTalk) _adviceNum++;
        else
        {
            _centerTextSpace.SetActive(true);
            _centerTextSpace.GetComponentInChildren<Text>().text = "Shinnosuke started learning game development.";
        }
        if (_adviceNum == _adviceScripts.Count) _adviceNum = 0;
        _finishedfirstTalk = true;
    }

    
    public void OnClick()
    {
        if (_finishedfirstTalk) scripts = _adviceScripts[_adviceNum];
        base.OnClick();
    }
    
}
