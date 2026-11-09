using UnityEngine;
public interface IHealth
{
    event System.Action<float> OnHPPctChanged;
    event System.Action OnDied;
    event System.Action<Color> OnColorChange;
    void TakeDamage(int amount);
}
