using UnityEngine;

public class Figure : MonoBehaviour
{
    public void SetColor(Color color)
    {
        var renderer = this.GetComponent<MeshRenderer>();
        var material = renderer.material;

        material.color = color;
    }

    public void SetSize(Vector3 size)
    {
        this.transform.localScale = size;
    }

    public void SetRotation(Vector3 rotation)
    {
        this.transform.localEulerAngles = rotation;
    }
}
