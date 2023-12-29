var price: float = 0;

//show the total prices in the guiText
function Update () 
{
 GetComponent.<GUIText>().text = price.ToString();
}

