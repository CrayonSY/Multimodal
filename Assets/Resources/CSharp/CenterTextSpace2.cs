using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterTextSpace2 : MonoBehaviour
{
    [TextArea] public string[] scripts;
    [SerializeField] private GameObject _lily;

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
        
        _text = GetComponentInChildren<Text>();
        _text.text = scripts[_scriptNum];
        _lily.GetComponent<DetectMe>().SetActiveButton(false);
    }

    protected void FinishTalking()
    {
        isActive = false;
        _scriptNum = 0;
        gameObject.SetActive(isActive);
        _lily.GetComponent<DetectMe>().SetActiveButton(true);
    }

    protected void NextLine()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!isActive) return;

        _scriptNum++;
        if (_scriptNum < scripts.Length) _text.text = scripts[_scriptNum];
        else FinishTalking();
    }
    
}
