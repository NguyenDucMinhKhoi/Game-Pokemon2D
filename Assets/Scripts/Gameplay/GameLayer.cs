using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayer : MonoBehaviour
{
    [SerializeField] LayerMask solidobjectLayer;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask grassLayer;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask fovLayer;
    [SerializeField] LayerMask portalLayer;


    public static GameLayer i { get; set; }

    private void Awake()
    {
        i = this;
    }
    public LayerMask SoildLayer
    { get => solidobjectLayer; }
    public LayerMask InteractableLayer

    { get => interactableLayer; } 
    public LayerMask GrassLayer
    { get => grassLayer; }
    public LayerMask PlayerLayer
    { get => playerLayer; }
    public LayerMask FovLayer
    { get => fovLayer; }
    public LayerMask PortalLayer 
    { get => portalLayer; }
    public LayerMask TriggerableLayer
    { get => grassLayer | fovLayer | portalLayer; }
}
