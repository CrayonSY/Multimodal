using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    [TextArea] public string[] scripts;

    private Text _text;
    public bool isActive;
    private int _scriptNum;

    void Update()
    {
        NextLine();
    }

    public void OnClick()
    {
        isActive = true;
        _scriptNum = 0;

        GameObject _textSpace = GameObject.FindWithTag("ScreenCanvas").transform.Find("TextSpace").gameObject;
        _textSpace.SetActive(isActive);
        _text = _textSpace.GetComponentInChildren<Text>();
        _text.text = scripts[_scriptNum];
        transform.parent.GetComponent<DetectMe>().SetActiveButton(false);
    }

    private void FinishTalking()
    {
        isActive = false;
        _scriptNum = 0;
        GameObject _textSpace = GameObject.FindWithTag("ScreenCanvas").transform.Find("TextSpace").gameObject;
        _textSpace.SetActive(isActive);
        transform.parent.GetComponent<DetectMe>().SetActiveButton(true);
    }

    private void NextLine()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!isActive) return;
        _scriptNum++;
        if (_scriptNum < scripts.Length) _text.text = scripts[_scriptNum];
        else FinishTalking();
    }
}
