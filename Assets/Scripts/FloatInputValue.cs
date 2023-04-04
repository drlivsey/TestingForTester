using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FloatInputValue : MonoBehaviour
{
    private InputField m_targetInput;

    public float Value 
    {
        get; private set;
    }

    public UnityEvent OnValueChanged;

    private void Awake()
    {
        m_targetInput = this.GetComponent<InputField>();
    }

    private void OnEnable()
    {
        m_targetInput.onValueChanged.AddListener(UpdateValue);
    }

    private void OnDisable()
    {
        m_targetInput.onValueChanged.RemoveListener(UpdateValue);
    }

    public void UpdateValue(string value)
    {
        this.Value = Convert.ToSingle(value);
        this.OnValueChanged?.Invoke();
    }
}
