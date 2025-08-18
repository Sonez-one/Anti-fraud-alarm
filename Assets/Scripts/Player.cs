using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InpurReciever _inpurReciever;
    [SerializeField] private Mover _mover;

    private void FixedUpdate()
    {
        if (_inpurReciever != null)
        {
            _mover.Move(_inpurReciever.Direction);
            _mover.Rotate(_inpurReciever.Rotation);
        }
    }
}
