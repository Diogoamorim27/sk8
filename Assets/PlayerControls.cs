// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""916c5892-2e06-46ad-8916-29dea635857d"",
            ""actions"": [
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Button"",
                    ""id"": ""216fb92e-6624-442a-b075-85cc60616456"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Button"",
                    ""id"": ""860f5e34-0e28-4469-9148-ab57cad60261"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ResetSkatePos"",
                    ""type"": ""Button"",
                    ""id"": ""f19c8f07-9ebf-45fb-9181-17f8ce10e125"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8375f266-10d9-4ca7-aa14-a2740db72dcd"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b7bcc34-d7e6-4e6e-b677-2bb3ee5e5d1a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc1568fb-258a-44fc-802f-ef2ebfd0f3a0"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetSkatePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_LeftStick = m_Gameplay.FindAction("LeftStick", throwIfNotFound: true);
        m_Gameplay_RightStick = m_Gameplay.FindAction("RightStick", throwIfNotFound: true);
        m_Gameplay_ResetSkatePos = m_Gameplay.FindAction("ResetSkatePos", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_LeftStick;
    private readonly InputAction m_Gameplay_RightStick;
    private readonly InputAction m_Gameplay_ResetSkatePos;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStick => m_Wrapper.m_Gameplay_LeftStick;
        public InputAction @RightStick => m_Wrapper.m_Gameplay_RightStick;
        public InputAction @ResetSkatePos => m_Wrapper.m_Gameplay_ResetSkatePos;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @LeftStick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftStick;
                @RightStick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightStick;
                @ResetSkatePos.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnResetSkatePos;
                @ResetSkatePos.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnResetSkatePos;
                @ResetSkatePos.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnResetSkatePos;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
                @ResetSkatePos.started += instance.OnResetSkatePos;
                @ResetSkatePos.performed += instance.OnResetSkatePos;
                @ResetSkatePos.canceled += instance.OnResetSkatePos;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnLeftStick(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
        void OnResetSkatePos(InputAction.CallbackContext context);
    }
}
