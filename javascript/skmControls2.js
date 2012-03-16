function skm_CountTextBox(textboxId, outputId, formatString, treatCRasOneChar)
{
    var textBox = document.getElementById(textboxId);
    var output = document.getElementById(outputId);
    
    var tbText = textBox.value;
    var totalWords = 0;
    var totalChars = 0;

    // Count the total number of words...    
    var uniformSpaces = tbText.replace(/\s/g, ' ');
    var pieces = uniformSpaces.split(' ');

    for (var i = 0; i < pieces.length; i++)
        if (pieces[i].length > 0)
            totalWords++;

    // Count the total number of characters...
    if (treatCRasOneChar)
    {        
        var removedExtraChar = tbText.replace('\r\n', '\n');
        totalChars = removedExtraChar.length;
    }
    else   
        totalChars = tbText.length;
    
    
    output.innerHTML = formatString.replace('{0}', totalWords).replace('{1}', totalChars);
}
