async function getData(){
    var fetchedData
   await fetch('https://localhost:44337/api/Guests')
  .then(response => response.json())
  .then(data => fetchedData = data);
  console.log(fetchedData)

  for (var i = 0; i < fetchedData.length; i++) {
      document.getElementById("content").innerHTML+="<ul><li>"+
        fetchedData[i].id+"</li></ul>"
  }
}

async function login(){
    var user = {email:null, password:null};
    const email = document.getElementById("emailInput").value;
    const password = document.getElementById("passwordInput").value;
   try{
   await fetch('https://localhost:44337/api/Receptionist/' + email)
  .then(response => response.json())
  .then(data => user = data);
   }
   catch(e){
    document.getElementById("emailHelp").style.color = "red"; 
  document.getElementById("emailHelp").innerText = "Uneli ste pogrešan email!"; 
   }
  if(user.password != password && user.email != null) {
   document.getElementById("emailHelp").style.color = "red"; 
  document.getElementById("emailHelp").innerText = "Uneli ste pogrešnu lozinku!"; }
  else if(user.password == password && user.email != null)
   window.location.href = "rezervacije.html";
}
var reservationData
async function fetchReservations()
{
    var fetchedData;
     var counter = 0;
   await fetch('https://localhost:44337/api/Reservations')
  .then(response => response.json())
  .then(data => reservationData = fetchedData = data);
  for (var i = 0; i < fetchedData.length; i++) {
    if(fetchedData[i].accepted)
    {
      document.getElementById("content").innerHTML += `
      <tr>
                    <th scope="row">${fetchedData[i].guestID}</th>
                    <td>${fetchedData[i].hotelRoomNumber}</td>
                    <td>${fetchedData[i].checkInDate.replace("T", " ")}</td>
                    <td>${fetchedData[i].checkOutDate.replace("T", " ")}</td>
                </tr>`;
    }
    if(!reservationData[i].accepted) {
      counter ++;
    }
    }
   document.getElementById("newrs").innerText = `Nove rezervacije (${counter})`;
}
async function newReservation() {
  document.getElementById("content").innerHTML = "";
   for (var i = 0; i < reservationData.length; i++) {
     if(reservationData[i].accepted == false) {
      document.getElementById("content").innerHTML += `
      <tr>
                    <th scope="row">${reservationData[i].guestID}</th>
                    <td>${reservationData[i].hotelRoomNumber}</td>
                    <td>${reservationData[i].checkInDate}</td>
                    <td>${reservationData[i].checkOutDate} &nbsp;<i class="fas fa-check"  onclick = "doUpdate('${reservationData[i].guestID}', ${reservationData[i].hotelRoomNumber}, '${reservationData[i].checkInDate}', '${reservationData[i].checkOutDate}')" style="color:green;"></i>&nbsp; <i onClick="doDelete('${reservationData[i].guestID}', '${reservationData[i].hotelRoomNumber}', '${reservationData[i].checkInDate}')" class="fas fa-times" style="color:red;"></i>&nbsp;</td>
                </tr>`;
   }
  }
}

async function oldReservation() {
  document.getElementById("content").innerHTML = "";
   for (var i = 0; i < reservationData.length; i++) {
     if(reservationData[i].accepted == true) {
      document.getElementById("content").innerHTML += `
      <tr>
                    <th scope="row">${reservationData[i].guestID}</th>
                    <td>${reservationData[i].hotelRoomNumber}</td>
                    <td>${reservationData[i].checkInDate}</td>
                    <td>${reservationData[i].checkOutDate} &nbsp;<i class="fas fa-check"  style="color:green;"></i>&nbsp; <i onClick="doDelete('${reservationData[i].guestID}', '${reservationData[i].hotelRoomNumber}', '${reservationData[i].checkInDate}')" class="fas fa-times" style="color:red;"></i>&nbsp;</td>
                </tr>`;
   }
  }
}
async function deleteData(url = '') {
  // Default options are marked with *
  const response = await fetch(url, {
    method: 'DELETE', // *GET, POST, PUT, DELETE, etc.
    mode: 'cors', // no-cors, *cors, same-origin
    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials: 'same-origin', // include, *same-origin, omit
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: 'follow', // manual, *follow, error
    referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
    body: JSON.stringify("") // body data type must match "Content-Type" header
  });
  return response.json(); // parses JSON response into native JavaScript objects
}
async function doDelete(id, roomNumber, checkIn) {
  
  var url = 'https://localhost:44337/api/Reservations' + 
  `?guestID=${id}&hotelRoomNumber=${roomNumber}&checkInDate=${checkIn}`;
  await (deleteData(url)).then(
    await fetch('https://localhost:44337/api/Reservations')
  .then(response => response.json())
  .then(data => reservationData =  data)
  ).then(newReservation());
}
async function search() {
  document.getElementById("content").innerHTML = "";
  document.getElementById("no-content-found").innerHTML = "";
 
  for (var i = 0; i < reservationData.length; i++) {
      if(reservationData[i].guestID.includes(document.getElementById("search").value)) 
      {
        document.getElementById("content").innerHTML += `
      <tr>
                    <th scope="row">${reservationData[i].guestID}</th>
                    <td>${reservationData[i].hotelRoomNumber}</td>
                    <td>${reservationData[i].checkInDate}</td>
                    <td>${reservationData[i].checkOutDate}</td>
                    
                    
                </tr>`;
      }
  
    }
   
    if( document.getElementById("content").innerHTML == "") 
    {
       document.getElementById("no-content-found").innerHTML = `<h4 style="text-align:center;font-weight:600;color:wheat;" class="my-4">Rezervacija nije pronađena!</h4>`;
    }
}

async function postData(url = '', data = {}) {
  // Default options are marked with *
  const response = await fetch(url, {
    method: 'POST', // *GET, POST, PUT, DELETE, etc.
    mode: 'cors', // no-cors, *cors, same-origin
    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials: 'same-origin', // include, *same-origin, omit
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: 'follow', // manual, *follow, error
    referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
    body: JSON.stringify(data) // body data type must match "Content-Type" header
  });
  return response.json(); // parses JSON response into native JavaScript objects
}

async function insertGuest(){
  var jmbg = document.getElementById("jmbg").value;
  var name = document.getElementById("name").value;
  var surname = document.getElementById("surname").value;
  var idcard = document.getElementById("idcard").value;
  var guest = {
    id:jmbg,
    name:name,
    surname:surname,
    idCardNumber:idcard
  }; 
  const urlParams = new URLSearchParams(window.location.search);
  var myParam = parseInt(urlParams.get('roomnumber'));
  var checkInDate = document.getElementById("checkin").value;
  var checkOutDate = document.getElementById("checkout").value;
  var reservation = {
    guestID:jmbg,
    hotelRoomNumber:myParam,
    checkInDate:checkInDate,
    checkOutDate:checkOutDate


  }
  var success = false;
  await postData('https://localhost:44337/api/Guests', guest)
  .then(data => {
    console.log(data);
    success = data.statusCode == 200?true:false;
  }).then(
  postData('https://localhost:44337/api/Reservations', reservation)
  .then(data => {
    console.log(data);
        success = data.statusCode == 200?true:false;
  }));
  if (success)
  alert("Uspesan unos podataka");
  else
    alert("Neuspesan unos podataka");
}

function formatDate(){
  var date = new Date().toISOString().split('T')[0];
  $("#checkin").attr('min', date);
  $("#checkout").attr('min',date);
}

async function doUpdate(guestid, roomNumber, checkIn, checkOut) {
  var reservation = {
    guestID:guestid,
    hotelRoomNumber:roomNumber,
    checkInDate:checkIn,
    checkOutDate:checkOut,
    accepted:true 
}
  await (updateData('https://localhost:44337/api/Reservations', reservation)).then(
    await fetch('https://localhost:44337/api/Reservations')
  .then(response => response.json())
  .then(data => reservationData =  data)
  ).then(newReservation());
}
async function updateData(url = '', data ={}) {
  // Default options are marked with *
  const response = await fetch(url, {
    method: 'PUT', // *GET, POST, PUT, DELETE, etc.
    mode: 'cors', // no-cors, *cors, same-origin
    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials: 'same-origin', // include, *same-origin, omit
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: 'follow', // manual, *follow, error
    referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
    body: JSON.stringify(data) // body data type must match "Content-Type" header
  });
  return response.json(); // parses JSON response into native JavaScript objects
}