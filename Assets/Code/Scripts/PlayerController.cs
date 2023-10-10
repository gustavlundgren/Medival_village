using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    [Header("Door Use")]
    [SerializeField] private TextMeshPro useText;
    [SerializeField] private Transform cam;
    [SerializeField] private float maxUseDistance;
    [SerializeField] private LayerMask useLayer;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform cameraTransform;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0, movement.y);

        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);
       
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        if(inputManager.PlayerUse())
        {
            if(Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, maxUseDistance, useLayer))
            {
                if(hit.collider.TryGetComponent<Door>(out Door door))
                {
                    if(door.isOpen)
                    {
                        door.Close();
                    }
                    else
                    {
                        door.Open(transform.position);
                    }
                }
            }
        }

        if(Physics.Raycast(cam.position, cam.forward, out RaycastHit h, maxUseDistance, useLayer))
        {
            if(h.collider.TryGetComponent<Door>(out Door door)) 
            {
                if(!door.isOpen)
                {
                    useText.SetText("Open E");

                } 
                else
                {
                    useText.SetText("Close E");
                }
            }
            

            useText.gameObject.SetActive(true);
            useText.transform.position = h.point - (h.point - cam.position).normalized * 0.01f;
            useText.transform.rotation = Quaternion.LookRotation((h.point - cam.position).normalized);
        }
        else
        {
            useText.gameObject.SetActive(false);
        } 


    }
}
