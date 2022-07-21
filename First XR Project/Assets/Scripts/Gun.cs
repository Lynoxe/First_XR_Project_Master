using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _speed = 40f;
    [SerializeField] private float _lifeTime = 2f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _barrelTransform;

    public void Shoot()
    {
        GameObject spawnedBullet = Instantiate(_bulletPrefab, _barrelTransform.position, _barrelTransform.rotation);
        spawnedBullet.GetComponentInChildren<Rigidbody>().velocity = _speed * _barrelTransform.forward;
        Destroy(spawnedBullet, _lifeTime);
    }
}
