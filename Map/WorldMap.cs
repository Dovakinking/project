using UnityEngine;

public class WorldMap : MonoBehaviour
{

	[SerializeField] private Transform target; // объект на основе которого делался скрин карты
	[SerializeField] private float zoomMultiple = 5; // во сколько раз возможно увеличение
	[SerializeField] private float zoomOffset = 0; // отступ от края экрана (при минимальном зуме)
	[SerializeField] private KeyCode showMap = KeyCode.M; // вкл./выкл.
	[SerializeField] private KeyCode findPlayer = KeyCode.Tab; // поиск игрока на карте
	[SerializeField] private RectTransform parent; // родительский объект для иконок карты, игрока и т.п.
	[SerializeField] private RectTransform mapRect; // трансформ иконки карты
	[SerializeField] private RectTransform player; // трансформ иконки игрока
	private static WorldMap _internal;
	private Vector3[] worldCorners = new Vector3[4];
	private float zoom, width, height, aspect, offset;
	private Vector3 offsetPosition;
	private static bool _active;
	private bool isDrag;
	public GameObject Gamer;

	public static bool isActive // карта развернута или нет, можно использовать для блокировки управления персонажем
	{
		get { return _active; }
	}

	void Awake()
	{
		aspect = target.localScale.x / target.localScale.y;
		zoom = 1;
		isDrag = false;
		Hide();
		_internal = this;
	}

	void CalculateScale() // масштабирование карты относительно текущего разрешения экрана вроде робит
	{
		if (target.localScale.x > target.localScale.y)
		{
			width = (float)Screen.width - (zoomOffset * 2);
			height = width / aspect;
			offset = width / target.localScale.x;
		}
		else
		{
			height = (float)Screen.height - (zoomOffset * 2);
			width = height * aspect;
			offset = height / target.localScale.y;
		}

		ZoomControl(0);
	}

	void FindPlayer() // функция поиска игрока робит
	{
		if (player == null) return;

		Rect rect = new Rect(0,Screen.width, 0,  Screen.height);

		if (!rect.Contains(player.position))
		{
			UpdateWorldCorners();
			Vector3 pos = new Vector3(Screen.width / 2, 0,Screen.height / 2) - player.position;
			if (worldCorners[0].x > 0 && worldCorners[2].x < Screen.width) 
				pos.x = 0;
			if (worldCorners[0].z > 0 && worldCorners[2].z < Screen.height) 
				pos.z = 0;
			parent.position += pos;
			UpdateWorldCorners();
			parent.position = PositionCorrection(parent.position);
		}
	}

	void MapControl()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && !isDrag)
		{
			ZoomControl(0.1f);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0 && !isDrag)
		{
			ZoomControl(-0.1f);
		}

		if (Input.GetKeyDown(findPlayer) && !isDrag)
		{
			FindPlayer();
		}
	}

	void ZoomControl(float value) // зум карты робит
	{
		zoom += value;
		zoom = Mathf.Clamp(zoom, 1, zoomMultiple);
		mapRect.sizeDelta = new Vector2(width * zoom, height * zoom);

		if (value < 0)
		{
			UpdateWorldCorners();
			parent.position = PositionCorrection(parent.position);
			if (worldCorners[0].x >= 0 && worldCorners[2].x <= Screen.width &&
				worldCorners[0].z >= 0 && worldCorners[2].z <= Screen.height) parent.localPosition = Vector3.zero;
		}
	}

	void Show()
	{
		CalculateScale();
		_active = true;
		parent.gameObject.SetActive(true);
	}

	void Hide()
	{
		_active = false;
		parent.gameObject.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(showMap) && !_active)
		{
			Show();
			Gamer.SetActive(false);
		}
		else if (Input.GetKeyDown(showMap) && _active)
		{
			Hide();
			Gamer.SetActive(true);
		}

		if (!_active) return;
		MapControl();
	}

	float Round(float f) // необходимое округление до сотых, чтобы исключить погрешности вычислений
	{
		return ((int)(f * 100f)) / 100f;
	}

	void UpdateWorldCorners() // получаем позиции углов иконки карты
	{
		mapRect.GetWorldCorners(worldCorners);
		worldCorners[0].x = Round(worldCorners[0].x);
		worldCorners[0].y = Round(worldCorners[0].y);
		worldCorners[2].x = Round(worldCorners[2].x);
		worldCorners[2].y = Round(worldCorners[2].y);
	}

	Vector3 PositionCorrection(Vector3 position) // функция "прилипания" к краю экрана
	{
		Vector3 pos = Vector3.zero;

		float x = Mathf.Max(worldCorners[0].x, Screen.width - worldCorners[2].x);
		float y = Mathf.Max(worldCorners[0].y, Screen.height - worldCorners[2].y);

		if (worldCorners[0].x > 0 && worldCorners[2].x > Screen.width) 
			pos.x = -x;
		else if (worldCorners[0].x < 0 && worldCorners[2].x < Screen.width) 
			pos.x = x;
		if (worldCorners[0].y > 0 && worldCorners[2].y > Screen.height) 
			pos.y = -y;
		else if (worldCorners[0].y < 0 && worldCorners[2].y < Screen.height) 
			pos.y = y;

		return position + pos;
	}

	bool CanMove(Vector2 delta, Vector3 position) // проверка на возможность "перетаскивания" карты
	{
		UpdateWorldCorners();

		if (worldCorners[0].x >= 0 && delta.x > 0 || worldCorners[2].x <= Screen.width && delta.x < 0
			|| worldCorners[0].y >= 0 && delta.y > 0 || worldCorners[2].y <= Screen.height && delta.y < 0)
		{
			offsetPosition = parent.position - position;
			return false;
		}

		return true;
	}

	public static Vector2 TransformPosition(Vector3 position)
	{
		return _internal.TransformPosition_internal(position);
	}

	public Vector2 TransformPosition_internal(Vector3 position)
	{
		Vector3 pos = position - target.position;
		return new Vector2(pos.x, pos.z) * zoom * offset;
	}

	public static void MapBeginDrag(Vector2 position)
	{
		_internal.MapBeginDrag_internal(position);
	}

	void MapBeginDrag_internal(Vector3 position)
	{
		isDrag = true;
		offsetPosition = parent.position - position;
	}

	public static void MapDrag(Vector3 position, Vector2 delta)
	{
		_internal.MapDrag_internal(position, delta);
	}

	void MapDrag_internal(Vector3 position, Vector2 delta)
	{
		if (CanMove(delta, position))
		{
			parent.position = position + offsetPosition;
		}

		parent.position = PositionCorrection(parent.position);
	}

	public static void MapEndDrag()
	{
		_internal.MapEndDrag_internal();
	}

	void MapEndDrag_internal()
	{
		isDrag = false;
	}
}