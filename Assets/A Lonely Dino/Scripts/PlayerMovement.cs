using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterController _charController;
    [SerializeField] private Animator _anim;
    private SoundManager _soundManager;

    [Header("Veriables")]
    [SerializeField] private Vector3 _Move;
    [SerializeField] private float _Speed,_gravity,_JumpForce,_vectorvalocity;
    [HideInInspector] public bool _PlayerMove = true;
    [HideInInspector] public bool _PlayerMove2;
    private string _Cactas;
    
    void Awake()
    {
       _Cactas = "Cactus";
    }
    void Start()
    {
        // Debug.Log(Vector3.right);
        _soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if(_PlayerMove2 == false)
        {
            if(Input.GetMouseButtonUp(0))
            {
                _PlayerMove2 =true;
            }
        }
        
        if(_PlayerMove && _PlayerMove2)
        {
            _anim.SetBool("PM",_PlayerMove);
            _Move = Vector3.zero;
            _Move = Vector3.right;
            if(_charController.isGrounded)
            {
                _vectorvalocity = -1;
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    _vectorvalocity = _JumpForce;
                    _soundManager.jupm();
                }
            }
            else
            {
                _vectorvalocity -= _gravity* Time.deltaTime;
            }
            _anim.SetBool("Ground",_charController.isGrounded);
            _Move.Normalize();
            _Move*= _Speed;
            _Move.y = _vectorvalocity;
            _charController.Move(_Move*Time.deltaTime);
        }
        else
        {
            if(_vectorvalocity < -.01 || _vectorvalocity >0)
            {
                _vectorvalocity -= _gravity* Time.deltaTime;
                _Move.y = _vectorvalocity;
                _charController.Move(_Move*Time.deltaTime);
            }
            if(_vectorvalocity <-80)
            {
                _vectorvalocity = 0;
            }
        }
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == _Cactas)
        {
            _PlayerMove = false;  
            _anim.SetTrigger("Ded");
            _soundManager.Death();
            _Cactas = "hi";
            Debug.Log("hi");
            
        }
    }



}
