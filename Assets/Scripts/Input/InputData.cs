using UnityEngine;

public class InputData : MonoBehaviour {

    [SerializeField]
    bool _up, _down, _left, _right, _dodge, _primary, _secondary, _interact;

    public bool up {
        get { return _up; }
        set { HandleDoubleInput(value, _down, out _up, out _down); }
    }

    public bool down {
        get { return _down; }
        set { HandleDoubleInput(_up, value, out _up, out _down); }
    }

    public bool left {
        get { return _left; }
        set { HandleDoubleInput(value, _right, out _left, out _right); }
    }

    public bool right {
        get { return _right; }
        set { HandleDoubleInput(_left, value, out _left, out _right); }
    }

    public  bool dodge {
        get { return _dodge; }
        set { _dodge = value; }
    }

    public bool primary {
        get { return _primary; }
        set { HandleDoubleInput(value, _secondary, out _primary, out _secondary); }
    }

    public bool secondary {
        get { return _secondary; }
        set { HandleDoubleInput(_primary, value, out _primary, out _secondary); }
    }

    public bool interact {
        get { return _interact; }
        set { _interact = value; }
    }

    /// <summary>
    /// Checks if both inputs is true.
    /// 
    /// If false sets toEditA to a
    /// and sets toEditB to b.
    /// 
    /// If true both out values return false.
    /// </summary>
    /// <param name="a">in value a</param>
    /// <param name="b">in value b</param>
    /// <param name="toEditA">out value a</param>
    /// <param name="toEditB">out value b</param>
    void HandleDoubleInput(bool a, bool b, out bool toEditA, out bool toEditB) {
        if (a && b) {
            toEditA = toEditB = false;
        } else {
            toEditA = a;
            toEditB = b;
        }
    }
}
