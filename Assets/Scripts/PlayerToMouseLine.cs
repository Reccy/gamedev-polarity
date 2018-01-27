using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToMouseLine : MonoBehaviour {

    [SerializeField] public float maxLineLength;
    
    public LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Use this for initialization
    void Start () {
        SetLinePositions();
	}
	
	// Update is called once per frame
	void Update () {
        SetLinePositions();
	}

    void SetLinePositions(){
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = new Vector3(lookPos.x - transform.position.x, lookPos.y - transform.position.y, transform.position.z);
        float distance = Vector2.Distance(transform.position, lookPos);

        lineRenderer.SetPosition(0, transform.position);

        if (distance > maxLineLength)
        {
            lineRenderer.SetPosition(1, (Vector2)(transform.position + (direction.normalized * maxLineLength)));
        } else
        {
            lineRenderer.SetPosition(1, (Vector2)lookPos);
        }
    }
}
