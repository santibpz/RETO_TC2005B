using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFinder : MonoBehaviour
{
    private RectTransform selectorRectTransform;
    private Canvas canvas;

    private void Start()
    {
        selectorRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    private void Update()
    {
        Vector2 selectorPosition = selectorRectTransform.anchoredPosition;
        List<GameObject> objectsAtPosition = GetObjectsAtPosition(selectorPosition);

        foreach (GameObject obj in objectsAtPosition)
        {
            Debug.Log("Objeto encontrado: " + obj.name);
        }
    }

    private List<GameObject> GetObjectsAtPosition(Vector2 position)
{
    List<GameObject> objectsAtPosition = new List<GameObject>();

    foreach (Transform child in transform.parent)
    {
        if (child != transform)
        {
            RectTransform childRectTransform = child.GetComponent<RectTransform>();
            if (childRectTransform != null)
            {
                Vector2 childPosition = childRectTransform.anchoredPosition;
                Vector2 childSize = childRectTransform.sizeDelta * childRectTransform.localScale.x;

                // Ajustar las coordenadas y las dimensiones según la escala
                childPosition /= childRectTransform.localScale.x;
                childSize /= childRectTransform.localScale.x;

                Rect rect = new Rect(childPosition - childSize / 2f, childSize);

                if (rect.Contains(position))
                {
                    objectsAtPosition.Add(child.gameObject);
                }
            }
        }
    }

    return objectsAtPosition;
}
}