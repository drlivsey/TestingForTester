using UnityEngine;
using UnityEngine.UI;

public class ColorLable : MonoBehaviour
{
    private Text m_labelText;

    private void Awake()
    {
        m_labelText = this.GetComponent<Text>();
    }
    
    public void SetValue(Color color)
    {
        m_labelText.text = $"A: {(int)(color.r * 255)} R: {(int)(color.g * 255)} G: {(int)(color.b * 255)} B: {(int)(color.a * 255)}";
    }
}