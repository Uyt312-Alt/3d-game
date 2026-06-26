using UnityEngine;

public class ParkourController : MonoBehaviour
{
    [Header("Wall Run")]
    public float wallRunSpeed = 8f;
    public float wallRunGravity = 2f;
    public LayerMask wallMask;
    public float wallCheckDistance = 0.7f;

    [Header("Vault")]
    public float vaultSpeed = 6f;
    public LayerMask vaultMask;
    public float vaultCheckDistance = 1f;

    private CharacterController controller;

    void Start() { controller = GetComponent<CharacterController>(); }

    void Update()
    {
        bool wallLeft  = Physics.Raycast(transform.position, -transform.right, out RaycastHit hL, wallCheckDistance, wallMask);
        bool wallRight = Physics.Raycast(transform.position,  transform.right, out RaycastHit hR, wallCheckDistance, wallMask);

        if ((wallLeft || wallRight) && Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 n = wallLeft ? hL.normal : hR.normal;
            Vector3 fwd = Vector3.Cross(n, Vector3.up);
            if (Vector3.Dot(fwd, transform.forward) < 0) fwd = -fwd;
            controller.Move(fwd * wallRunSpeed * Time.deltaTime);
            controller.Move(Vector3.down * wallRunGravity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E))
            if (Physics.Raycast(transform.position, transform.forward, vaultCheckDistance, vaultMask))
            {
                controller.Move(Vector3.up * 1.5f);
                controller.Move(transform.forward * vaultSpeed * Time.deltaTime);
            }
    }
}
