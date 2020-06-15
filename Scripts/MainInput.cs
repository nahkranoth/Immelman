// GENERATED AUTOMATICALLY FROM 'Assets/Data/MainInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInput"",
    ""maps"": [
        {
            ""name"": ""Airplane"",
            ""id"": ""1e8d6f9e-8f05-4131-a6d1-730ea6a2114f"",
            ""actions"": [
                {
                    ""name"": ""Moving"",
                    ""type"": ""Button"",
                    ""id"": ""6b7d3f16-5b04-4fee-b9bb-a6d746678de2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""YawMoving"",
                    ""type"": ""Button"",
                    ""id"": ""42ff0984-ea67-42bb-9490-11dfd22a2fbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""dc36b70b-0525-4c95-9f0f-b99f3a3ef6ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""d6a36107-6c27-489f-b0ea-ead5fbed9c66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FreeLook"",
                    ""type"": ""Button"",
                    ""id"": ""a2466f7c-a691-4eed-956c-8720b2dba890"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Button"",
                    ""id"": ""4e83bc82-f801-4cd7-af72-78669138cd4c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""4b95ec41-3877-4212-9c37-2b4d580205e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""RollAndPitch"",
                    ""id"": ""fe432b7a-bc01-4e9b-9aac-3421ea74a6e4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""435d091b-9b99-469a-97db-c4011c051a72"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b7c303bd-4e07-4064-ba95-ddd22e583ae7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0b522880-eb34-4616-845e-9cf70561a46a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6455c572-5fd8-40b4-9976-b69d8a13a10b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1679f8c6-7a94-41af-8d1c-6e8ec35bfeb0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edc83520-8dda-4818-99ea-c3ebaa08bf32"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bb4fa79-1a1a-4fc3-b3e8-9c3bcf3490a4"",
                    ""path"": ""<Keyboard>/#(C)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FreeLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Yaw"",
                    ""id"": ""0b0bec5b-aac3-476b-ae13-c106ff299012"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawMoving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c6c22293-2350-467c-a895-1bdb50bdcdd6"",
                    ""path"": ""<Keyboard>/#(Q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawMoving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""900e0c5a-33ec-4a6e-9b4d-bdbe13bdfdba"",
                    ""path"": ""<Keyboard>/#(E)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawMoving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Throttle"",
                    ""id"": ""036fe851-148e-4ddc-a65b-a084a72113f0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""05cf847f-7b20-48ce-8654-a6d3be86cd5b"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""99f6cea9-2973-44b3-a47c-6f2c5b518494"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d389aa2b-8ab2-4a2f-81ac-04dad5f55029"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""fd2eb1b4-2b1f-4c6e-a68f-323368204437"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""a478ccd0-36cd-416f-85be-d0f1de21ea9b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""0055b188-3893-4c2d-9af9-510c3058a468"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b3c68cf1-a6ef-42e9-9b79-1ac4efb5eda4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""abaa2929-2d14-497b-9984-226a5c185fa4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleScoreboard"",
                    ""type"": ""Button"",
                    ""id"": ""284a22bf-5cfa-49f7-b085-efa74dd301ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""Button"",
                    ""id"": ""123cec7d-87c2-4506-a374-c1ed4916ac47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Click"",
                    ""type"": ""Button"",
                    ""id"": ""0fbf4b21-6d15-4e0e-b6e4-3d6f385e668c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1c6dcec0-1272-473a-9008-7e2389bb774c"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af1e05e5-0951-4913-9d44-99d2233aefa5"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdd7f06f-0296-4180-aaf0-70ba057aa7a5"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a75636a5-efd0-4616-b600-005ebf21e566"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f17033bc-ae38-410b-a61d-0ff65b26f11b"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""702462cc-c7d0-4b94-bd1a-05deceb21766"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79fd8791-c863-4461-a05d-645156224e24"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b2a7cbc-c76d-467d-98e2-006a7672b033"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8979a1e4-1acc-473f-82be-8a97b4845905"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1fe7d6d-2324-43b3-9a0f-5edd185306d1"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleScoreboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a20445b4-7032-4340-a7ac-a708b48cbe50"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92ee332c-a7ae-4897-b2ed-70958b100709"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Airplane
        m_Airplane = asset.FindActionMap("Airplane", throwIfNotFound: true);
        m_Airplane_Moving = m_Airplane.FindAction("Moving", throwIfNotFound: true);
        m_Airplane_YawMoving = m_Airplane.FindAction("YawMoving", throwIfNotFound: true);
        m_Airplane_Shoot = m_Airplane.FindAction("Shoot", throwIfNotFound: true);
        m_Airplane_Boost = m_Airplane.FindAction("Boost", throwIfNotFound: true);
        m_Airplane_FreeLook = m_Airplane.FindAction("FreeLook", throwIfNotFound: true);
        m_Airplane_Throttle = m_Airplane.FindAction("Throttle", throwIfNotFound: true);
        m_Airplane_Brake = m_Airplane.FindAction("Brake", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_ToggleScoreboard = m_UI.FindAction("ToggleScoreboard", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("Right Click", throwIfNotFound: true);
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

    // Airplane
    private readonly InputActionMap m_Airplane;
    private IAirplaneActions m_AirplaneActionsCallbackInterface;
    private readonly InputAction m_Airplane_Moving;
    private readonly InputAction m_Airplane_YawMoving;
    private readonly InputAction m_Airplane_Shoot;
    private readonly InputAction m_Airplane_Boost;
    private readonly InputAction m_Airplane_FreeLook;
    private readonly InputAction m_Airplane_Throttle;
    private readonly InputAction m_Airplane_Brake;
    public struct AirplaneActions
    {
        private @MainInput m_Wrapper;
        public AirplaneActions(@MainInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moving => m_Wrapper.m_Airplane_Moving;
        public InputAction @YawMoving => m_Wrapper.m_Airplane_YawMoving;
        public InputAction @Shoot => m_Wrapper.m_Airplane_Shoot;
        public InputAction @Boost => m_Wrapper.m_Airplane_Boost;
        public InputAction @FreeLook => m_Wrapper.m_Airplane_FreeLook;
        public InputAction @Throttle => m_Wrapper.m_Airplane_Throttle;
        public InputAction @Brake => m_Wrapper.m_Airplane_Brake;
        public InputActionMap Get() { return m_Wrapper.m_Airplane; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AirplaneActions set) { return set.Get(); }
        public void SetCallbacks(IAirplaneActions instance)
        {
            if (m_Wrapper.m_AirplaneActionsCallbackInterface != null)
            {
                @Moving.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnMoving;
                @Moving.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnMoving;
                @Moving.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnMoving;
                @YawMoving.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnYawMoving;
                @YawMoving.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnYawMoving;
                @YawMoving.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnYawMoving;
                @Shoot.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnShoot;
                @Boost.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnBoost;
                @Boost.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnBoost;
                @Boost.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnBoost;
                @FreeLook.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnFreeLook;
                @FreeLook.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnFreeLook;
                @FreeLook.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnFreeLook;
                @Throttle.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnThrottle;
                @Brake.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnBrake;
            }
            m_Wrapper.m_AirplaneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Moving.started += instance.OnMoving;
                @Moving.performed += instance.OnMoving;
                @Moving.canceled += instance.OnMoving;
                @YawMoving.started += instance.OnYawMoving;
                @YawMoving.performed += instance.OnYawMoving;
                @YawMoving.canceled += instance.OnYawMoving;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Boost.started += instance.OnBoost;
                @Boost.performed += instance.OnBoost;
                @Boost.canceled += instance.OnBoost;
                @FreeLook.started += instance.OnFreeLook;
                @FreeLook.performed += instance.OnFreeLook;
                @FreeLook.canceled += instance.OnFreeLook;
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
            }
        }
    }
    public AirplaneActions @Airplane => new AirplaneActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ToggleScoreboard;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    public struct UIActions
    {
        private @MainInput m_Wrapper;
        public UIActions(@MainInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ToggleScoreboard => m_Wrapper.m_UI_ToggleScoreboard;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @ToggleScoreboard.started -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleScoreboard;
                @ToggleScoreboard.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleScoreboard;
                @ToggleScoreboard.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleScoreboard;
                @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ToggleScoreboard.started += instance.OnToggleScoreboard;
                @ToggleScoreboard.performed += instance.OnToggleScoreboard;
                @ToggleScoreboard.canceled += instance.OnToggleScoreboard;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IAirplaneActions
    {
        void OnMoving(InputAction.CallbackContext context);
        void OnYawMoving(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnFreeLook(InputAction.CallbackContext context);
        void OnThrottle(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnToggleScoreboard(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
    }
}
