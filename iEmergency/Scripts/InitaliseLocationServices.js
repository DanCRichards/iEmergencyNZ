// This Script initalises the location services. 
// This requires the user to select if they want their location to be shared with the server. 
// Means that the browser can remember that the user wants to share this data and not require a popup later



window.onload = function getLocation() {
    if (navigator.geolocation) {
        return;
    } else {
        alert("Cannot find location. Detail");
    }
}