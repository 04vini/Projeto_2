using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_cam : MonoBehaviour
{
    private const float limit_minY = 10f;
    private const float limit_maxY = 80f;

    public Transform lookat;
    public Transform camTransform;

    private Camera cam;

    private float distance =5f;
    private float currentX =0f;
    private float currentY =0f;
    private float sensitivyX  =4f;
    private float sensitivyY =1f;

    public static bool lockedON;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, limit_minY, limit_maxY);
    }
    private void LateUpdate()
    {
        if (lockedON == false)
        {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            camTransform.position = lookat.position + rotation * dir;
            camTransform.LookAt(lookat.position);
        }
    }
}
