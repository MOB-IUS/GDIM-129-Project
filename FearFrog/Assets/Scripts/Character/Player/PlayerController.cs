using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Member Variables
    private uint m_health = 0; // To be set later with scriptable objects
    private bool m_isGrounded = true;
    [SerializeField] private float m_moveSpeed = 2f;
    [SerializeField] private float m_cameraSensitivity = 100f;
    [SerializeField] private float m_jumpSpeed = 0.7f;
    [SerializeField] private float m_groundDrag = 12f;
    [SerializeField] private float m_airDrag = 3f;
    
    private float m_xOritation = 0; // Record of player look direction
    private float m_yOritation = 0;
    
    [SerializeField] private GameObject m_playerEntity;
    [SerializeField] private GameObject m_camera;
    [SerializeField] private Transform m_footPos;
    
    
    // Awake
    void Awake()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    // Start
    void Start()
    {
        // Link Jump functionality to input system
        InputController.Instance.Input.Player.Jump.performed += Jump;
    }

    // Update
    void Update()
    {
        // Player Look
        Vector2 lookDirection = InputController.Instance.Input.Player.Look.ReadValue<Vector2>();
        m_xOritation += lookDirection.x * m_cameraSensitivity * Time.deltaTime;
        m_yOritation += lookDirection.y * m_cameraSensitivity * Time.deltaTime;
        m_yOritation = Math.Clamp(m_yOritation, -90f, 90f);
        
        m_camera.transform.rotation = Quaternion.Euler(-m_yOritation, m_xOritation, 0f);
        m_playerEntity.transform.rotation = Quaternion.Euler(0f, m_xOritation, 0f);
        
        // Player Move
        Vector2 input = InputController.Instance.Input.Player.Move.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);
        moveDirection = (Quaternion.Euler(0f, m_xOritation, 0f) * moveDirection).normalized;

        this.GetComponent<Rigidbody>().AddForce(moveDirection * m_moveSpeed, ForceMode.Force);
        
        // Player Grounded Check
        m_isGrounded = Physics.Raycast(m_footPos.position, Vector3.down, 0.15f, LayerMask.GetMask("Ground"));
        this.GetComponent<Rigidbody>().linearDamping = m_isGrounded ? m_groundDrag : m_airDrag;
    }
    
    
    // Player Jump
    private void Jump(InputAction.CallbackContext ctx)
    {
        if (m_isGrounded)
        {
            // Update player rigidbody velocity
            Vector3 targetVelocity = this.GetComponent<Rigidbody>().linearVelocity;
            targetVelocity.y = m_jumpSpeed;
            this.GetComponent<Rigidbody>().linearVelocity = targetVelocity;
            
            // Update player grounded state
            m_isGrounded = false;
        }
    }
}
