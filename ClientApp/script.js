function GetData(){
  console.log("GetData()");
  var requestInput = document.getElementById("exampleInputUrl");
  var methodInput = document.getElementById("exampleInputMethod");
  
  var request = new XMLHttpRequest();
  request.open(methodInput.value, requestInput.value, true);
  request.send();
  
  request.onload = function(){
    document.getElementById('responseTextArea').value = request.responseText;
  }
  
}

var btn = document.getElementById('sendBtn');
btn.addEventListener("click",GetData);