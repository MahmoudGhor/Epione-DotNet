sendMessageToKey = function () {
    var messageToKey = document.getElementById('messageToKey').value;
    ws.send(JSON.stringify({ 'message': messageToKey, "doctorName": " ", "patientName": "Patient " + yourKey, "isPatient": "" }));
    document.getElementById('messageToKey').value = "";
    $(".messages").append('<div class="clearmsg1"><p class="msg1">' + messageToKey + '</p></div>');
};

connect = function () {

    yourKey = "1";
    var webSocketUrl = 'ws://localhost:18080/Epione_JEE-web/chat/quest/' + $("#username").val();
    ws = new WebSocket(webSocketUrl);
    ws.onopen = function () {
        ws.send(JSON.stringify({ 'message': "", "doctorName": " ", "patientName": "Patient " + yourKey, "isPatient": "true" }));
        setTimeout(function () {
            $(".buttonCon").hide();
            $(".message-box").show();
            $(".messages").show();
        }, 500);

    };

    ws.onmessage = function (event) {
        var json = JSON.parse(event.data);

        if (json.doctorName == "connectionOpen") {
            $(".messages").append('<div><p class="connectionDr">' + json.message + '</p></div>')
        }
        else if (json.doctorName == "connectionClose") {
            $(".messages").append('<div><p class="disconnectionDr">' + json.message + '</p></div>')
        } else {
            $(".messages").append('<div><p class="msg2">Dr.' + json.doctorName + ': ' + json.message + '</p></div>')
        }
       
    };

    ws.onclose = function () {
        $(".messages").append('<p class="disconnectionDr">closed!</p>')
    };

    ws.onerror = function (err) {
        $(".messages").append('<p class="disconnectionDr">' + err + '</p>')
    };
};

$(function () {
  var chatWidget = (".chat-widget-container"),
      chatBox = $(".chat-box-container");

  $(".chat-box-content").hide();
  $(".message-box").hide();
  $(".messages").hide();

	/* button */

  $( "#buttonCon" ).click(function() {
    $( "#buttonCon" ).addClass( "onclic", 250, validate);
    $(".chat-box-content").css("z-index", "3");
    connect();
    

  });

  function validate() {
    setTimeout(function() {
      $( "#buttonCon" ).removeClass( "onclic" );
      $( "#buttonCon" ).addClass( "validate", 450, callback );
    }, 2250 );
  }
    function callback() {
      setTimeout(function() {
        $( "#buttonCon" ).removeClass( "validate" );
      }, 1250 );
    }
  
  $(chatWidget).click(function(e){
    
    e.preventDefault();
    
    $(chatBox).toggleClass("show");
    $(".chat-box-content").toggle();
    $(chatWidget).toggleClass("open");
  })

  $(".messages").addClass("thin");
	$(".messages").mouseover(function(){
	  $(this).removeClass("thin");
	});
	$(".messages").mouseout(function(){
	  $(this).addClass("thin");
	});
	$(".messages").scroll(function () {
	  $(".messages").addClass("thin");
	});

	  
});