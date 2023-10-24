using UnityEngine;
using UnityEngine.UI;

public class FrameComponent : MonoBehaviour
{
    [SerializeField] private Image _img;
    
    private readonly Color _selectedColor = new Color(0.3658411f, 0.9245283f, 0.3096298f, 0.3960784f);
    private readonly Color _defaultColor = new Color(0, 0, 0, 0);

    public void ChangeColor(Toggle status)
    {
        _img.color = status.isOn ? _selectedColor : _defaultColor;
    }
}
