using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
public class SpheresMonitor : MonoBehaviour
{
	private Material[] _materials;
	public GameObject[] Centers;
	public float Radius = 1f;

    void Start()
    {
	}

    void Update()
    {
		if (Centers == null || Centers.Length == 0)
			return;
		if (_materials == null || _materials.Length == 0)
			_materials = GetComponent<MeshRenderer>().sharedMaterials;
		foreach (var material in _materials)
		{
			for (int i = 0; i < Centers.Length; i++)
			{
				GameObject center = Centers[i];
				Vector3 pos = center.transform.position;
				Vector4 v = new Vector4(pos.x, pos.y, pos.z, Radius);
				material.SetVector("_Sphere" + (i + 1), v);
			}
		}
    }
}
