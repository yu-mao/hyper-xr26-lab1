using UnityEngine;

public interface IControllerInput
{
    Transform GetTransform();

    bool IsTriggerPressed();
    bool IsColorChangePressed();
}
