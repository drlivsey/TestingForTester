using UnityEngine;
using UnityEngine.Events;

public class RotationGUI : MonoBehaviour
{
    [SerializeField, Header("Input")] private RotationInputValue m_xInput;
    [SerializeField] private RotationInputValue m_yInput;
    [SerializeField] private RotationInputValue m_zInput;

    public UnityEvent<Vector3> OnRotationChange;

    public Vector3 Value
    {
        get; private set;
    }

    public void OnEnable()
    {
        m_xInput.OnValueChanged.AddListener(UpdateRotation);
        m_yInput.OnValueChanged.AddListener(UpdateRotation);
        m_zInput.OnValueChanged.AddListener(UpdateRotation);
    }

    public void OnDisable()
    {
        m_xInput.OnValueChanged.RemoveListener(UpdateRotation);
        m_yInput.OnValueChanged.RemoveListener(UpdateRotation);
        m_zInput.OnValueChanged.RemoveListener(UpdateRotation);
    }

    public Vector3 GetRotation(float x, float y, float z)
    {
        return new Vector3(y, x, z);
    }

    public void UpdateRotation()
    {
        var (x, y, z) = (m_xInput.Value, m_yInput.Value, m_zInput.Value);
        var rotation = this.GetRotation(x, z, y);

        this.Value = rotation;

        this.OnRotationChange?.Invoke(rotation);
    }
}