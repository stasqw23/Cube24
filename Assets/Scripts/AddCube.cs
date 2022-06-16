using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCube : MonoBehaviour
{
    [SerializeField] private Transform _positionFirstCube;
    [SerializeField] private Transform _newPosition;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _collectText;
    [SerializeField] private Transform _spawnTransformText;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _cubeStackEffect;

    private Animator _animatorPlayer;

    void Start()
    {
        _animatorPlayer = _player.GetComponentInChildren<Animator>();
        _cubeStackEffect.Stop();
    }

    void Update()
    {
        
    }
    public void CreateCube(GameObject objectCreate)
    {
        _player.transform.position = _newPosition.position;
        Instantiate(objectCreate, _positionFirstCube).transform.SetParent(_player.transform);
        _animatorPlayer.SetTrigger("Jump");
        _cubeStackEffect.Play();



    }
    public void SpawnCollectText(Transform parent)
    {
        var text = Instantiate(_collectText, _spawnTransformText);
        text.GetComponentInChildren<Canvas>().worldCamera = _camera;
        text.transform.SetParent(parent.parent);
    }
}
