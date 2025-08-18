using UnityEngine;

public class InpurReciever : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);
    public const string Vertical = nameof(Vertical);

    public float Rotation { get; private set; }
    public float Direction {  get; private set; }

    private void Update()
    {
        Rotation = Input.GetAxis(Horizontal);
        Direction = Input.GetAxis(Vertical);
    }
}
