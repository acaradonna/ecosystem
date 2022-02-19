using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
{
    public Slider sliderUI;
    public Text text;
    private Text textSliderValue;

    void Start()
    {
        //textSliderValue = GetComponent<Text>();
        //sliderUI = GetComponent<Slider>();
        ShowSliderValue();
    }

    private void Update()
    {
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        string sliderMessage = (sliderUI.value.ToString());
        text.text = sliderMessage;
    }
}