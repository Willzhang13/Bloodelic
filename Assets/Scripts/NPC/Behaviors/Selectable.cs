using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Profiling;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField]
    private GameObject _modelObject;
    [SerializeField]
    private GameObject _uiObject; //Will be a part of the object prefab, so will be added with it

    private WorldUI _uiScript;
    private Outline _outline;
    private BehaviorController _behaviorController;

    public GameObject ModelObject {
        get => _modelObject;
    }
    public GameObject UIObject {
        get => _uiObject;
    }
    public WorldUI UIScript {
        get => _uiScript;
    }
    public BehaviorController GetBehaviorController {
        get => _behaviorController;
    }

    public event Action<GameObject> ClickAction;
    public event Action<GameObject> HoverAction;

    // Start is called before the first frame update
    void Start()
    {
        _outline = _modelObject.GetComponent<Outline>();
        if (_outline == null) {
            _outline = _modelObject.AddComponent<Outline>();
        }
        _outline.enabled = false;

        _uiScript = _uiObject.GetComponent<WorldUI>();
        _behaviorController = GetComponent<BehaviorController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate() {
        CameraController.Instance.ClickAction += Click;
        CameraController.Instance.HoverAction += Hover;
    }

    public void Deactivate() {
        CameraController.Instance.ClickAction -= Click;
        CameraController.Instance.HoverAction -= Hover;
        _outline.enabled = false;
    }
    //These two probably repeative, and might be better to just go directly to CameraController action
    //But like having a middle man for now just in case there needs to be additional functionality and filtering
    public void Click(GameObject gO) {
        ClickAction?.Invoke(gO);
    }
    public void Hover(GameObject gO) {
        HoverAction?.Invoke(gO);
    }

    public void HoverSelect() {
        _outline.enabled = true;
    }
    public void HoverDeselect() {
        Debug.Log("Is this call??>>>>>>>>>>");
        _outline.enabled = false;
    }
}
