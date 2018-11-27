$(document).ready(function () {

    $("#rate").rate({
        selected_symbol_type: 'image2',
        max_value: 5,
        step_size: 1,
        update_input_field_name: $("#inputRate"),

        only_select_one_symbol: true,
        symbols: {
            image2: {
                base: ['<div style="background-image: url(\'../img/emoji1.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji2.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji3.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji4.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji5.png\');" class="im2">&nbsp;</div>', ],
                hover: ['<div style="background-image: url(\'../img/emoji1.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji2.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji3.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji4.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji5.png\');" class="im2">&nbsp;</div>', ],
                selected: ['<div style="background-image: url(\'../img/emoji1.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji2.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji3.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji4.png\');" class="im2">&nbsp;</div>',
                       '<div style="background-image: url(\'../img/emoji5.png\');" class="im2">&nbsp;</div>', ],
            },
        },
    });
});

sendMessageToKey = function () {
    var messageToKey = document.getElementById('messageToKey').value;
    wsp.send(JSON.stringify({ 'message': messageToKey, "doctorName": "", "patientName": $("#username").val(), "isPatient": "" }));
    document.getElementById('messageToKey').value = "";
    $("#messagesPat").append('<div class="clearmsg1"><p class="msg1">' + messageToKey + '</p></div>');
};

sendMessageToPatient = function () {
    var message = document.getElementById('messageToPatient').value;
    document.getElementById('messageToPatient').value = "";
    $.ajax({
        type: "post",
        url: "Chat/send",
        data: {
            key: $("#key").val(),
            message: message
        },
        success: function (data) {
          
        }
    })
    
};



connect = function () {

    patient = $("#username").val();
    var webSocketUrl = 'ws://localhost:18080/Epione_JEE-web/chat/quest/' + $("#username").val();
    wsp = new WebSocket(webSocketUrl);
    wsp.onopen = function () {
        wsp.send(JSON.stringify({ 'message': "", "doctorName": " ", "patientName": $("#username").val(), "isPatient": "true" }));
        setTimeout(function () {
            $(".buttonCon").hide();
            $(".message-box").show();
            $("#messagesPat").show();
            $("#messagesPat").append('<div><p class="disconnectionDr"> Wait for a doctor to be connected </p></div>')
        }, 500);

    };

    wsp.onmessage = function (event) {
        var json = JSON.parse(event.data);

        if (json.doctorName == "connectionOpen") {
            $("#messagesPat").append('<div><p class="connectionDr">Dr.' + json.message + '</p></div>')
        }
        else if (json.doctorName == "connectionClose") {
            $("#messagesPat").append('<div><p class="disconnectionDr">Dr.' + json.message + '</p></div>')
        } else {
            $("#messagesPat").append('<div><p class="msg2">Dr.' + json.doctorName + ': ' + json.message + '</p></div>')
        }
       
    };

    wsp.onclose = function () {
        $("#messagesPat").append('<p class="disconnectionDr">closed!</p>')

    };

    wsp.onerror = function (err) {
        $("#messagesPat").append('<p class="disconnectionDr">' + err + '</p>')
    };
};

connectDoc = function (key) {

    $(".chat-box-content").css("z-index", "3");
    doc = $("#username").val();
    var webSocketUrl = 'ws://localhost:18080/Epione_JEE-web/chat/quest/' + key.textContent
    ws = new WebSocket(webSocketUrl);

    ws.onopen = function () {
        ws.send(JSON.stringify({ 'message': doc + " is connected", "doctorName": "connectionOpen", "patientName": "", "isPatient": "" }))
        $(".connectbtn1").hide();
        $(".message-box").show();
        $("#messagesDoc").show();
        $(".chat-box-nav").html("ChatRoom with " + key.textContent);
        $("#key").val(key.textContent);
    };

    ws.onmessage = function (event) {
        var json = JSON.parse(event.data);

        if (json.doctorName == "connectionOpen") {
            $("#messagesDoc").append('<div><p class="connectionDr">' + json.message + '</p></div>')
        }
        else if (json.doctorName == "connectionClose") {
            $("#messagesDoc").append('<div><p class="disconnectionDr">' + json.message + '</p></div>')
        }
        else if (json.doctorName == "connectionClosePa") {
            $("#messagesDoc").append('<div><p class="disconnectionDr">' + json.message + '</p></div>')
            setTimeout(function () {
                $(".message-box").hide();
                $("#messagesDoc").hide();
                $(".connectbtn1").show();
                $(".chat-box-nav").html("Answer questions");
                ws.close();
            }, 1000);
        }
        else if (json.doctorName == $("#username").val()) {
            $("#messagesDoc").append('<div class="clearmsg1"><p class="msg1">' + json.message + '</p></div>');
        }
        else if (json.doctorName == "") {
            $("#messagesDoc").append('<div><p class="msg2">' + json.patientName + ': ' + json.message + '</p></div>')
        }
        else {
            $("#messagesDoc").append('<div><p class="msg2">Dr.' + json.doctorName + ': ' + json.message + '</p></div>')
        }

    };

    ws.onclose = function () {
        $("#messagesDoc").append('<p class="disconnectionDr">closed!</p>');
        $(".message-box").hide();
        $("#messagesDoc").hide();
        $(".connectbtn1").show();
        $(".chat-box-nav").html("Answer questions");
    };
    ws.onerror = function (err) {
        appendMessage(err);
    };
};

function getKeys() {

    var xmlhttp;
    var xhttp = new XMLHttpRequest();
    xhttp.open('GET', 'http://127.0.0.1:18080/Epione_JEE-web/epione/messages/ques/PatientsQuestions/');
    xhttp.send(null);

    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4) {
            if (xhttp.status == 200) {
                var json = JSON.parse(xhttp.responseText);
                $(".connectbtn1").html("");
                for (var i in json) {
                    $(".connectbtn1").append('<button class="buttonUser" id="buttonUser" onclick="connectDoc(this);return false;">' + json[i].key + '</button>');
                }
                if($(".connectbtn1").html()=="")
                    $(".connectbtn1").append('<h1 class="NoPatient">no patient is available</h1>');
            }
        }

    }

}

function initTimer() {
    timer = setInterval(getKeys, 500);
}

$(function () {
  var chatWidget = (".chat-widget-container"),
      chatBox = $(".chat-box-container");

  $(".chat-box-content").hide();
  $(".message-box").hide();
  $(".messages").hide();

  window.onbeforeunload = closingSession;
  function closingSession() {
      //doctor is diconected
      if (ws) {
          ws.send(JSON.stringify({ 'message': +$("#username").val() + " is disconnected", "doctorName": "connectionClose", "patientName": "", "isPatient": "" }));
          ws.close();
      }
      //patient is disconnected
      if (wsp) {
          wsp.send(JSON.stringify({ 'message': patient + " is disconnected", "doctorName": "connectionClosePa", "patientName": "", "isPatient": "" }));
          wsp.close();
      }
      return null;
  }

	/* button */

  $( "#buttonCon" ).click(function() {
    $( "#buttonCon" ).addClass( "onclic", 250, validate);
    $(".chat-box-content").css("z-index", "3");
    connect();
  });

  $("#logout").click(function () {
      if (ws) {
          ws.onclose = function () { };
          ws.close();
      }
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