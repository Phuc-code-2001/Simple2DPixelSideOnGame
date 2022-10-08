using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
    private Slider slider;
    public Text OutputText;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (OutputText != null) OutputText.text = slider.value.ToString("0");
    }

    public void OnChangeSlideValue(float value)
    {
        if(OutputText != null)
        {
            OutputText.text = value.ToString("0");
        }
    }

}
