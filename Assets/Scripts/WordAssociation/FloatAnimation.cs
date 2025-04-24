using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAnimation : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    [SerializeField] private float height = 10f;
    [SerializeField] private float wobbleSpeed = 1.5f;
    [SerializeField] private float wobbleAngle = 5f;
    [SerializeField] private Vector2 direction = new Vector2(0f,1f);

    private Vector2 startPos;
    private float phaseOffset;
    private RectTransform rectTransform;   

    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;

        phaseOffset = Random.Range(0f, Mathf.PI * 2);
    }

    // Update is called once per frame
    void Update()
    {
        // floating effect
        Vector2 offset = Mathf.Sin(Time.time * speed + phaseOffset) * (height * direction);
        rectTransform.anchoredPosition = startPos + offset;

        // Wobble effect
        float zRotation = Mathf.Sin(Time.time * wobbleSpeed + phaseOffset) * wobbleAngle;
        rectTransform.localRotation = Quaternion.Euler(0f, 0f, zRotation);
    }
}
