using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    private bool _isOpened = false;
    private bool _hasOpener;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rogue>())
            _hasOpener = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rogue>())
            _hasOpener = false;
    }

    private void Update()
    {
        if (_isOpened)
            return;

        if (_hasOpener && Input.GetKeyDown(KeyCode.E))
        {
            _door.Open();
            _isOpened = true;
        }
    }
}
