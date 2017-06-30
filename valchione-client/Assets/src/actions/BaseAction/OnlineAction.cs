using UnityEngine;
using System.Collections;

// use if needed to send/receive data from server
public abstract class OnlineAction : Action {
    protected const string BASEURL = "http://localhost:8088/valchione-gamesvc";

    protected string url;

    // Returns an error message and does handling actions specified by child
    protected abstract string onError(int errorCode);

    // Actions specified child on successful submission
    protected abstract void onSuccess(string successWWWText);

    // Adds fields to form 
    protected abstract void addFields(WWWForm form);

    // Returns true if fields are the way you want them
    protected abstract bool fieldsValid();

    // Handles Invalid Fields; specified by child
    protected abstract void handleInvalidFields();

    
}
