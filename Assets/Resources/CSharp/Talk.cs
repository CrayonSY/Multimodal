using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    [SerializeField] protected GameObject[] _options;
    [SerializeField] protected GameObject _nextTarget;
    [TextArea] public string[] scripts;

    protected Text _text;
    public bool isActive;
    protected int _scriptNum;

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

    protected void FinishTalking()
    {
        isActive = false;
        _scriptNum = 0;
        GameObject _textSpace = GameObject.FindWithTag("ScreenCanvas").transform.Find("TextSpace").gameObject;
        _textSpace.SetActive(isActive);
        transform.parent.GetComponent<DetectMe>().SetActiveButton(true);
        if (_nextTarget != null) GameObject.FindWithTag("Player").GetComponent<NextDirection>().goal = _nextTarget;
    }

    protected void NextLine()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!isActive) return;

        _scriptNum++;
        if (_scriptNum < scripts.Length) _text.text = scripts[_scriptNum];
        else FinishTalking();
    }

    protected void DisplayOptions(int id)
    {
        _options[id].SetActive(true);
    }
}
