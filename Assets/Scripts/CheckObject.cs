using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation.Samples;

public class CheckObject : MonoBehaviour
{
    [SerializeField] List<Button> Buttons = new List<Button>();
    [SerializeField] List<GameObject> ARobjects = new List<GameObject>();
    [SerializeField] GameObject XROrigin;

    private PlaceOnPlane placeOnPlane;  // ���������, ������� ��������� PlacedPrefab

    void Start()
    {
        // ������ ��������� PlaceOnPlane � ������ �������
        placeOnPlane = XROrigin.GetComponent<PlaceOnPlane>();

        // ������������� �� ������� ������
        for (int i = 0; i < Buttons.Count; i++)
        {
            int index = i;  // ��������� ������ ������ ��� ������������� � �����������
            Buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
    }

    // ����� ��� ��������� ������� �� ������
    private void OnButtonClicked(int index)
    {
        if (index >= 0 && index < ARobjects.Count)
        {
            // ������ Prefab � ���������� PlaceOnPlane
            placeOnPlane.placedPrefab = ARobjects[index];
            Debug.Log("������ ������ � CheckObject (��� ���������): " + ARobjects[index].name);
        }
    }
    public void MakePlacedPrefabNull()
    {
        placeOnPlane.placedPrefab = null;
        Destroy(placeOnPlane.placedPrefab);
    }
}
