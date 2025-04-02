using UnityEngine;
using UnityEngine.UI;

public class ScrollViewList : MonoBehaviour
{
    public GameObject buttonPrefab;  // ������ ������
    public Transform content;  // ��������� ��� ������ (Content)
    public Sprite[] buttonImages;  // ������ � ������������� ��� ������

    void Start()
    {
        // ������� ������ �� ������ ������� �����������
        foreach (Sprite img in buttonImages)
        {
            CreateButton(img);
        }
    }

    // ����� ��� �������� ������
    void CreateButton(Sprite buttonImage)
    {
        // ������� ������
        GameObject newButton = Instantiate(buttonPrefab, content);

        // �������� ��������� Image ��� ������ � ������������� ��������
        Image buttonImg = newButton.GetComponent<Image>();
        buttonImg.sprite = buttonImage;

        // �������� ��������� Button � ��������� ���������� �������
        Button button = newButton.GetComponent<Button>();
        button.onClick.AddListener(() => OnButtonClick(buttonImage));
    }

    // �����, ������� ���������� ��� ������� �� ������
    void OnButtonClick(Sprite clickedImage)
    {
        Debug.Log("������� ������ � ������������: " + clickedImage.name);
    }
}
