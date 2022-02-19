using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject settingsMenu;
    public Slider testSlider;
    public Slider testSlider2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Keep Parameters Updated
    }

    public void UpdateParameters()
    {
        PlayerPrefs.SetFloat("mapSize", testSlider.value);
        PlayerPrefs.SetFloat("noiseScale", testSlider2.value);
        Debug.Log("Player Prefs Updated (Map Size): " + PlayerPrefs.GetFloat("mapSize"));
    }
}
