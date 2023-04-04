using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ColorGUI : MonoBehaviour
{
    [SerializeField, Header("Input")] private ColorInputValue m_rInput;
    [SerializeField] private ColorInputValue m_gInput;
    [SerializeField] private ColorInputValue m_bInput;
    [SerializeField] private ColorInputValue m_aInput;
    [SerializeField, Header("Indicator")] private Image m_indicator;

    public Color Value
    {
        get; private set;
    }

    public UnityEvent<Color> OnColorChanged;

    public void OnEnable()
    {
        m_aInput.OnValueChanged.AddListener(UpdateColor);
        m_rInput.OnValueChanged.AddListener(UpdateColor);
        m_gInput.OnValueChanged.AddListener(UpdateColor);
        m_bInput.OnValueChanged.AddListener(UpdateColor);
    }

    public void OnDisable()
    {
        m_aInput.OnValueChanged.RemoveListener(UpdateColor);
        m_rInput.OnValueChanged.RemoveListener(UpdateColor);
        m_gInput.OnValueChanged.RemoveListener(UpdateColor);
        m_bInput.OnValueChanged.RemoveListener(UpdateColor);
    }

    public Color GetColor(float a, float r, float g, float b)
    {
        return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }

    private void UpdateColor()
    {
        var (a, r, g, b) = (m_aInput.Value, m_rInput.Value, m_gInput.Value, m_bInput.Value);
        var color = this.GetColor(a, r, g, b);

        m_indicator.color = color;
        this.Value = color;

        this.OnColorChanged?.Invoke(color);
    }
}
