using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;

public class ShowPlane : MonoBehaviour
{
    // private PlaceOnPlane placeOnPlane;  // ���������, ������� ��������� PlacedPrefab
    [SerializeField] GameObject XROrigin;
    private GameObject Plane;
    private ARPlaneManager arPlaneManager;
    void Start()
    {
        PlaceOnPlane.onPlacedObject += DeactivatePlane;
        Debug.Log("��������� PlaceOnPlane ������� �������, ����� � ��� ��������");
        
        if (XROrigin.TryGetComponent<ARPlaneManager>(out arPlaneManager))
        {
            Debug.Log("��������� ARPlaneManager ������� �������, ����� � ��� ��������");
        }
        else
        {
            Debug.LogWarning("��������� ARPlaneManager �� ������ �� ������� XROrigin");
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