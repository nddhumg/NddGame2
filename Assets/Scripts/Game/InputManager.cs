using UnityEngine;

public class InputManager : NddBehaviour {
	[SerializeField] protected Vector4 keyMoving;
	[SerializeField] protected bool keySpace;
	[SerializeField] protected bool keyEsc;
	[SerializeField] protected Vector3 posMouse;
	[SerializeField] protected Vector2 downMouse;
	public Vector4 KeyMoving => keyMoving;

	public bool KeySpace{
		get{
			return keySpace;
		}
	}
	public bool KeyEsc{
		get{
			return keyEsc;
		}
	}
	public Vector2 DownMouse{
		get{
			return downMouse;
		}
	}
	public Vector3 PosMouse{
		get{
			return posMouse;
		}
	}
	private static InputManager instance;
	public static InputManager Instance{
		get{
			return instance;
		}
	}

	// Update is called once per frame
	void Update () {
		this.InputKeyMoving();
		this.InputKeySpace();
		this.InputPosMouse ();
		this.InputMouseDown ();
		this.InputKeyEsc ();
	}
	protected override void LoadSingleton() {
		if (InputManager.instance != null) {
			Debug.LogError("Only 1 InputManager allow to exist");

		}
        InputManager.instance = this;
    }

	protected void InputKeyMoving() {
		/* X = RIGHT
		 * Y = LEFT
		 * Z = DOWN
		 * W = UP
		 */
		this.keyMoving.x = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) ? 1 : 0;
		this.keyMoving.y = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) ? 1 : 0;
        this.keyMoving.z = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) ? 1 : 0;
        this.keyMoving.w = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) ? 1 : 0;
    }
	protected void InputKeySpace() {
		this.keySpace = Input.GetKeyDown(KeyCode.Space);
	}
	protected void InputPosMouse() {
		this.posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	protected void InputKeyEsc(){
		this.keyEsc =Input.GetKeyDown(KeyCode.Escape);
	}
	protected void InputMouseDown(){
		this.downMouse.x =Input.GetMouseButton(0) ? 1  : 0;
		this.downMouse.y =Input.GetMouseButton(1) ? 1  : 0;
	}
}
