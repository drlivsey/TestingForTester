using UnityEngine;
using UnityEngine.UI;

public class RotationLable : MonoBehaviour
{
    private Text m_labelText;

    private void Awake()
    {
        m_labelText = this.GetComponent<Text>();
    }
    
    public void SetValue(Vector3 rotation)
    {
        m_labelText.text = $"X: {rotation.x.ToString("F3")} Y: {rotation.y.ToString("F3")} Z: {rotation.z.ToString("F3")}";
    }
}