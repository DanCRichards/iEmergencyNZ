/*
Dan Richards 2017.

This script finds the location of the user.
For some reason the HTML doesn't want to run this script


TESTING:
Doesn't work. Assumed to be around browser loading. 


*/
function getLocation() {
  
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(myMap);
    } else {
        alert("Location could not be accuratly tracked.");
    }
}



function myMap(position) {
    let long = position.coords.longitude;
    let lat = position.coords.latitude;
    var mapOptions = {
        center: new google.maps.LatLng(lat, long),
        zoom: 10,
        mapTypeId: google.maps.MapTypeId.HYBRID
    };
var map = new google.maps.Map(document.getElementById("map"), mapOptions);
}


// Need to make it so that it inserts into hidden forms. 