using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAnimation : MonoBehaviour
{

    public float speed = 1f;
    public float height = 10f;
    [SerializeField] private Vector3 direction;
    
    private RectTransform parentRect;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();
        
        rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = Mathf.Sin(Time.time * speed) * (height * direction);
        Debug.Log("transform.localPosition" + transform.localPosition);

    }
}
