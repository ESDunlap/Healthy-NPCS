using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider _slider;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        GetComponent<IHealth>().OnHPPctChanged += HandleHPPctChanged;
    }

    private void HandleHPPctChanged(float pct)
    {
        Debug.Log("This Runs");
        Debug.Log(pct);
        _slider.value = pct;
    }
}
