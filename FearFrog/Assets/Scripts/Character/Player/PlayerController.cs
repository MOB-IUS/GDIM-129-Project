using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Member Variables
    [SerializeField] private float m_moveSpeed = 5f;
    [SerializeField] private float m_cameraSensitivity = 100f;
    private Rigidbody m_playerRb;
    
    private uint m_health = 0; // To be set later with scriptable objects
    
    // Awake
    void Awake()
    {
        // Set private member variables
        m_playerRb = this.GetComponent<Rigidbody>();
    }
    

    // Update
    void Update()
    {
        // Player Move
        Vector2 input = InputController.Instance.Input.Player.Move.ReadValue<Vector2>();
        Debug.Log(input.ToString());
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);

        m_playerRb.linearVelocity = moveDirection.normalized * m_moveSpeed;
    }
}
