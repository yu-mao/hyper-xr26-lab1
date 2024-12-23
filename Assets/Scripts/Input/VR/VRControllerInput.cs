using UnityEngine;

public class VRControllerInput : MonoBehaviour, IControllerInput
{
    [SerializeField]
    private OVRInput.Controller controllerType;

    public Transform GetTransform()
    {
        return transform;
    }

    public bool IsTriggerPressed()
    {
        return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controllerType);
    }
}