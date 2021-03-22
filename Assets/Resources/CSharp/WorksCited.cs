using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorksCited : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    public void OnClick()
    {
        _menu.SetActive(!_menu.active);
    }

}
