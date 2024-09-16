using UnityEngine;

public class InputController : MonoBehaviour
{
    [Header("Keys")]
    [SerializeField] private KeyCode _jumpButton = KeyCode.Space;
    [SerializeField] private KeyCode _moveButton = KeyCode.Z;

    [Space(10)]
    [Header("Settings")]
    [SerializeField] private BirdJumper _bird;

    void Update()
    {
        if (Input.GetKeyDown(_jumpButton))
        {
            _bird.Jump();
        }

        if (Input.GetKeyDown(_moveButton))
        {
            _bird.Swipe();
        }
    }
}
