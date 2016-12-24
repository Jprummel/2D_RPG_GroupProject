using UnityEngine;

[RequireComponent(typeof(InputData))]
public class KeyboardInput : MonoBehaviour {

    KeyCode _upKeyCode = KeyCode.W;
    KeyCode _downKeyCode = KeyCode.S;
    KeyCode _leftKeyCode = KeyCode.A;
    KeyCode _rightKeyCode = KeyCode.D;

    KeyCode _dodgeKeyCode = KeyCode.Space;
    KeyCode _interactKeyCode = KeyCode.E;

    InputData inputData;

    //string _primary = "LMB";
    //string _secondary = "RMB";

    // For custom key binding
    public KeyCode upKeyCode {
        set { _upKeyCode = value; }
    }

    public KeyCode downKeyCode {
        set { _downKeyCode = value; }
    }

    public KeyCode leftKeyCode {
        set { _leftKeyCode = value; }
    }

    public KeyCode rightKeyCode {
        set { _rightKeyCode = value; }
    }

    public KeyCode dodgeKeyCode {
        set { _dodgeKeyCode = value; }
    }

    public KeyCode interactKeyCode {
        set { _interactKeyCode = value; }
    }

    void Start() {
        inputData = GetComponent<InputData>();
    }

    void Update() {
        inputData.up = Input.GetKey(_upKeyCode);
        inputData.down = Input.GetKey(_downKeyCode);
        inputData.left = Input.GetKey(_leftKeyCode);
        inputData.right = Input.GetKey(_rightKeyCode);

        inputData.dodge = Input.GetKey(_dodgeKeyCode);
        inputData.interact = Input.GetKeyDown(_interactKeyCode);

        inputData.primary = Input.GetMouseButtonDown(0);
        inputData.secondary = Input.GetMouseButtonDown(1);
    }
}
