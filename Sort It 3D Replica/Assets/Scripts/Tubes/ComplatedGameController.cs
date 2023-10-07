using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplatedGameController : MonoBehaviour
{
    public GameObject[] Tubes;
    public GameObject WinnButton;

    private bool _tubescomplatedbool;
    private int _tubecontrolintex = 0;

    public void CheckUpCompalatedGame()
    {
        _tubecontrolintex = 0;
        for (int i = 0; i < Tubes.Length; i++)
        {
            Tubes[i].GetComponent<TubeController>().CheckUpTube();

            if ( Tubes[i].GetComponent<TubeController>().Complated == true)
            {
                _tubecontrolintex++;
            }
        }

        if (_tubecontrolintex == Tubes.Length)
        {
            WinnButton.SetActive(true);
        }
    }
}
