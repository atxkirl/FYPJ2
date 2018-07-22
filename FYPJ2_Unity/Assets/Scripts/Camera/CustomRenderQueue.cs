using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CustomRenderQueue : MonoBehaviour
{
	public UnityEngine.Rendering.CompareFunction comparison = UnityEngine.Rendering.CompareFunction.Always;

	private Material existingGlobalMat;
	private Material updatedMaterial;
	private Image imageComponent;

	void Start()
	{
		//Check to make sure object has Image component
		if(this.GetComponent<Image>())
		{
			imageComponent = GetComponent<Image>();
			existingGlobalMat = imageComponent.materialForRendering;
			updatedMaterial = new Material(existingGlobalMat);
			updatedMaterial.SetInt("unity_GUIZTestMode", (int)comparison);
			imageComponent.material = updatedMaterial;
		}
	}
}
