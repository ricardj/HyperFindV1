using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LabelListController : MonoBehaviour
{
    public string objectId;

    public TextMeshProUGUI textLabel;

    public void ConfigureLabel(LabelConfiguration labelConfiguration)
    {
        textLabel.text = labelConfiguration.labelText;
        objectId = labelConfiguration.objectId;
        Debug.Log("New object id is " + objectId);
    }

    public void ShowLabelFinishedFeedback()
    {
        textLabel.fontStyle = FontStyles.Strikethrough;
    }
}

public class LabelConfiguration
{
    public string labelText;
    public string objectId;
}
