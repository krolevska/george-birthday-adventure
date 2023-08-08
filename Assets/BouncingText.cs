using UnityEngine;
using TMPro;

public class BouncingText : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector2 direction = Vector2.one.normalized;  // Start with diagonal movement.
    private RectTransform rectTransform;
    private RectTransform parentRectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectTransform.anchoredPosition += direction * speed * Time.deltaTime;

        if (rectTransform.anchoredPosition.x < -parentRectTransform.rect.width / 2 + rectTransform.rect.width / 2)
            direction.x = Mathf.Abs(direction.x);  // Flip the x direction
        else if (rectTransform.anchoredPosition.x > parentRectTransform.rect.width / 2 - rectTransform.rect.width / 2)
            direction.x = -Mathf.Abs(direction.x);  // Flip the x direction

        if (rectTransform.anchoredPosition.y < -parentRectTransform.rect.height / 2 + rectTransform.rect.height / 2)
            direction.y = Mathf.Abs(direction.y);  // Flip the y direction
        else if (rectTransform.anchoredPosition.y > parentRectTransform.rect.height / 2 - rectTransform.rect.height / 2)
            direction.y = -Mathf.Abs(direction.y);  // Flip the y direction
    }
}
