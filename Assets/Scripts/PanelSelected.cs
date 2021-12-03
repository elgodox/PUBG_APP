using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelSelected : MonoBehaviour
{
    public GameObject container;
    private Animator _animator;
    private ObjectTournament _objectTournament;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _objectTournament = Resources.Load<ObjectTournament>("Tournament");
        _animator.Play("Exit");
    }

    public void Exit()
    {
        _animator.Play("Exit");
        var children = new List<GameObject>();
        foreach (Transform child in container.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
    }

    public void ShowTournament<T>(T gameObject)
    {
        _animator.Play("Enter");
        _objectTournament = gameObject as ObjectTournament;
        Instantiate(_objectTournament, container.transform);
    }

}
