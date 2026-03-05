using UnityEngine;

public class CameraSwipe : MonoBehaviour
{
    [Header("이동 설정")]
    [SerializeField] private float moveSpeed = 0.02f;   // 스와이프에 대한 민감도
    [SerializeField] private bool clampX = false;
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;

    private bool _isDragging;
    private Vector2 _lastPointerPos;

    private Camera _cam;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
        if (_cam == null)
        {
            _cam = Camera.main;
        }
    }

    private void Update()
    {
        // 에디터 / PC용 마우스 드래그
        HandleMouseDrag();

        // 모바일용 터치 드래그
        HandleTouchDrag();

        // 다른 스크립트에서 이동시켜도 항상 X를 한 번 더 고정
        if (clampX)
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            transform.position = pos;
        }
    }

    private void HandleMouseDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            _lastPointerPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
        }

        if (!_isDragging) return;

        Vector2 currentPos = Input.mousePosition;
        Vector2 delta = currentPos - _lastPointerPos;
        _lastPointerPos = currentPos;

        MoveHorizontal(delta.x);
    }

    private void HandleTouchDrag()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                _isDragging = true;
                _lastPointerPos = touch.position;
                break;

            case TouchPhase.Moved:
                if (!_isDragging) return;
                Vector2 currentPos = touch.position;
                Vector2 delta = currentPos - _lastPointerPos;
                _lastPointerPos = currentPos;

                MoveHorizontal(delta.x);
                break;

            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                _isDragging = false;
                break;
        }
    }

    private void MoveHorizontal(float deltaX)
    {
        // 오른쪽으로 스와이프하면 카메라를 오른쪽/왼쪽 어느 쪽으로 움직일지에 따라 부호를 조절
        float moveAmount = -deltaX * moveSpeed; // 보통 오른쪽으로 스와이프하면 카메라는 왼쪽으로 이동하도록 음수

        Vector3 pos = transform.position;
        pos.x += moveAmount;

        if (clampX)
        {
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
        }

        transform.position = pos;
    }
}

