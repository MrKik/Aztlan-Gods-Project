//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/Input System/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""CharacterController"",
            ""id"": ""0848a5c3-4e4e-48d0-b0f3-41697dc19076"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""eb334374-682a-4a4e-a93e-d776ef64a2a3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Value"",
                    ""id"": ""91722f54-1f97-4d11-89fe-261b4a2aeed5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""011c36b3-61b9-4eb0-af5e-1a1c21ed931d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""0691605f-0101-439a-8438-7b408379927a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.05)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""93e4ad83-e408-4ddc-9c44-d6024a75f74f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""ecb4e6c7-2c18-4df4-b05e-28cbfb920138"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement 3D"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ba7d8ae4-e6bb-4658-a229-6ff0f244e75f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""87f33dbc-c500-4e17-8fd6-378c8bbc33d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Heal"",
                    ""type"": ""Button"",
                    ""id"": ""710820ab-17d5-4787-8909-50234b4cc248"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AimBall"",
                    ""type"": ""Value"",
                    ""id"": ""27c709d9-f08e-4ef4-b416-5e6d354cace2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""c451d569-6cb0-4920-920d-caeaa86d098e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.05)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8a472e2b-a843-42cf-b45b-8e394720399c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9315ff0-84a9-4cb3-bb88-29b93239323e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57afa41e-2eba-4cc6-8810-a7431bd41662"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20b6ea28-1503-4371-bc86-f1a00e1c0ef7"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6433be18-d651-4a02-9db0-b65a5c05f49d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""baa1b7f5-ecd4-4511-8b13-5dfcf9712ead"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""80bf62bf-d9bc-4f7d-a215-ad0a1cc16e68"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4a1291e2-f068-4d3a-b288-55194211c8a1"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""bdc583f6-2f0c-41a6-a54e-4797efb75c36"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""fb490dde-57cd-4bb4-b409-4129aedabcd0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""71385319-9cee-491c-92f8-8ac19e7fa28d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fe3f7623-86eb-4361-9dfd-068ab7d75a33"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Movement 3D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19a5143f-fede-4954-bbc8-4cba577006cf"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d31020b0-d1b4-45a3-b1db-25b71fd03a24"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c317631f-96d9-449a-bcfc-aa402f2b9e71"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7156b63-2bea-4fbf-98a1-91314296eb61"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a82707a-3592-400a-92d7-7039bff21156"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9fea490-0259-4b0e-8e7a-cc2adcea4219"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Hold(duration=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff2a80bb-52e7-4a5f-8bcf-512b43f960d4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b433517a-63ce-4806-943b-7b6030413729"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6336c54-8835-4ab1-a632-98198e60a067"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterController
        m_CharacterController = asset.FindActionMap("CharacterController", throwIfNotFound: true);
        m_CharacterController_Movement = m_CharacterController.FindAction("Movement", throwIfNotFound: true);
        m_CharacterController_Aiming = m_CharacterController.FindAction("Aiming", throwIfNotFound: true);
        m_CharacterController_Jump = m_CharacterController.FindAction("Jump", throwIfNotFound: true);
        m_CharacterController_Dash = m_CharacterController.FindAction("Dash", throwIfNotFound: true);
        m_CharacterController_Attack = m_CharacterController.FindAction("Attack", throwIfNotFound: true);
        m_CharacterController_Run = m_CharacterController.FindAction("Run", throwIfNotFound: true);
        m_CharacterController_Movement3D = m_CharacterController.FindAction("Movement 3D", throwIfNotFound: true);
        m_CharacterController_PauseGame = m_CharacterController.FindAction("PauseGame", throwIfNotFound: true);
        m_CharacterController_Heal = m_CharacterController.FindAction("Heal", throwIfNotFound: true);
        m_CharacterController_AimBall = m_CharacterController.FindAction("AimBall", throwIfNotFound: true);
        m_CharacterController_Shoot = m_CharacterController.FindAction("Shoot", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // CharacterController
    private readonly InputActionMap m_CharacterController;
    private ICharacterControllerActions m_CharacterControllerActionsCallbackInterface;
    private readonly InputAction m_CharacterController_Movement;
    private readonly InputAction m_CharacterController_Aiming;
    private readonly InputAction m_CharacterController_Jump;
    private readonly InputAction m_CharacterController_Dash;
    private readonly InputAction m_CharacterController_Attack;
    private readonly InputAction m_CharacterController_Run;
    private readonly InputAction m_CharacterController_Movement3D;
    private readonly InputAction m_CharacterController_PauseGame;
    private readonly InputAction m_CharacterController_Heal;
    private readonly InputAction m_CharacterController_AimBall;
    private readonly InputAction m_CharacterController_Shoot;
    public struct CharacterControllerActions
    {
        private @PlayerInput m_Wrapper;
        public CharacterControllerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharacterController_Movement;
        public InputAction @Aiming => m_Wrapper.m_CharacterController_Aiming;
        public InputAction @Jump => m_Wrapper.m_CharacterController_Jump;
        public InputAction @Dash => m_Wrapper.m_CharacterController_Dash;
        public InputAction @Attack => m_Wrapper.m_CharacterController_Attack;
        public InputAction @Run => m_Wrapper.m_CharacterController_Run;
        public InputAction @Movement3D => m_Wrapper.m_CharacterController_Movement3D;
        public InputAction @PauseGame => m_Wrapper.m_CharacterController_PauseGame;
        public InputAction @Heal => m_Wrapper.m_CharacterController_Heal;
        public InputAction @AimBall => m_Wrapper.m_CharacterController_AimBall;
        public InputAction @Shoot => m_Wrapper.m_CharacterController_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_CharacterController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControllerActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControllerActions instance)
        {
            if (m_Wrapper.m_CharacterControllerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement;
                @Aiming.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnAiming;
                @Jump.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnDash;
                @Attack.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnAttack;
                @Run.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnRun;
                @Movement3D.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement3D;
                @Movement3D.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement3D;
                @Movement3D.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement3D;
                @PauseGame.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnPauseGame;
                @Heal.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnHeal;
                @Heal.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnHeal;
                @Heal.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnHeal;
                @AimBall.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnAimBall;
                @AimBall.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnAimBall;
                @AimBall.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnAimBall;
                @Shoot.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_CharacterControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Movement3D.started += instance.OnMovement3D;
                @Movement3D.performed += instance.OnMovement3D;
                @Movement3D.canceled += instance.OnMovement3D;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @Heal.started += instance.OnHeal;
                @Heal.performed += instance.OnHeal;
                @Heal.canceled += instance.OnHeal;
                @AimBall.started += instance.OnAimBall;
                @AimBall.performed += instance.OnAimBall;
                @AimBall.canceled += instance.OnAimBall;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public CharacterControllerActions @CharacterController => new CharacterControllerActions(this);
    public interface ICharacterControllerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnMovement3D(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnHeal(InputAction.CallbackContext context);
        void OnAimBall(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
