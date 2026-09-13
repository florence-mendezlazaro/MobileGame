using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Laser Properties")]
    [SerializeField] private float laser_speed = 15f;
    private Vector3 laser_direction;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += laser_direction * laser_speed * Time.deltaTime;
    }

    public void SetLaserDirection(Vector3 direction)
    {
        laser_direction = direction;
    }
}