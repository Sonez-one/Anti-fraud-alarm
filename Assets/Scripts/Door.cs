using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _openTrigger = Animator.StringToHash("Open");

    public void Open()
    {
        _animator.SetTrigger(_openTrigger);
    }
}
