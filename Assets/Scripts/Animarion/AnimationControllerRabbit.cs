using UnityEngine;

public class AnimationControllerRabbit : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ��� ��
        {
            CheckForObjectClick(Input.mousePosition);
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // ��� ���������
        {
            CheckForObjectClick(Input.GetTouch(0).position);
        }
    }
    void CheckForObjectClick(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition); // ������� ��� �� ����� �������
        if (Physics.Raycast(ray, out RaycastHit hit)) // ���������, ����� �� ��� � ���������
        {
            if (hit.collider.gameObject == gameObject) // ���������, ��� ��� ������ ��� ������
            {
                animator.SetTrigger("PlayDanceAnimation");
            }
        }
    }
}
