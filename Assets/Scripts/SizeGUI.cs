using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SizeGUI : MonoBehaviour
{
    [SerializeField, Header("Input")] private SizeInputValue m_xInput;
    [SerializeField] private SizeInputValue m_yInput;
    [SerializeField] private SizeInputValue m_zInput;

    public UnityEvent<Vector3> OnSizeChange;

    public Vector3 Value
    {
        get; private set;
    }

    public void OnEnable()
    {
        m_xInput.OnValueChanged.AddListener(UpdateSize);
        m_yInput.OnValueChanged.AddListener(UpdateSize);
        m_zInput.OnValueChanged.AddListener(UpdateSize);
    }

    public void OnDisable()
    {
        m_xInput.OnValueChanged.RemoveListener(UpdateSize);
        m_yInput.OnValueChanged.RemoveListener(UpdateSize);
        m_zInput.OnValueChanged.RemoveListener(UpdateSize);
    }

    public Vector3 GetSize(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }

    public void UpdateSize()
    {
        var (x, y, z) = (m_xInput.Value, m_yInput.Value, m_zInput.Value);
        var size = this.GetSize(x, y, z);

        this.Value = size;

        this.OnSizeChange?.Invoke(size);
    }
}
