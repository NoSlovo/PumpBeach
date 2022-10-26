using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class BonfireLog : MonoBehaviour
{
    private MeshRenderer _mesh;

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    public void MeshOff() => _mesh.enabled = false;

    public void MeshOn() => _mesh.enabled = true;
}
