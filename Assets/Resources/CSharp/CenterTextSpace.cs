using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterTextSpace : MonoBehaviour
{
    private bool _hasBeenActive;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (!Input.GetMouseButtonUp(0)) return;
        if (_hasBeenActive)
        {
            gameObject.SetActive(false);
            _hasBeenActive = false;
        }
        _hasBeenActive = true;
    }
}
