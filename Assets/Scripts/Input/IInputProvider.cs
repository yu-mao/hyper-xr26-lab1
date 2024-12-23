using UnityEngine;

public interface IInputProvider
{
    bool TryInitialize();

    Transform GetHeadTransform();

    IControllerInput GetLeftController();
    IControllerInput GetRightController();
}
