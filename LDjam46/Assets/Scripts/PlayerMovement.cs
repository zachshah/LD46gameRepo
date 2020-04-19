using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public List<GameObject> enemiesChasingThisObject = new List<GameObject>();
    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;
    public GameObject physicalMouseLoc;
    // Start is called before the first frame update
    void Start()
    {
        physicalMouseLoc = GameObject.FindGameObjectWithTag("PhysicalMouse");
       
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed*Time.deltaTime;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0,2.5f,0));
        float rayLength;

        if (groundPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            physicalMouseLoc.transform.position = pointToLook;
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }
    }
    private void LateUpdate()
    {
        for (var i = 0; i < enemiesChasingThisObject.Count; i++)
        {
            if (enemiesChasingThisObject[i] == null)
                enemiesChasingThisObject.RemoveAt(i);
        }
    }
    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
