using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using Mirror;

public class playerController : MonoBehaviour
{
    public Rigidbody player;
    public int speed;
    public GameObject camCube;

    private GameControls controls;

    private void Awake()
    {
        controls = new GameControls();
    }

    public GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        // Disable camera if we are not the local player
        //if (!isLocalPlayer) for multiplayer
        //{
        //    playerCamera.gameObject.SetActive(false);
        //}
    }

    // New Input System Controls -------------------------
    private void OnEnable()
    {
        // Camera
        controls.Camera.PanLeft.performed += panLeft;
        controls.Camera.PanLeft.Enable();
        controls.Camera.PanRight.performed += panRight;
        controls.Camera.PanRight.Enable();
        // Gameplay
        //controls.Gameplay.Menu.performed += openMenu;
        //controls.Gameplay.Menu.Enable();
        controls.Gameplay.Shoot.performed += openFire;
        controls.Gameplay.Shoot.Enable();
        controls.Gameplay.Jump.performed += Jump;
        controls.Gameplay.Jump.Enable();
    }
    // Camera
    private void panLeft(InputAction.CallbackContext obj) // ','
    {
        //if (!isLocalPlayer)
        //{
        //    return;
        //}
        camCube.transform.Rotate(new Vector3(0, -45, 0));
    }
    private void panRight(InputAction.CallbackContext obj) // '.'
    {
        //if (!isLocalPlayer)
        //{
        //    return;
        //}
        camCube.transform.Rotate(new Vector3(0, 45, 0));
    }
    //Gameplay
    //public GameObject menu;
    //private void openMenu(InputAction.CallbackContext obj) // 'Esc'
    //{
    //    //if (!isLocalPlayer)
    //    //{
    //    //    return;
    //    //}
    //    // if ui is enabled, disable it, vice versa
    //    Debug.Log("Activate menu");
    //    menu.SetActive(true);
    //}
    public Rigidbody projectile;
    private void openFire(InputAction.CallbackContext obj) // 'Tab'
    {
        //if (!isLocalPlayer)
        //{
        //    return;
        //}
        // shoot a projectile
        Rigidbody clone;
        clone = Instantiate(projectile, camCube.transform.position + Vector3.up * 0.9f, Quaternion.Euler(90f, camCube.transform.rotation.y, camCube.transform.rotation.z)); // spawn bullets a small distance away from where I'm facing
        clone.velocity = camCube.transform.TransformDirection(Vector3.forward * 100); // send bullets with speed
        Destroy(clone.gameObject, 1.5f);
    }
    private void Jump(InputAction.CallbackContext obj) // 'Space'
    {
        //if (!isLocalPlayer) for multiplayer purposes
        //{
        //    return;
        //}
        player.AddForce(new Vector3(0.0f, 1500.0f, 0.0f));
    }

    private void OnDisable()
    {
        controls.Camera.PanLeft.Disable();
        controls.Camera.PanRight.Disable();
        controls.Gameplay.Menu.Disable();
        controls.Gameplay.Shoot.Disable();
        controls.Gameplay.Jump.Disable();
    }

    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void FixedUpdate()
    {
      
        // Using old input system ---------------------------------------------
        float moveHorizontal = Input.GetAxis("Horizontal"); // * Time.deltaTime
        float moveForward = Input.GetAxis("Vertical");

        Vector3 movement = moveHorizontal * camCube.transform.right;
        movement += moveForward * camCube.transform.forward;

        player.AddForce(movement * speed);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
