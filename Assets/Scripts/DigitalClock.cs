using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    [SerializeField] private TextMeshPro timeText;

    private void Start()
    {
        StartCoroutine(UpdateClockCoroutine());
    }

    private IEnumerator UpdateClockCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            timeText.text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
    

}
