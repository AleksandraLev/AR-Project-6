using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;

public class ShowPlane : MonoBehaviour
{
    // private PlaceOnPlane placeOnPlane;  // Компонент, который управляет PlacedPrefab
    [SerializeField] GameObject XROrigin;
    private GameObject Plane;
    private ARPlaneManager arPlaneManager;
    void Start()
    {
        PlaceOnPlane.onPlacedObject += DeactivatePlane;
        Debug.Log("Компонент PlaceOnPlane успешно получен, можно с ним работать");
        
        if (XROrigin.TryGetComponent<ARPlaneManager>(out arPlaneManager))
        {
            Debug.Log("Компонент ARPlaneManager успешно получен, можно с ним работать");
        }
        else
        {
            Debug.LogWarning("Компонент ARPlaneManager не найден на объекте XROrigin");
        }
    }

    void OnDestroy()
    {
        PlaceOnPlane.onPlacedObject -= DeactivatePlane;
    }

    void DeactivatePlane()
    {
        arPlaneManager.enabled = false;
        foreach (var plane in arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }
}