using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CustomRenderQueue : MonoBehaviour
{
	public UnityEngine.Rendering.CompareFunction comparison = UnityEngine.Rendering.CompareFunction.Always;

	void Start()
	{
		//Debug.Log("Updated" + gameObject.name + "material val");
		Image image = GetComponent<Image>();
		Material existingGlobalMat = image.materialForRendering;
		Material updatedMaterial = new Material(existingGlobalMat);
		updatedMaterial.SetInt("unity_GUIZTestMode", (int)comparison);
		image.material = updatedMaterial;
	}
}
