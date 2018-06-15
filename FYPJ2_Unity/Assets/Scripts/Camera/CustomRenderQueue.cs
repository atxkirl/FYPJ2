using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CustomRenderQueue : MonoBehaviour
{
	public UnityEngine.Rendering.CompareFunction comparison = UnityEngine.Rendering.CompareFunction.Always;
	public bool ApplyToChildren = true;

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

		//Should apply this effect to all children?
		if (ApplyToChildren)
		{
			//Run through all the children of the main object and check if they have Image components, and if they do - update them
			for (int i = 0; i < this.transform.childCount; ++i)
			{
				if (this.transform.GetChild(i).GetComponent<Image>())
				{
					imageComponent = this.transform.GetChild(i).GetComponent<Image>();
					existingGlobalMat = imageComponent.materialForRendering;
					updatedMaterial = new Material(existingGlobalMat);
					updatedMaterial.SetInt("unity_GUIZTestMode", (int)comparison);

					this.transform.GetChild(i).GetComponent<Image>().material = updatedMaterial;
				}
			}
		}
	}
}
