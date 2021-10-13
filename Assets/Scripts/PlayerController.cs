using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    #region Event
    public delegate void MoveEvent(float value);
    public event MoveEvent OnMoveHorizontal;
    public event MoveEvent OnMoveVertical;
    public event MoveEvent OnEndHorizontal;
    public event MoveEvent OnEndVertical;

    public delegate void InteractEvent();
    public event InteractEvent OnInteract;
    public event InteractEvent OnInventory;

    public delegate void MouseEvent(Vector2 position);
    public event MouseEvent OnMouse;
    #endregion

    //[Range(0.0f, 10.0f)]
    //public float speed = 10.0f;
    //private Rigidbody rb;

    private PlayerControls playerControls;
    public static PlayerController Instance { get; private set; }
    private void Awake()
    {
        playerControls = new PlayerControls();
        //rb = GetComponent<Rigidbody>();
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Start()
    {
        playerControls.Map.MoveHorizontal.started += ctx => StartMoveHorizontal(ctx);
        playerControls.Map.MoveVertical.started += ctx => StartMoveVertical(ctx);
        playerControls.Map.MoveHorizontal.canceled += ctx => EndMoveHorizontal(ctx);
        playerControls.Map.MoveVertical.canceled += ctx => EndMoveVertical(ctx);
        playerControls.Map.Interact.performed += ctx => StartInteract(ctx);
        playerControls.Map.Mouse.started += ctx => StartMouse(ctx);
        playerControls.Map.Inventory.performed += ctx => StartInventory(ctx);
    }

    private void StartMoveHorizontal(InputAction.CallbackContext context)
    {
        if(OnMoveHorizontal != null)
        {
            OnMoveHorizontal(playerControls.Map.MoveHorizontal.ReadValue<float>());
        }
    }
    private void StartMoveVertical(InputAction.CallbackContext context)
    {
        if(OnMoveVertical != null)
        {
            OnMoveVertical(playerControls.Map.MoveVertical.ReadValue<float>());
        }
    }
    private void EndMoveHorizontal(InputAction.CallbackContext context)
    {
        if(OnEndHorizontal != null)
        {
            OnEndHorizontal(playerControls.Map.MoveHorizontal.ReadValue<float>());
        }
    }
    private void EndMoveVertical(InputAction.CallbackContext context)
    {
        if(OnEndVertical != null)
        {
            OnEndVertical(playerControls.Map.MoveVertical.ReadValue<float>());
        }
    }
    private void StartMouse(InputAction.CallbackContext context)
    {
        if(OnMouse != null)
        {
            OnMouse(playerControls.Map.Mouse.ReadValue<Vector2>());
        }
    }
    private void StartInteract(InputAction.CallbackContext context)
    {
        if(OnInteract != null)
        {
            OnInteract();
        }
    }
    private void StartInventory(InputAction.CallbackContext context)
    {
        if (OnInventory != null)
        {
            OnInventory();
        }
    }

    //private void Update()
    //{
    //    Vector3 currentPos = transform.position;
    //    float moveVertical = playerControls.Map.MoveVertical.ReadValue<float>();
    //    float moveHorizontal = playerControls.Map.MoveHorizontal.ReadValue<float>();
    //    currentPos.x += moveHorizontal * speed * Time.deltaTime;
    //    currentPos.z += moveVertical * speed * Time.deltaTime;
    //    rb.MovePosition(currentPos);
    //}
}
