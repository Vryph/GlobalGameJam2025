using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;

public class VirtualMouseUI : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasRectTransform;
    public Vector2 virtualMousePosition;
    public int id = 0;

    private VirtualMouseInput _virtualMouseInput;
    private float _edgeOffset = 15f;

    private void Awake()
    {
        _virtualMouseInput = GetComponent<VirtualMouseInput>();
    }

    private void Start()
    {
        if (id == 1) { InputState.Change(_virtualMouseInput.virtualMouse.position, new Vector2(812, 50), InputUpdateType.Default); }
        else { InputState.Change(_virtualMouseInput.virtualMouse.position, new Vector2(60, 50));}
    }

    private void Update()
    {
        transform.localScale = Vector3.one *  (1f / _canvasRectTransform.localScale.x);
        transform.SetAsLastSibling();

    }
    private void LateUpdate()
    {
        virtualMousePosition = _virtualMouseInput.virtualMouse.position.value;
        virtualMousePosition.x = Mathf.Clamp(virtualMousePosition.x, 0f + _edgeOffset, Screen.width - _edgeOffset);
        virtualMousePosition.y = Mathf.Clamp(virtualMousePosition.y, 0f + _edgeOffset, Screen.height - _edgeOffset);
        InputState.Change(_virtualMouseInput.virtualMouse.position, virtualMousePosition);
    }
}
