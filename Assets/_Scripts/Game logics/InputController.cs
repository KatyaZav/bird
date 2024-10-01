using UnityEngine;

public class InputController : MonoBehaviour
{
    [Header("Keys")]
    [SerializeField] private KeyCode _jumpButton = KeyCode.X;
    [SerializeField] private KeyCode _moveButton = KeyCode.Z;
    [SerializeField] private KeyCode _useItemButton = KeyCode.F;

    [Space(10)]
    [Header("Settings")]
    [SerializeField] private Player _bird;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpButton))
        {
            _bird.Jump();
        }

        if (Input.GetKeyDown(_moveButton))
        {
            _bird.PlayerJumper.Swipe();
        }

        if (Input.GetKeyDown(_useItemButton))
        {
            _bird.TryUseItem();
        }
    }
}
