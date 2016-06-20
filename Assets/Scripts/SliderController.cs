using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider Slider;

    private VesselController VesselController;

    void Awake()
    {
        VesselController = GetComponent<VesselController>();
    }

    void Start () {
        Slider.onValueChanged.AddListener(delegate { VesselController.ChangeCompression(Slider.value); });
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Slider.value -= 5f;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Slider.value += 5f;
        }
    }
}
