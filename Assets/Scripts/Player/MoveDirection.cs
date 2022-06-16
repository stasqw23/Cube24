using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveDirection : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Vector2 _moveDirection;
    [SerializeField] private GameObject _player;
    private PlayerMover _playerMoverScript;



    public Vector2 moveDirection { get { return _moveDirection; } }

    void Start()
    {
        _playerMoverScript = _player.GetComponent<PlayerMover>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {


    }

    public void OnDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
                _moveDirection = transform.right;
                _playerMoverScript.MowePlayer(-_player.transform.right);

            }
            else
            {
                _playerMoverScript.MowePlayer(_player.transform.right);
            }
        }

    }

}
