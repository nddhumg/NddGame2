using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDark : NddBehaviour
{
	[SerializeField] protected Image img;
	private float maxOpacity = 0.7f;
	private float minOpacity = 0;
	private float opacity;

	protected override void LoadComponent()
	{
		LoadImg();
	}

	void OnEnable()
	{
		StartCoroutine(FadeOverTime(4f));
	}

	void OnDisable()
	{
		if (img != null)
		{
			Color tempColor = img.color;
			tempColor.a = minOpacity;
			img.color = tempColor;
		}
	}

	protected virtual void LoadImg()
	{
		if (img != null)
			return;
		img = transform.GetComponent<Image>();
		Debug.LogWarning("Thêm Hình ảnh", gameObject);
	}

	IEnumerator FadeOverTime(float time)
	{
		opacity = minOpacity;
		while (true)
		{
			if (opacity > maxOpacity)
			{
				yield break;
			}
			Color tempColor = img.color;
			tempColor.a = opacity;
			img.color = tempColor;
			opacity += (1f/255);
			yield return new WaitForSeconds(CalculateDelayTime(time));
		}
	}

	private float CalculateDelayTime(float time)
	{
		return time/(maxOpacity*255 - minOpacity );
	}
}
