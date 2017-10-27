var long = 20.1; // Values that force it to be a float
var lat = 10.1; // Not sure if JS has set variable types
 function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        alert("Cannot find location.");
    }
};

function showPosition(position) {
    lati = position.coords.latitude;
    long = position.coords.longitude;
    accuracy = position.coords.accuracy;
    var geocoder = new google.maps.Geocoder;
    
  
    
    var latlng = { lat: lati, lng: long };
    
    geocoder.geocode({ 'location': latlng }, function (results, status) {
        if (status === 'OK') {
            if (results[0]) {

                document.getElementById("MainContent_locationDescriptionHDN").value = results[0].formatted_address;
                
            }
        }

    });


    document.getElementById("MainContent_latitudeHDN").value = lati;
    document.getElementById("MainContent_longitudeHDN").value = long;
    document.getElementById("MainContent_accuracyHDN").value = accuracy;

   myMap() //goes here for aSync
    
}



function myMap() {
    var mapOptions = {
        center: new google.maps.LatLng(lat, long),
        zoom: 18,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var centerPosition = new google.maps.LatLng(lat, long);
   
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);

   

    var marker = new google.maps.Marker({
        position: centerPosition,
        map: map
        
    });

    var circle = new google.maps.Circle({
        center: centerPosition,
        radius: accuracy,
        map: map,
        fillColor: '#0000FF',
        fillOpacity: 0.5,
        strokeColor: '#0000FF',
        strokeOpacity: 1.0
    });



    //set the zoom level to the circle's size
    map.fitBounds(circle.getBounds());
            // End bweaver's code


}

