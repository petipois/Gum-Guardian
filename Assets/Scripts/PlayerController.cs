using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerControls playerControls;
    [SerializeField] GameObject projectile;
    [SerializeField] float speed=1f;
    [SerializeField] Transform firePoint;
    [SerializeField] float xRange, yRange;

    [SerializeField] float positionPitchFactor = -2f, controlPitchFactor = -10f, positionYawFactor = 2f, controlRollFactor=-0f;
    Vector2 movement;
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    // Start is called before the first frame update
    void Start()
    {

        playerControls.Player.Shoot.performed += Shoot_performed;
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        ThrowProjectile();
    }
    void ThrowProjectile()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
        
    }
    void ProcessRotation()
    {
        float pitch = (transform.localPosition.y*positionPitchFactor)+movement.y*controlPitchFactor;
        float yaw =  transform.localPosition.x * positionYawFactor;
        float roll = movement.x + controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void ProcessMovement()
    {
       movement = playerControls.Player.Movement.ReadValue<Vector2>();

        float xOffset = movement.x * Time.deltaTime * speed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = movement.y * Time.deltaTime * speed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
