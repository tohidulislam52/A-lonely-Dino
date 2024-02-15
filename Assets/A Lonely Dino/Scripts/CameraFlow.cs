using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    [SerializeField] private Transform _terget;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _offset2;
    [SerializeField] private Vector3 _Rotation;
    [SerializeField] private float _smoothtime;
    private Vector3 _curentvelo = Vector3.zero; 
    private PlayerMovement _playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        _playerMovement= FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(_playerMovement._PlayerMove)
        {
        // transform.eulerAngles = _Rotation;
        Vector3 tergetPosition = _terget.position + _offset;
        tergetPosition.y = 14.2f;
        transform.position = Vector3.SmoothDamp(transform.position,tergetPosition,
             ref _curentvelo,_smoothtime);
        }
        else
        {
            Vector3 tergetPosition = _terget.position + _offset2;
            transform.eulerAngles =new Vector3(20,transform.eulerAngles.y,transform.eulerAngles.z);

            transform.position = Vector3.SmoothDamp(transform.position,tergetPosition,
                ref _curentvelo,1.1f);
        }
    }
}
