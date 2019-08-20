using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{

    [SerializeField]
    private Text _sliderNum = null;

    [SerializeField]
    private Slider _slider = null;

    public void UpdateValue()
    {
        _sliderNum.text = " " + _slider.value;
    }
}
