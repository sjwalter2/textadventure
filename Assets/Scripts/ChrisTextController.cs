	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections;
	
	public class ChrisTextController : MonoBehaviour {
		
	public float Speed = 10;
		public float FadeOutSpeed = 0.1f;
		public Vector3 MoveToPosition = new Vector3 (0, -10);
	public float distanceOffset = 1*ChrisPlayerController.gameSpeed;
		public RectTransform RectTransform;
		public Text CustomText;
		
		// Use this for initialization
		void Start () {
			StartCoroutine (MoveAndFade ());
		}
		
		IEnumerator MoveAndFade()
		{
			while (true) {
			RectTransform.position -= Vector3.up * Time.deltaTime * Speed;
				CustomText.color -= new Color(0,0,0,FadeOutSpeed);
				
				if(Vector3.Distance(MoveToPosition, RectTransform.position) < distanceOffset)
					break;
				
				yield return null;
			}
		}
	}