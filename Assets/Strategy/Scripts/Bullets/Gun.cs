using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Strategy
{
    public class Gun : MonoBehaviour, ISingleFireing, ITripleFireing
    {
        enum SetBulletMode
        {
            SingleFireing,
            TripleFireing
        }

        private GameObject _bulletGo;
        private Bullet _bullet;
        [SerializeField] private AmmoStorage _ammoStorage;
        [SerializeField] private Transform _bulletSpawnPosition;
        [SerializeField] private SetBulletMode _bulletMode;

        private float _fireSpeed = 0.3f;

        private void Awake()
        {
            _bullet = _ammoStorage.GetBullet();
        }

        private void OnEnable()
        {
            Buttons.LoadSimpleAmmo_e += SetSimple;
            Buttons.LoadMetalAmmo_e += SetMetal;
            Buttons.EnableSingleFireing_e += SetSingleMode;
            Buttons.EnableTripleFireing_e += SetTripleMode;
        }

        private void OnDisable()
        {
            Buttons.LoadSimpleAmmo_e -= SetSimple;
            Buttons.LoadMetalAmmo_e -= SetMetal;
            Buttons.EnableSingleFireing_e -= SetSingleMode;
            Buttons.EnableTripleFireing_e -= SetTripleMode;
        }

        private void SetSimple()
        {
            _bullet = _ammoStorage.GetBullet();
        }

        private void SetMetal()
        {
            _bullet = _ammoStorage.GetBulletPro();
        }

        private void SetSingleMode()
        {
            _bulletMode = SetBulletMode.SingleFireing;
        }

        private void SetTripleMode()
        {
            _bulletMode = SetBulletMode.TripleFireing;
        }

        private void Fire()
        {
            _bulletGo = _bullet.gameObject;
            if (!_bulletGo.IsUnityNull())
            {
                if (_bulletMode == SetBulletMode.SingleFireing)
                {
                    SingleShooting();
                }
                else if (_bulletMode == SetBulletMode.TripleFireing)
                {
                    TripleShooting();
                }
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && TimeDelay.RepeatEveryFewSec(_fireSpeed))
            {
                Fire();
            }
        }

        public void SingleShooting()
        {
            Instantiate(_bulletGo, _bulletSpawnPosition.transform.position, Quaternion.identity);
        }

        public void TripleShooting()
        {
            Vector2 firstBulletPosition = _bulletSpawnPosition.transform.position;
            Vector2 secondBulletPosition = new Vector2(firstBulletPosition.x - 0.5f, firstBulletPosition.y);
            Vector2 thirdBulletPosition = new Vector2(firstBulletPosition.x + 0.5f, firstBulletPosition.y);
            Instantiate(_bulletGo, firstBulletPosition, Quaternion.identity);
            Instantiate(_bulletGo, secondBulletPosition, Quaternion.identity);
            Instantiate(_bulletGo, thirdBulletPosition, Quaternion.identity);
        }
    }
}
