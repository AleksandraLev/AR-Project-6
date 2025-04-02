using UnityEngine;

public class AnimationControllerChest : MonoBehaviour
{
    private Animator animator;
    private int animationIndex = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0) ||
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) // ��� ���������
        {
            animationIndex = (animationIndex + 1) % 2; // ������������ ����� 0 � 1
            animator.SetInteger("AnimationIndex", animationIndex);
        }*/
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
                animationIndex = (animationIndex + 1) % 2; // ������������ ��������
                animator.SetInteger("AnimationIndex", animationIndex);
            }
        }
    }
}
