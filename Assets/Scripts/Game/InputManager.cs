using UnityEngine;

public class InputManager : NddBehaviour {
	[SerializeField] protected float keyHorizontal;
	[SerializeField] protected float keyVertical;
	[SerializeField] protected bool keySpace;
	[SerializeField] protected bool keyEsc;
	[SerializeField] protected Vector3 posMouse;
	[SerializeField] protected Vector2 downMouse;
	public float KeyHorizontal{
		get{
			return keyHorizontal;
		}
	}
	public float KeyVertical{
		get{
			return keyVertical;
		}
	}
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
		this.InputHorizontalAndVertical();
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

	protected void InputHorizontalAndVertical() {
		keyHorizontal = Input.GetAxisRaw ("Horizontal") ;
		keyVertical = Input.GetAxisRaw ("Vertical") ;
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
