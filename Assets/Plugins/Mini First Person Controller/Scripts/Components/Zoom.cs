using UnityEngine;

[ExecuteInEditMode]
public class Zoom : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    
    public float defaultFOV = 60;
    [Range(0, 1)]
    public float currentZoom;
    public float sensitivity = 1;


    void Awake()
    {
        // Get the camera on this gameObject and the defaultZoom.
        if (camera)
        {
            defaultFOV = camera.fieldOfView;
        }
    }

    public void ZoomIn(float newFOV, float time)
    {
         camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, newFOV, time);
    }

    public void ResetZoom()
    {
        camera.fieldOfView = defaultFOV;
    }
    
    // void Update()
    // {
    //     // Update the currentZoom and the camera's fieldOfView.
    //     currentZoom += Input.mouseScrollDelta.y * sensitivity * .05f;
    //     currentZoom = Mathf.Clamp01(currentZoom);
    //     camera.fieldOfView = Mathf.Lerp(defaultFOV, maxZoomFOV, currentZoom);
    // }
}
