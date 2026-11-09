using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPBar : MonoBehaviour
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        GetComponent<IHealth>().OnHPPctChanged += HandleHPPctChanged;
        GetComponent<IHealth>().OnColorChange += HandleColorChange;
    }

    private void HandleHPPctChanged(float pct)
    {
        _slider.value = pct;
    }

    private void HandleColorChange(Color color)
    {
        _slider.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>().color = color;
    }
}
