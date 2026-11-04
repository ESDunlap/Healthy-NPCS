using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider _slider;

    private void Start()
    {
        GetComponentInParent<IHealth>().OnHPPctChanged += HandleHPPctChanged;
    }

    private void HandleHPPctChanged(float pct)
    {
        _slider.value = pct;
    }
}
