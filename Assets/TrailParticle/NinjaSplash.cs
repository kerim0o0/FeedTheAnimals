using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSplash : MonoBehaviour
{
    public GameObject splashParticle;

    public float depth = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;

        if (Input.GetMouseButton(0))
        {
            Vector3 dir = (worldPos - Camera.main.transform.position).normalized;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, dir, out hit))
            {
                Splash();

                Destroy(hit.collider.gameObject);
            }
        }
    }

    public void Splash()
    {
        Instantiate(splashParticle, transform);
    }
}
