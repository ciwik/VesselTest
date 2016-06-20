using System.Collections;
using UnityEngine;

public class VesselController : MonoBehaviour
{
    public GameObject Vessel;

    private MeshCollider meshCollider;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Mesh mesh;
    private float compressionRatio;
    private SliderController SliderController;

    void Awake()
    {
        SliderController = GetComponent<SliderController>();
        skinnedMeshRenderer = Vessel.GetComponent<SkinnedMeshRenderer>();
        meshCollider = Vessel.GetComponent<MeshCollider>();
    }

    private void ChangeCollider()
    {
        skinnedMeshRenderer.SetBlendShapeWeight(0, compressionRatio);

        mesh = new Mesh();
        skinnedMeshRenderer.BakeMesh(mesh);
        meshCollider.sharedMesh = mesh;
    }

    IEnumerator AnimateCompress(float targetCompressionRatio)
    {
        SliderController.Slider.interactable = false;

        float deltaRatio = targetCompressionRatio - compressionRatio;
        float k = (int)(deltaRatio/5f) + 1f;
        k = deltaRatio/k;

        while (compressionRatio < targetCompressionRatio)
        {
            compressionRatio += k;
            ChangeCollider();
            yield return new WaitForSeconds(0.05f);            
        }
        SliderController.Slider.interactable = true;
    }

    public void ChangeCompression(float newCompressionRatio)
    {
        if (newCompressionRatio - compressionRatio <= 5f)
        {
            compressionRatio = newCompressionRatio;
            ChangeCollider();
        }
        else
        {            
            StartCoroutine(AnimateCompress(newCompressionRatio));
        }
    }
}