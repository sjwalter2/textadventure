using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputFieldToText : MonoBehaviour {
	public InputField Field;
	public Text TextBox;
	public Text Machine;

	public void CopyText() {
		TextBox.text = Field.text;
		Machine.text = Field.text;
	}
}