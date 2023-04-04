using UnityEngine;
using UnityEngine.UI;

public class SizeLable : MonoBehaviour
{
    private Text m_labelText;

    private void Awake()
    {
        m_labelText = this.GetComponent<Text>();
    }
    
    public void SetValue(Vector3 size)
    {
        m_labelText.text = $"X: {size.x.ToString("F3")} Y: {size.y.ToString("F3")} Z: {size.z.ToString("F3")}";
    }
}